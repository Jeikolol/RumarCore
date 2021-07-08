var initBusinessOpportunitSmartWizardComponent = function(url, actionButtonId,modalContainer) {
    var reviewer = {
        Business: {
            Notes: "",
            Channel: "",
            Type: "",
            InputCurrency: "",
            InputInstrument: "",
            OutputCurrency: "",
            OutputInstrument: "",
            Amount: "",
            Rate: "",
            Trader: "",
            Init: function () {
                var channelText = $("#SelectedChannelId option:selected").text();
                var typeText = $("#SelectedBusinessTypeId option:selected").text();
                var inputCurrencyText = $("#SelectedInputCurrencyId option:selected").text();
                var inputInstrumentText = $("#SelectedInputInstrumentId option:selected").text();
                var outputCurrencyText = $("#SelectedOutputCurrencyId option:selected").text();
                var outputInstrumentText = $("#SelectedOutputInstrumentId option:selected").text();
                var traderText = $("#SelectedTraderId option:selected").text();
                var amountText = +$("#Amount").val();
                var rateText = +$("#Rate").val();
                var notesText = $("#business-notes").val();
                var totalText = amountText * rateText;

                this.Channel = channelText;
                this.Type = typeText;
                this.InputCurrency = inputCurrencyText;
                this.InputInstrument = inputInstrumentText;
                this.OutputCurrency = outputCurrencyText;
                this.OutputInstrument = outputInstrumentText;
                this.Trader = traderText;
                this.Amount =
                    amountText.toLocaleString('en', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                this.Rate = rateText.toLocaleString('en',
                    { minimumFractionDigits: 4, maximumFractionDigits: 4 });
                this.Total =
                    totalText.toLocaleString('en', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                this.Notes = notesText;
            }
        },
        Client: {
            IdentificationType: "",
            Identification: "",
            Name: "",
            Phone: "",
            Email: "",
            Init: function () {
                var identificationTypeText = $("#SelectedIdentificationTypeId option:selected").text();
                var identificationText = $("#Identification").val();
                var nameText = $("#Name").val();
                var phoneText = $("#Phone").val();
                var emailText = $("#Email").val();
                this.IdentificationType = identificationTypeText;
                this.Identification = identificationText;
                this.Name = nameText;
                this.Phone = phoneText;
                this.Email = emailText;
            }
        },
        Show: function () {
            $(".review-channel").text(this.Business.Channel);
            $(".review-business-type").text(this.Business.Type);
            $(".review-input-currency").text(this.Business.InputCurrency);
            $(".review-input-instrument").text(this.Business.InputInstrument);
            $(".review-output-currency").text(this.Business.OutputCurrency);
            $(".review-output-instrument").text(this.Business.OutputInstrument);
            $(".review-trader").text(this.Business.Trader);
            $(".review-amount").text(this.Business.Amount);
            $(".review-rate").text(this.Business.Rate);
            $(".review-total").text(this.Business.Total);
            $(".review-notes").text(this.Business.Notes);
               
            $(".review-identification-type").text(this.Client.IdentificationType);
            $(".review-identification").text(this.Client.Identification);
            $(".review-name").text(this.Client.Name);
            $(".review-phone").text(this.Client.Phone);
            $(".review-email").text(this.Client.Email);
        }
    }

    $(`#${actionButtonId}`).on('click',function () {
        $.showLoadingModal();
        $.get(url,
            function (data) {
                $(`#${modalContainer}`).html(data);
                $.hideLoadingModal();
                $(`#${modalContainer}`).modal('show');

                var btnFinish = $('<button id="finish-btn" disabled ></button>').text('Finalizar')
                    .addClass('btn btn-info')
                    .on('click',
                    function () {
                        $("#create-business-opportunity-form").trigger("submit");
                    });

                // Smart Wizard
                $('#add-business-opportunity-smart-wizard').smartWizard({
                    theme: 'circles',
                    transitionEffect: 'fade',
                    toolbarSettings: {
                        toolbarExtraButtons: [btnFinish]
                    },
                    lang: {
                        next: 'Siguiente',
                        previous: 'Atras'
                    }
                });

                putCancelButtonToSmartWizard("6%");
                moveButtonsSmartWizard("-6%");

                $("#add-business-opportunity-smart-wizard").on("showStep",
                    function (e, anchorObject, stepNumber, stepDirection) {
                        if (anchorObject.attr("data-review-step")) {
                            reviewer.Show();                   
                            $('#finish-btn').attr("disabled", false);
                        }
                    });

                $("#add-business-opportunity-smart-wizard").on("leaveStep",
                    function (e, anchorObject, stepNumber, stepDirection) {
                        stepNumber++;
                        if (stepDirection === "forward") {
                            //Ejecutando la validacion cuando se cambia de step
                            if ($("#step-" + stepNumber).validator('validate').has('.has-error').length) {
                                e.preventDefault();
                            }

                            if (stepNumber === 1) {
                                reviewer.Business.Init();
                            }
                            if (stepNumber === 2) {
                                reviewer.Client.Init();
                                var url = "/BusinessOpportunity/Step3Review?inputCurrencyId=" +
                                    $("#SelectedInputCurrencyId option:selected").val() +
                                    "&outputCurrencyId=" +
                                    $("#SelectedOutputCurrencyId option:selected").val();
                                $('a[href^="#step-3"]').attr("data-content-url", url);
                            }
                        }
                    });
            });
    });

    $(`#${modalContainer}`).on('hide.bs.modal',
        function (e) {
            var $smw = $('#add-business-opportunity-smart-wizard');
            if ($smw[0] !== undefined && e.target.id === `#${modalContainer}`) {
                $smw.smartWizard('reset');
            }
        });
}
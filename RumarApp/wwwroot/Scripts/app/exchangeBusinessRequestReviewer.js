function BusinessRequestReviewer() {
    this.Business = {
            Notes: "",
            PurchaseTypeJquery: "",
            InputCurrencyJquery: "",
            InputInstrument: "",
            OutputCurrencyJquery: "",
            OutputInstrument: "",
            InputAuxiliary: "",
            OutputAuxiliary: "",
            Amount: "",
            Rate: "",
            AmountRateTotal: "",
            PurchaseSource: "",
            Init: function () {
                var $purchaseType = $("#select2-exchange-type-select-container").first("span");
                var $inputCurrency = $("#input-currency-span");
                var $outputCurrency = $("#output-currency-span");

                var inputInstrumentText = $("#input-instrument-type").val();
                var outputInstrumentText = $("#output-instrument-type").val();
                var inputAuxiliaryText = $("#SelectedInputAuxiliaryTypeId option:selected").text();
                var outputAuxiliaryText = $("#SelectedOutputAuxiliaryTypeId option:selected").text();

                var purchaseSourceText = $("#SelectedPurchaseSourceId option:selected").text();
                var amountText = +$("#Amount").val();
                var rateText = +$("#Rate").val();
                var amountRateTotalText = $("#amount-rate-total-label").text();
                var notesText = $("#business-request-notes").val();

                var percentageCalculated = $("#PercentageCalculated").val();
                var percentageCommission = $("#PercentageCommission").val();
                var fixedCommission = $("#FixedCommission").val();
                var totalCommission = $("#total-main-label").text();
                var totalToPay = $("#amount-rate-total-with-comission-label").text();

                this.PurchaseTypeJquery = $purchaseType;
                this.InputCurrencyJquery = $inputCurrency;
                this.OutputCurrencyJquery = $outputCurrency;

                this.InputInstrument = inputInstrumentText;
                this.OutputInstrument = outputInstrumentText;
                this.InputAuxiliary = inputAuxiliaryText;
                this.OutputAuxiliary = outputAuxiliaryText;
                this.PurchaseSource = purchaseSourceText;
                this.Amount =
                    amountText.toLocaleString('en', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                this.Rate = rateText.toLocaleString('en', { minimumFractionDigits: 4, maximumFractionDigits: 4 });
                this.Notes = notesText;
                this.AmountRateTotal = amountRateTotalText;

                this.FixedCommission = convertToDouble(fixedCommission);
                this.PercentageCalculated = convertToDouble(percentageCalculated);
                this.TotalCommission = convertToDouble(totalCommission);
                this.PercentageCommission = convertToDouble(percentageCommission);
                this.TransactionTotalPlusOrMinusCommissionInLocalCurrency = totalToPay;
            }
        },
        this.Client = {
            IdentificationType: "",
            Identification: "",
            Name: "",
            CustomerCode: "",
            CustomerId: "",
            Init: function (genratedIdPrefix) {
                var identificationTypeText = $(`#${genratedIdPrefix}-cfs-widget-IdentificationTypeId option:selected`).text();
                var identificationText = $(`#${genratedIdPrefix}-cfs-widget-Identification`).val();
                var fullNameText = $(`#${genratedIdPrefix}-cfs-widget-FullName`).val();
                var customerCodeText = $(`#${genratedIdPrefix}-cfs-widget-CustomerCode`).val();
                var customerId = $(`#${genratedIdPrefix}-cfs-widget-SelectedCustomerId`).val();

                this.IdentificationType = identificationTypeText;
                this.Identification = identificationText;
                this.Name = fullNameText;
                this.CustomerCode = customerCodeText;
                this.CustomerId = customerId;
            }
        },
        this.Show = function () {
            $(".review-purchase-type").html(this.Business.PurchaseTypeJquery.html());
            $(".review-input-instrument").text(this.Business.InputInstrument);
            $(".review-output-instrument").text(this.Business.OutputInstrument);
            $(".review-input-auxiliary").text(this.Business.InputAuxiliary);
            $(".review-output-auxiliary").text(this.Business.OutputAuxiliary);
            $(".review-purchase-source").text(this.Business.PurchaseSource);
            $(".review-amount").text(this.Business.Amount);
            $(".review-rate").text(this.Business.Rate);
            $(".review-notes").text(this.Business.Notes);
            $(".review-amount-rate-total").text(this.Business.AmountRateTotal);
            $(".review-identification-type").text(this.Client.IdentificationType);
            $(".review-identification").text(this.Client.Identification);
            $(".review-name").html(`<a target="_blank" href="/Customer/Details?id=${this.Client.CustomerId}">${this.Client.CustomerCode} - ${this.Client.Name}</a >`);

            $(".review-fixed-comission").text(this.Business.FixedCommission.toLocaleString('en', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
            $(".review-percentaje-calculated").text(this.Business.PercentageCalculated.toLocaleString('en', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
            $(".review-total-comission").text(this.Business.TotalCommission.toLocaleString('en', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
            $(".review-percentaje-comission").text(this.Business.PercentageCommission + "%");
            $(".review-transaction-total-plus-or-minus-commission-in-local-currency").text(this.Business.TransactionTotalPlusOrMinusCommissionInLocalCurrency);


        }
};


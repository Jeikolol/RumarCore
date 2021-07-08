var InitWizardStepListSelector = function (list, uniqueIdPrefix, formElemntsMapping) {

    var uniquePrefix = uniqueIdPrefix;
    var beneficiaries = list;
    var formElements = new FormElements(formElemntsMapping);

    init();

    function fillBeneficiaryInfoStep(mappedObject) {
        var beneficiary = new BeneficiaryInfo(mappedObject);
        $(`#${uniquePrefix}-cfs-widget-IdentificationTypeId`).val(beneficiary.IdentificationTypeId).attr("readonly", true).trigger('change');
        $(`#${uniquePrefix}-cfs-widget-Identification`).val(beneficiary.Identification).attr("readonly", true);
        $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).val(beneficiary.IdentificationCountryId).attr("readonly", true);
        $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).trigger('change');

        $(`#${uniquePrefix}-cfs-widget-FirstName`).val(beneficiary.FirstName).attr("readonly", true);

        if (beneficiary.IdentificationCountryId == 1 && beneficiary.IdentificationTypeId) {
            $(`#${uniquePrefix}-cfs-widget-LastName`).val("").attr("readonly", true);
        }
        else {
            $(`#${uniquePrefix}-cfs-widget-LastName`).val(beneficiary.LastName).attr("readonly", true);
        }

        $(`#${uniquePrefix}-cfs-widget-FullName`).val(`${beneficiary.FirstName} ${beneficiary.LastName}`);

        $(`${formElements.EntityId}`).val(beneficiary.EntityId);
        $(`${formElements.EconomicActivityId}`).val(beneficiary.EconomicActivityId).attr("readonly", true).trigger('change');
        $(`${formElements.EconomicActivityCompanyId}`).val(beneficiary.EconomicActivityCompanyId).attr("readonly", true).trigger('change');

        $(`${formElements.Email}`).val(beneficiary.Email).attr("readonly", true);
        $(`${formElements.Phone}`).val(beneficiary.Phone).attr("readonly", true);
        $(`${formElements.Notes}`).text(beneficiary.Notes).attr("readonly", true);
        $(`${formElements.Address}`).val(beneficiary.Address).attr("readonly", true);
        $(`${formElements.Relationship}`).val(beneficiary.Relationship).attr("readonly", true);

        var select2DataUrl = `/Customer/SearchEconomicalActivityGubermentById?id=${beneficiary.EconomicActivityId}`;

        $.get(select2DataUrl, function (data) {
            if (data) {
                var newOption = new Option(data.text, data.id, false, true);
                $(`${formElements.EconomicActivityId}`).append(newOption).attr("readonly", true).trigger('change');
            }
        });

        $(`${formElements.IsEditingBeneficiaryInfoId}`).iCheck('enable');
        $(`${formElements.EconomicActivityName}`).val(beneficiary.EconomicActivityName).attr("readonly", true);
        $("#edit-beneficiary-info-container").show('fast');
    }

    function cleanCustomerWidgetInfo() {
        $(`#${uniquePrefix}-cfs-widget-CustomerCode`).val("");
        $(`#${uniquePrefix}-cfs-widget-IdentificationTypeId`).val("");
        $(`#${uniquePrefix}-cfs-widget-IdentificationTypeId`).trigger('change');
        $(`#${uniquePrefix}-cfs-widget-FirstName`).val("");
        $(`#${uniquePrefix}-cfs-widget-LastName`).val("");
        $(`#${uniquePrefix}-cfs-widget-Identification`).val("");
        $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).val("");
        $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).trigger('change');
    }
    function cleanFormElementsInfo() {
        $(`${formElements.EntityId}`).val("");
        $(`${formElements.EconomicActivityId}`).val("").trigger('change');
        $(`${formElements.EconomicActivityCompanyId}`).val("").trigger('change');

        $(`${formElements.EconomicActivityName}`).val("");
        $(`${formElements.Email}`).val("");
        $(`${formElements.Phone}`).val("");
        $(`${formElements.Address}`).val("");
        $(`${formElements.Relationship}`).val("");
        $(`${formElements.IsEditingBeneficiaryInfoId}`).iCheck('disabled');
        $(`${formElements.Notes}`).text("");
        $("#edit-beneficiary-info-container").hide('fast');
    }

    function disableCustomerWidgetInputs(booleanState) {
        $(`#${uniquePrefix}-cfs-widget-CustomerCode`).attr("readonly", booleanState);
        $(`#${uniquePrefix}-cfs-widget-IdentificationTypeId`).attr("readonly", booleanState);
        $(`#${uniquePrefix}-cfs-widget-IdentificationTypeId`).trigger('change');
        $(`#${uniquePrefix}-cfs-widget-FirstName`).attr("readonly", booleanState);
        $(`#${uniquePrefix}-cfs-widget-Identification`).attr("readonly", booleanState);
        $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).attr("readonly", booleanState);
        $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).trigger('change');
        $(`#${uniquePrefix}-cfs-widget-LastName`).attr("readonly", booleanState);
    }
    function disableFormElementsInputs(booleanState) {
        $(`${formElements.EconomicActivityId}`).attr("readonly", booleanState).trigger('change');
        $(`${formElements.EconomicActivityName}`).attr("readonly", booleanState);
        $(`${formElements.Email}`).attr("readonly", booleanState);
        $(`${formElements.Phone}`).attr("readonly", booleanState);
        $(`${formElements.Notes}`).attr("readonly", booleanState);
        $(`${formElements.Address}`).attr("readonly", booleanState);
        $(`${formElements.Relationship}`).attr("readonly", booleanState);
        $(`${formElements.EconomicActivityCompanyId}`).attr("readonly", booleanState).trigger('change');
    }

    function cleanBeneficiaryStep() {
        cleanCustomerWidgetInfo();
        cleanFormElementsInfo();
        disabledBeneficiaryInfoInputs(false);
    }

    function disabledBeneficiaryInfoInputs(booleanState) {
        disableCustomerWidgetInputs(booleanState);
        disableFormElementsInputs(booleanState);
    }

    function init() {
        $(`${formElements.IsEditingBeneficiaryInfoId}`).iCheck({
            checkboxClass: 'icheckbox_square-green',
            radioClass: 'iradio_square-green'
        });

        $(`${formElements.IsEditingBeneficiaryInfoId}`).iCheck('disable');

        $("#main-step-container").on("click", "div.element-info", function () {
            var id = $(this).data("id");
            var parent = $('#container-info');
            parent.find(".element-info").removeClass("element-info-selected");
            $(this).addClass("element-info-selected");
            if (id === -1) {
                cleanBeneficiaryStep();
            } else {
                fillBeneficiaryInfoStep(beneficiaries[id]);
            }
            $(`${formElements.IsEditingBeneficiaryInfoId}`).iCheck('uncheck');
        });

        $(`${formElements.IsEditingBeneficiaryInfoId}`).on('ifChecked', function (event) {
            disabledBeneficiaryInfoInputs(false);
        });

        $(`${formElements.IsEditingBeneficiaryInfoId}`).on('ifUnchecked', function (event) {
            disabledBeneficiaryInfoInputs(true);
        });

        $(`${formElements.EconomicActivityId}`).each(function () {
            var $this = $(this);

            var endpointUrl = $this.data('ajaxurl');
            $this.select2({
                placeholder: "Escriba una actividad economica",
                allowClear: true,
                ajax: {
                    url: endpointUrl,
                    dataType: 'json',
                    delay: 250,
                    data: function (params) {
                        return {
                            q: params.term,
                            page: params.page
                        };
                    },
                    processResults: function (data) {
                        return {
                            results: $.map(data,
                                function (obj) {
                                    return { id: obj.Id, text: `${obj.Code} - ${obj.Description}`};
                                })
                        };
                    }
                }
            });
        });

    }

   // DO NOT TOUCH, ASK FIRST
    function FormElements (mappingObject) {
        return {
            IsEditingBeneficiaryInfoId: mappingObject.IsEditingBeneficiaryInfoId,
            EntityId: mappingObject.EntityId,
            EconomicActivityName: mappingObject.EconomicActivityDescription,
            EconomicActivityId: mappingObject.EconomicActivityId,
            Email: mappingObject.Email,
            Phone: mappingObject.Phone,
            Notes: mappingObject.Notes,
            Address: mappingObject.Address,
            Relationship: mappingObject.Relationship,
            EconomicActivityCompanyId : mappingObject.EconomicActivityCompanyId
        }
    }
    // DO NOT TOUCH, ASK FIRST
    function BeneficiaryInfo(mappingObject) {
        return {
            IdentificationTypeId: mappingObject.IdentificationTypeId,
            FirstName: mappingObject.FirstName,
            LastName: mappingObject.LastName,
            Identification: mappingObject.Identification,
            IdentificationCountryId: mappingObject.IdentificationCountryId,
            EconomicActivityId: mappingObject.EconomicalActivityId,
            EconomicActivityName: mappingObject.EconomicalActivityDescription,
            Email: mappingObject.Email,
            Phone: mappingObject.Phone,
            Notes: mappingObject.Notes,
            EntityId: mappingObject.EntityId,
            Relationship: mappingObject.Relationship,
            EconomicActivityCompanyId : mappingObject.EconomicalActivityCompanyId
        }
    }

    function setBeneficiaryDataWithCustomer(customerCode) {
        var url = `/CustomerFinderWidget/SearchCustomerByCode?code=${customerCode}`;

        $.get(url, function (dataCustomerInfot) {
            if (dataCustomerInfot.hasOwnProperty("Identification")) {
                $(`#${uniquePrefix}-cfs-widget-SelectedCustomerId`).val(dataCustomerInfot.Id).trigger("change");;
                $(`#${uniquePrefix}-cfs-widget-IdentificationTypeId`).val(dataCustomerInfot.IdentificationTypeId).attr("readonly", true).trigger('change');
                $(`#${uniquePrefix}-cfs-widget-CustomerCode`).val(dataCustomerInfot.Code).attr("readonly", true);
                $(`#${uniquePrefix}-cfs-widget-Identification`).val(dataCustomerInfot.Identification).attr("readonly", true);
                $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).val(dataCustomerInfot.IdentificationCountryId).attr("readonly", true);
                $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).trigger('change');

                $(`#${uniquePrefix}-cfs-widget-FirstName`).val(dataCustomerInfot.FirstName).attr("readonly", true);

                if (dataCustomerInfot.IdentificationCountryId == 1 && dataCustomerInfot.IdentificationTypeId) {
                    $(`#${uniquePrefix}-cfs-widget-LastName`).val("").attr("readonly", true);
                }
                else {
                    $(`#${uniquePrefix}-cfs-widget-LastName`).val(dataCustomerInfot.LastName).attr("readonly", true);
                }

                $(`#${uniquePrefix}-cfs-widget-FullName`).val(`${dataCustomerInfot.FirstName} ${dataCustomerInfot.LastName}`);

                $(`${formElements.EntityId}`).val(dataCustomerInfot.EntityId);
                $(`${formElements.EconomicActivityId}`).val(dataCustomerInfot.EconomicActivityId).attr("readonly", true).trigger('change');
                $(`${formElements.EconomicActivityCompanyId}`).val(dataCustomerInfot.EconomicActivityCompanyId).attr("readonly", true).trigger('change');

                $(`${formElements.Email}`).val(dataCustomerInfot.Email).attr("readonly", true);
                $(`${formElements.Phone}`).val(dataCustomerInfot.Phone).attr("readonly", true);
                $(`${formElements.Notes}`).text(dataCustomerInfot.Notes).attr("readonly", true);
                $(`${formElements.Address}`).val(dataCustomerInfot.Address).attr("readonly", true);
                $(`${formElements.Relationship}`).val("Es El Mismo Cliente").attr("readonly", true);
                $(`${formElements.EconomicActivityName}`).attr("readonly", true);
            }
        });
    }

    $("#copy-customer-data").on("click", function () {
        var customerCode = $("input[name='CustomerCode']").val();

        setBeneficiaryDataWithCustomer(customerCode);
    });
};


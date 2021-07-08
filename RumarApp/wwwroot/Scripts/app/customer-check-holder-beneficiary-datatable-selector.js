var CustomerCheckHolderBeneficiaryDatatableSelector = function (uniqueIdPrefix, formElemntsMapping) {

    var uniquePrefix = uniqueIdPrefix;
    var formElements = new FormElements(formElemntsMapping);

    init();

    var selft = this;
    this.fillInfoStep = function (mappedObject) {
        var formInfo = new FormInfo(mappedObject);

        $(`#${uniquePrefix}-cfs-widget-IdentificationTypeId`).val(formInfo.IdentificationTypeId).trigger('change');
        $(`#${uniquePrefix}-cfs-widget-FirstName`).val(formInfo.FirstName);
        $(`#${uniquePrefix}-cfs-widget-LastName`).val(formInfo.LastName);
        $(`#${uniquePrefix}-cfs-widget-FullName`).val(`${formInfo.FirstName} ${formInfo.LastName}`);
        $(`#${uniquePrefix}-cfs-widget-Identification`).val(formInfo.Identification);
        $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).val(formInfo.IdentificationCountryId).trigger('change');

        $(`${formElements.EntityId}`).val(formInfo.EntityId);
        $(`${formElements.CustomerCheckHolderId}`).val(formInfo.CustomerCheckHolderId);
        $(`${formElements.EconomicActivityId}`).val(formInfo.EconomicActivityId).trigger('change');
        $(`${formElements.EconomicActivityCompanyId}`).val(formInfo.EconomicActivityCompanyId).trigger('change');

        $(`${formElements.EconomicActivityDescription}`).val(formInfo.EconomicActivityDescription);
        $(`${formElements.Relationship}`).val(formInfo.Relationship);
        $(`${formElements.Email}`).val(formInfo.Email);
        $(`${formElements.Phone}`).val(formInfo.Phone);
        $(`${formElements.Notes}`).text(formInfo.Notes);
        $(`${formElements.BirthDate}`).val(formInfo.BirthDate);
        $(`${formElements.NationalityId}`).val(formInfo.NationalityId).trigger('change');

        if (formInfo.Address && formInfo.Address.AddressLine1) {
            $(`${formElements.Address}`).val(formInfo.Address.AddressLine1);
        }
        else {
            $(`${formElements.Address}`).val(formInfo.Address);
        }

        $(`${formElements.PaymentReason}`).val(formInfo.PaymentReason);
        $(`${formElements.SourceOfFunds}`).val(formInfo.SourceOfFunds);

        var select2DataUrl = `/Customer/SearchEconomicalActivityGubermentById?id=${formInfo.EconomicActivityId}`;
        $.get(select2DataUrl, function (data) {
            if (data) {
                var newOption = new Option(data.text, data.id, false, true);
                $(`${formElements.EconomicActivityId}`).append(newOption).trigger('change');
            }
        });

        if (formInfo.NationalityId) {
            $.get(`/CountryBank/GetCountryById?id=${formInfo.NationalityId}`, function (data) {
                if (data) {
                    var newOption = new Option(data.text, data.id, false, true);
                    $(`${formElements.NationalityId}`).append(newOption).trigger('change');
                }
            });
        }

        $.selectDefaultDate(formInfo.BirthDate, formElements.BirthDate);

        $(`${formElements.IsEditingBeneficiaryInfoId}`).iCheck('enable');
        $(`${formElements.EditInfoContainer}`).show('fast');

        $(`${formElements.ClearFormButtonId}`).on("click", function () {
            selft.cleanInfoStep();
        });

        setInputsState(true);
    }

    this.cleanInfoStep = function () {
        $(`${formElements.IsEditingBeneficiaryInfoId}`).iCheck('uncheck');
        cleanCustomerWidgetInfo();
        cleanFormElementsInfo();
        setInputsState(false);
        $(`${formElements.ClearFormButtonId}`).off("click");
    }

    function setInputsState (booleanState) {
        disableCustomerWidgetInputs(booleanState);
        disableFormElementsInputs(booleanState);
    }

    this.getInfoStep = function () {
        var mappedObjectForm = {
            IdentificationTypeId: $(`#${uniquePrefix}-cfs-widget-IdentificationTypeId`).val(),
            FirstName: $(`#${uniquePrefix}-cfs-widget-FirstName`).val(),
            LastName: $(`#${uniquePrefix}-cfs-widget-LastName`).val(),
            FullName: $(`#${uniquePrefix}-cfs-widget-FullName`).val(),
            Identification: $(`#${uniquePrefix}-cfs-widget-Identification`).val(),
            IdentificationCountryId: $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).val(),
            EconomicActivityId: $(`${formElements.EconomicActivityId} :selected`).val(),
            EconomicActivityDescription: $(`${formElements.EconomicActivityDescription}`).val(),
            Email: $(`${formElements.Email}`).val(),
            Phone: $(`${formElements.Phone}`).val(),
            Address: $(`${formElements.Address}`).val(),
            Notes: $(`${formElements.Notes}`).val(),
            EntityId: $(`${formElements.EntityId}`).val(),
            Relationship: $(`${formElements.Relationship}`).val(),
            EconomicActivityCompanyId: $(`${formElements.EconomicActivityCompanyId}`).val(),
            PaymentReason: $(`${formElements.PaymentReason}`).val(),
            SourceOfFunds: $(`${formElements.SourceOfFunds}`).val(),
            BirthDate: $(`${formElements.BirthDate}`).val(),
            NationalityId: $(`${formElements.NationalityId} :selected`).val(),
        }
        return mappedObjectForm;
    }

    function cleanCustomerWidgetInfo() {
        $(`#${uniquePrefix}-cfs-widget-CustomerCode`).val("");
        $(`#${uniquePrefix}-cfs-widget-IdentificationTypeId`).val("").trigger('change');
        $(`#${uniquePrefix}-cfs-widget-FirstName`).val("");
        $(`#${uniquePrefix}-cfs-widget-LastName`).val("");
        $(`#${uniquePrefix}-cfs-widget-Identification`).val("");
        $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).val("").trigger('change');
    }

    function cleanFormElementsInfo() {
        $(`${formElements.EntityId}`).val("");
        $(`${formElements.EconomicActivityId}`).val("").trigger('change');
        $(`${formElements.EconomicActivityCompanyId}`).val("").trigger('change');

        $(`${formElements.EconomicActivityDescription}`).val("");
        $(`${formElements.CustomerCheckHolderId}`).val("");
        $(`${formElements.Email}`).val("");
        $(`${formElements.Phone}`).val("");
        $(`${formElements.Address}`).val("");
        $(`${formElements.Relationship}`).val("");
        $(`${formElements.IsEditingBeneficiaryInfoId}`).iCheck('disabled');
        $(`${formElements.Notes}`).text("");

        $(`${formElements.EditInfoContainer}`).hide('fast');
        $(`${formElements.BirthDate}`).val("");
        $(`${formElements.NationalityId}`).val("").trigger('change');
    }

    function disableCustomerWidgetInputs(booleanState) {
        $(`#${uniquePrefix}-cfs-widget-search-by-code-command`).attr("readonly", booleanState);
        $(`#${uniquePrefix}-cfs-widget-search-by-identification-command`).attr("readonly", booleanState);
        $(`#${uniquePrefix}-cfs-widget-CustomerCode`).attr("readonly", booleanState);
        $(`#${uniquePrefix}-cfs-widget-IdentificationTypeId`).attr("readonly", booleanState);
        $(`#${uniquePrefix}-cfs-widget-IdentificationTypeId`).trigger('change');
        $(`#${uniquePrefix}-cfs-widget-FirstName`).attr("readonly", booleanState);
        $(`#${uniquePrefix}-cfs-widget-Identification`).attr("readonly", booleanState);
        $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).attr("readonly", booleanState).trigger('change');
        $(`#${uniquePrefix}-cfs-widget-LastName`).attr("readonly", booleanState);
    }

    function disableFormElementsInputs(booleanState) {
        $(`${formElements.EconomicActivityId}`).attr("readonly", booleanState).trigger('change');
        $(`${formElements.EconomicActivityCompanyId}`).attr("readonly", booleanState).trigger('change');
        $(`${formElements.EconomicActivityDescription}`).attr("readonly", booleanState);
        $(`${formElements.Email}`).attr("readonly", booleanState);
        $(`${formElements.Phone}`).attr("readonly", booleanState);
        $(`${formElements.Notes}`).attr("readonly", booleanState);
        $(`${formElements.Address}`).attr("readonly", booleanState);
        $(`${formElements.Relationship}`).attr("readonly", booleanState);
        
        if ($(`${formElements.NationalityId}`).val()) {
            $(`${formElements.NationalityId}`).attr("readonly", booleanState).trigger('change');
        }

        if ($(`${formElements.BirthDate}`).val()) {
            $.dateTimeSelectorDisabled(booleanState, formElements.BirthDate);
        }
    }

    function init() {
        $(`${formElements.IsEditingBeneficiaryInfoId}`).iCheck({
            checkboxClass: 'icheckbox_square-green',
            radioClass: 'iradio_square-green'
        });
        $(`${formElements.IsEditingBeneficiaryInfoId}`).iCheck('disable');


        $(`${formElements.IsEditingBeneficiaryInfoId}`).on('ifChecked', function (event) {
            setInputsState(false);
        });
        $(`${formElements.IsEditingBeneficiaryInfoId}`).on('ifUnchecked', function (event) {
            setInputsState(true);
        });

        $(`${formElements.EconomicActivityCompanyId}`).select2({
            placeholder: "seleccione una opcion",
            allowClear: true
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
                                    return { id: obj.Id, text: `${obj.Code} - ${obj.Description}` };
                                })
                        };
                    }
                }
            });
        });

        $(`${formElements.NationalityId}`).each(function () {
            var $this = $(this);

            var endpointUrl = $this.data('ajaxurl');
            $this.select2({
                placeholder: "Escriba una Nacionalidad",
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
                                    return { id: obj.Id, text: `${obj.Code} - ${obj.Description}` };
                                })
                        };
                    }
                }
            });
        });

    }

    // DO NOT TOUCH, ASK FIRST
    function FormElements(mappingObject) {
        return {
            IsEditingBeneficiaryInfoId: mappingObject.IsEditingBeneficiaryInfoId,
            EntityId: mappingObject.EntityId,
            EconomicActivityDescription: mappingObject.EconomicActivityDescription,
            EconomicActivityId: mappingObject.EconomicActivityId,
            Email: mappingObject.Email,
            Phone: mappingObject.Phone,
            Notes: mappingObject.Notes,
            Address: mappingObject.Address,
            EditInfoContainer: mappingObject.EditInfoContainer,
            Relationship: mappingObject.Relationship,
            ClearFormButtonId : mappingObject.ClearFormButtonId,
            EconomicActivityCompanyId: mappingObject.EconomicActivityCompanyId,
            PaymentReason: mappingObject.PaymentReason,
            SourceOfFunds: mappingObject.SourceOfFunds,
            HolderAddress: mappingObject.Address,
            BirthDate: mappingObject.BirthDate,
            NationalityId: mappingObject.NationalityId
        }
    }

    // DO NOT TOUCH, ASK FIRST
    function FormInfo(mappingObject) {
        return {
            IdentificationTypeId: mappingObject.IdentificationTypeId,
            FirstName: mappingObject.FirstName,
            LastName: mappingObject.LastName,
            Identification: mappingObject.Identification,
            IdentificationCountryId: mappingObject.IdentificationCountryId,
            EconomicActivityId: mappingObject.EconomicActivityId,
            EconomicActivityDescription: mappingObject.EconomicActivityDescription,
            Email: mappingObject.Email,
            Phone: mappingObject.Phone,
            Notes: mappingObject.Notes,
            EntityId: mappingObject.EntityId,
            Relationship: mappingObject.Relationship,
            EconomicActivityCompanyId: mappingObject.EconomicalActivityCompanyId,
            PaymentReason: mappingObject.PaymentReason,
            SourceOfFunds: mappingObject.SourceOfFunds,
            Address: mappingObject.Address,
            BirthDate: mappingObject.BirthDateToView,
            NationalityId: mappingObject.NationalityId,
        }
    }
};

var WizardCommondForm = function (uniqueIdPrefix, formElemntsMapping) {

    var uniquePrefix = uniqueIdPrefix;
    var formElements = new FormElements(formElemntsMapping);

    init();

    this.fillInfoStep = function (mappedObject) {
        var formInfo = new FormInfo(mappedObject);

        $(`#${uniquePrefix}-cfs-widget-IdentificationTypeId`).val(formInfo.IdentificationTypeId).attr("readonly", true).trigger('change');
        $(`#${uniquePrefix}-cfs-widget-FirstName`).val(formInfo.FirstName).attr("readonly", true);
        $(`#${uniquePrefix}-cfs-widget-LastName`).val(formInfo.LastName).attr("readonly", true);
        $(`#${uniquePrefix}-cfs-widget-FullName`).val(`${formInfo.FirstName} ${formInfo.LastName}`);
        $(`#${uniquePrefix}-cfs-widget-Identification`).val(formInfo.Identification).attr("readonly", true);
        $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).val(formInfo.IdentificationCountryId).attr("readonly", true);
        $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).trigger('change');

        $(`${formElements.EntityId}`).val(formInfo.EntityId);
        $(`${formElements.CustomerCheckHolderId}`).val(formInfo.CustomerCheckHolderId);
        $(`${formElements.EconomicActivityId}`).val(formInfo.EconomicActivityId).attr("readonly", true).trigger('change');

        $(`${formElements.EconomicActivityDescription}`).val(formInfo.EconomicActivityDescription).attr("readonly", true);
        $(`${formElements.Relationship}`).val(formInfo.Relationship).attr("readonly", true);
        $(`${formElements.Email}`).val(formInfo.Email).attr("readonly", true);
        $(`${formElements.Phone}`).val(formInfo.Phone).attr("readonly", true);
        $(`${formElements.Notes}`).text(formInfo.Notes).attr("readonly", true);
        $(`${formElements.Address}`).val(formInfo.Address).attr("readonly", true);
        var select2DataUrl = `/Customer/SearchEconomicalActivityGubermentById?id=${formInfo.EconomicActivityId}`;
        $.get(select2DataUrl,
            function (data) {
                if (data) {
                    var newOption = new Option(data.text, data.id, false, true);
                    $(`${formElements.EconomicActivityId}`).append(newOption).attr("readonly", true).trigger('change');
                }
            });

        $(`${formElements.IsEditingBeneficiaryInfoId}`).iCheck('enable');
        $(`${formElements.EditInfoContainer}`).show('fast');
    }

    this.cleanInfoStep = function () {
        cleanCustomerWidgetInfo();
        cleanFormElementsInfo();
        this.setInputsState(false);
    }

    this.setInputsState = function (booleanState) {
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
            Notes: $(`${formElements.Notes}`).val(),
            EntityId: $(`${formElements.EntityId}`).val(),
            Relationship: $(`${formElements.Relationship}`).val(),
            CustomerCheckHolderId: $(`${formElements.CustomerCheckHolderId}`).val()
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

        $(`${formElements.EconomicActivityDescription}`).val("");
        $(`${formElements.CustomerCheckHolderId}`).val("");
        $(`${formElements.Email}`).val("");
        $(`${formElements.Phone}`).val("");
        $(`${formElements.Address}`).val("");
        $(`${formElements.Relationship}`).val("");
        $(`${formElements.IsEditingBeneficiaryInfoId}`).iCheck('disabled');
        $(`${formElements.Notes}`).text("");
        $(`${formElements.EditInfoContainer}`).hide('fast');
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
        $(`${formElements.EconomicActivityDescription}`).attr("readonly", booleanState);
        $(`${formElements.Email}`).attr("readonly", booleanState);
        $(`${formElements.Phone}`).attr("readonly", booleanState);
        $(`${formElements.Notes}`).attr("readonly", booleanState);
        $(`${formElements.Address}`).attr("readonly", booleanState);
        $(`${formElements.Relationship}`).attr("readonly", booleanState);
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
            CustomerCheckHolderId: mappingObject.CustomerCheckHolderId
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
            CustomerCheckHolderId: mappingObject.CustomerCheckHolderId
        }
    }
};


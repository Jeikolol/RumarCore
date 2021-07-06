var WizardDatatableSelector = function (uniqueIdPrefix, formElemntsMapping) {

    var uniquePrefix = uniqueIdPrefix;
    var formElements = new FormElements(formElemntsMapping);

    var transferenceformElements, transferenceInformationData;
    init();
    this.fillBeneficiaryInfoStep = function (mappedObject) {
        var beneficiary = new BeneficiaryInfo(mappedObject);
        $(`#${uniquePrefix}-cfs-widget-search-by-code-command`).attr("disabled", true);
        $(`#${uniquePrefix}-cfs-widget-search-by-identification-command`).attr("disabled", true);
        $(`#${uniquePrefix}-cfs-widget-CustomerCode`).attr("readonly", true);
        $(`#${uniquePrefix}-cfs-widget-IdentificationTypeId`).val(beneficiary.IdentificationTypeId).attr("readonly", true).trigger('change');
        $(`#${uniquePrefix}-cfs-widget-Identification`).val(beneficiary.Identification).attr("readonly", true);
        $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).val(beneficiary.IdentificationCountryId).attr("readonly", true);
        $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).trigger('change');

        $(`#${uniquePrefix}-cfs-widget-FirstName`).val(beneficiary.FirstName).attr("readonly", true);

        if (beneficiary.IdentificationCountryId == 1 && beneficiary.IdentificationTypeId == 1) {
            $(`#${uniquePrefix}-cfs-widget-LastName`).val("").attr("readonly", true);
        }
        else {
            $(`#${uniquePrefix}-cfs-widget-LastName`).val(beneficiary.LastName).attr("readonly", true);
        }

        $(`#${uniquePrefix}-cfs-widget-FullName`).val(`${beneficiary.FirstName} ${beneficiary.LastName}`);

        $(`${formElements.Email}`).val(beneficiary.Email).attr("readonly", true);
        $(`${formElements.Phone}`).val(beneficiary.Phone).attr("readonly", true);
        $(`${formElements.Notes}`).text(beneficiary.Notes).attr("readonly", true);
        $(`${formElements.Address}`).val(beneficiary.Address).attr("readonly", true);
        $(`${formElements.Relationship}`).val(beneficiary.Relationship).attr("readonly", true);

        $(`${formElements.City}`).val(beneficiary.City).attr("readonly", true);
        $(`${formElements.PostalCode}`).val(beneficiary.PostalCode).attr("readonly", true);

        $(`${formElements.EntityId}`).val(beneficiary.EntityId);
        $(`${formElements.EconomicActivityId}`).val(beneficiary.EconomicActivityId).attr("readonly", true).trigger('change');
        $(`${formElements.EconomicActivityCompanyId}`).val(beneficiary.EconomicActivityCompanyId).attr("readonly", true).trigger('change');
        $(`${formElements.BeneficiaryCountryId}`).val(beneficiary.BeneficiaryCountryId).attr("readonly", true).trigger('change');

        var select2DataUrl = `/Customer/SearchEconomicalActivityGubermentById?id=${beneficiary.EconomicActivityId}`;
        $.get(select2DataUrl,
            function (data) {
                if (data) {
                    var newOption = new Option(data.text, data.id, false, true);
                    $(`${formElements.EconomicActivityId}`).append(newOption).attr("readonly", true).trigger('change');
                }
            });
        $(`${formElements.EconomicActivityDescription}`).val(beneficiary.EconomicActivityDescription).attr("readonly", true);
        $(`${formElements.IsEditingBeneficiaryInfoId}`).iCheck('enable');
        $(`${formElements.EditBeneficiaryInfoContainerId}`).show('fast');

        $(`${formElements.ClearFormButtonId}`).on("click", function () {
                cleanInfoStep();
            });

    }

    function  cleanInfoStep () {
        cleanCustomerWidgetInfo();
        cleanFormElementsInfo();
        clearTransferenceInfoStep();
        $(`${formElements.IsEditingBeneficiaryInfoId}`).iCheck('uncheck');
        disabledBeneficiaryInfoInputs(false);
        changeReadOnlyStatusTransfenrenceForm(false);
    }

    function clearTransferenceInfoStep() {
        $(`${transferenceformElements.BankCity}`).val('');
        $(`${transferenceformElements.BankName}`).val('');
        $(`${transferenceformElements.AccountNumber}`).val('');
        $(`${transferenceformElements.RoutingNumber}`).val('');
        $(`${transferenceformElements.SwiftCode}`).val('');
        $(`${transferenceformElements.OriginCountryId}`).val('').trigger('change');
    }

    this.fillTransferenceInfoStep = function (formElements, dataInformation) {
        transferenceformElements = new TransfernceFormElements(formElements);
        transferenceInformationData = new TransferenceInformationData(dataInformation);

        $(`${transferenceformElements.BankCity}`).val(transferenceInformationData.BankCity);
        $(`${transferenceformElements.BankName}`).val(transferenceInformationData.BankName);
        $(`${transferenceformElements.AccountNumber}`).val(transferenceInformationData.AccountNumber);
        $(`${transferenceformElements.RoutingNumber}`).val(transferenceInformationData.RoutingNumber);
        $(`${transferenceformElements.SwiftCode}`).val(transferenceInformationData.SwiftCode);

        var newOption = new Option(`${dataInformation.SibWorldCityDescription}`, dataInformation.SibWorldCityId, false, false);

        $(`${transferenceformElements.SibWorldCityId}`).append(newOption);
        $(`${transferenceformElements.SibWorldCityId}`).val(dataInformation.SibWorldCityId).trigger('change');

        var select2GetBankCountryNameUrl = `/CountryBank/GetCountryById?id=${transferenceInformationData.OriginCountryId}`;

        $.get(select2GetBankCountryNameUrl, function (data) {
            if (data) {
                var newOption = new Option(data.text, data.id, false, true);
                $(`${transferenceformElements.OriginCountryId}`).append(newOption).trigger('change');
            }
        });

        $(`${formElements.BankAccountNumber}`).val(dataInformation.AccountNumber);
        $(`${formElements.BankOriginCountryId}`).val(dataInformation.TransferenceOriginCountryId).trigger("change");

        var bankUrl = `/CountryBank/GetBanksForCountry?countryId=${dataInformation.TransferenceOriginCountryId}&q=${dataInformation.BankRoutingNumber}`;

        $.get(bankUrl, function (data) {
            if (data) {
                var newOption = new Option(data[0].RoutingNumberAndName, data[0].Id, false, true);
                $(`${formElements.BankId}`).append(newOption).trigger('change');
            }
        });

        changeReadOnlyStatusTransfenrenceForm(true);
    }

    function changeReadOnlyStatusTransfenrenceForm(booleanState) {
        $(`${transferenceformElements.BankCity}`).val(transferenceInformationData.BankCity);

        $(`${transferenceformElements.BankCity}`).attr("readonly", booleanState);
        $(`${transferenceformElements.BankName}`).attr("readonly", booleanState);
        $(`${transferenceformElements.AccountNumber}`).attr("readonly", booleanState);
        $(`${transferenceformElements.RoutingNumber}`).attr("readonly", booleanState);
        $(`${transferenceformElements.SwiftCode}`).attr("readonly", booleanState);
        $(`${transferenceformElements.OriginCountryId}`).attr("readonly", booleanState);


        $(`${transferenceformElements.BankAccountNumber}`).attr("readonly", booleanState);
        $(`${transferenceformElements.BankOriginCountryId}`).attr("readonly", booleanState);
        $(`${transferenceformElements.BankId}`).attr("readonly", booleanState); 
        $(`${transferenceformElements.SibWorldCityId}`).attr("readonly", booleanState);
    }

    function cleanCustomerWidgetInfo() {
        $(`#${uniquePrefix}-cfs-widget-search-by-code-command`).attr("disabled", false);
        $(`#${uniquePrefix}-cfs-widget-search-by-identification-command`).attr("disabled", false);
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
        $(`${formElements.BeneficiaryCountryId}`).val("").trigger('change');

        $(`${formElements.EconomicActivityDescription}`).val("");
        $(`${formElements.Email}`).val("");
        $(`${formElements.Phone}`).val("");
        $(`${formElements.Address}`).val("");
        $(`${formElements.Relationship}`).val("");
        $(`${formElements.Notes}`).text("");
        $(`${formElements.City}`).val("");
        $(`${formElements.PostalCode}`).val("");

        $(`${formElements.EditBeneficiaryInfoContainerId}`).hide('fast');
        $(`${formElements.IsEditingBeneficiaryInfoId}`).iCheck('disable');

        $(`${formElements.ClearFormButtonId}`).off("click");


    }

    function disableCustomerWidgetInputs(booleanState) {
        $(`#${uniquePrefix}-cfs-widget-search-by-code-command`).attr("disabled", booleanState);
        $(`#${uniquePrefix}-cfs-widget-search-by-identification-command`).attr("disabled", booleanState);
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
        $(`${formElements.City}`).attr("readonly", booleanState);
        $(`${formElements.PostalCode}`).attr("readonly", booleanState);

        $(`${formElements.EconomicActivityCompanyId}`).attr("readonly", booleanState).trigger('change');
        $(`${formElements.BeneficiaryCountryId}`).attr("readonly", booleanState).trigger('change');

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

        $(`${formElements.IsEditingBeneficiaryInfoId}`).on('ifChecked', function (event) {
            disableFormElementsInputs(false);
            changeReadOnlyStatusTransfenrenceForm(false);
        });

        $(`${formElements.IsEditingBeneficiaryInfoId}`).on('ifUnchecked', function (event) {
            disableFormElementsInputs(true);
            changeReadOnlyStatusTransfenrenceForm(true);
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
                                    return { id: obj.Id, text: obj.CodeAndDescription };
                                })
                        };
                    }
                }
            });
        });

    }

    function TransfernceFormElements(mappingObject) {
        return {
            OriginCountryId : mappingObject.OriginCountryId,
            AccountNumber: mappingObject.AccountNumber,
            BankName : mappingObject.BankName,
            SwiftCode : mappingObject.SwiftCode,
            BankCity: mappingObject.BankCity,
            RoutingNumber: mappingObject.RoutingNumber,
            BankAccountNumber: mappingObject.BankAccountNumber,
            BankOriginCountryId: mappingObject.BankOriginCountryId,
            BankId: mappingObject.BankId,
            SibWorldCityId: mappingObject.SibWorldCityId
        }
    }

    function TransferenceInformationData(mappingObject) {
        return {
            OriginCountryId : mappingObject.TransferenceOriginCountryId,
            AccountNumber: mappingObject.AccountNumber,
            BankName : mappingObject.BankName,
            SwiftCode : mappingObject.BankSwiftCode,
            BankCity: mappingObject.BankCity,
            RoutingNumber: mappingObject.BankRoutingNumber,
            BankAccountNumber: mappingObject.BankAccountNumber,
            BankOriginCountryId: mappingObject.BankOriginCountryId,
            BankId: mappingObject.BankId,
            SibWorldCityId: mappingObject.SibWorldCityId
        }
    }

    // DO NOT TOUCH, ASK FIRST
    function FormElements(mappingObject) {
        return {

            EntityId: mappingObject.EntityId,
            EconomicActivityDescription: mappingObject.EconomicActivityDescription,
            EconomicActivityId: mappingObject.EconomicActivityId,
            Email: mappingObject.Email,
            Phone: mappingObject.Phone,
            Notes: mappingObject.Notes,
            Address: mappingObject.Address,
            Relationship: mappingObject.Relationship,
            BeneficiaryCountryId: mappingObject.BeneficiaryCountryId,
            EconomicActivityCompanyId: mappingObject.EconomicActivityCompanyId,
            EditBeneficiaryInfoContainerId: mappingObject.EditBeneficiaryInfoContainerId,
            IsEditingBeneficiaryInfoId: mappingObject.IsEditingBeneficiaryInfoId,
            City: mappingObject.City,
            PostalCode: mappingObject.PostalCode,
            ClearFormButtonId : mappingObject.ClearFormButtonId
        }
    }

    // DO NOT TOUCH, ASK FIRST
    function BeneficiaryInfo(mappingObject) {
        return {
            IdentificationTypeId: mappingObject.IdentificationTypeId,
            FirstName: mappingObject.FirstName,
            LastName: mappingObject.LastName,
            Address :mappingObject.Address,
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
            BeneficiaryCountryId: mappingObject.CountryId,
            City: mappingObject.City,
            PostalCode: mappingObject.ZipCode
        }
    }

    function setSenderDataWithCustomer(customerCode) {
        var url = `/CustomerFinderWidget/SearchCustomerByCode?code=${customerCode}`;

        $.get(url, function (dataCustomerInfo) {
            if (dataCustomerInfo.hasOwnProperty("Identification")) {
                $(`#${uniquePrefix}-cfs-widget-SelectedCustomerId`).val(dataCustomerInfo.Id).trigger("change");;
                $(`#${uniquePrefix}-cfs-widget-IdentificationTypeId`).val(dataCustomerInfo.IdentificationTypeId).attr("readonly", true).trigger('change');
                $(`#${uniquePrefix}-cfs-widget-CustomerCode`).val(dataCustomerInfo.Code).attr("readonly", true);
                $(`#${uniquePrefix}-cfs-widget-Identification`).val(dataCustomerInfo.Identification).attr("readonly", true);
                $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).val(dataCustomerInfo.IdentificationCountryId).attr("readonly", true);
                $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).trigger('change');

                $(`#${uniquePrefix}-cfs-widget-FirstName`).val(dataCustomerInfo.FirstName).attr("readonly", true);

                if (dataCustomerInfo.IdentificationCountryId == 1 && dataCustomerInfo) {
                    $(`#${uniquePrefix}-cfs-widget-LastName`).val("").attr("readonly", true);
                }
                else {
                    $(`#${uniquePrefix}-cfs-widget-LastName`).val(dataCustomerInfo.LastName).attr("readonly", true);
                }

                $(`#${uniquePrefix}-cfs-widget-FullName`).val(`${dataCustomerInfo.FirstName} ${dataCustomerInfo.LastName}`);

                $(`#${uniquePrefix}-person-photo`).attr("src", normalizeImageUrl(dataCustomerInfo.PhotoUrl));
                $(`${formElements.EntityId}`).val(dataCustomerInfo.EntityId);
                $(`${formElements.EconomicActivityId}`).val(dataCustomerInfo.EconomicActivityId).attr("readonly", true).trigger('change');
                $(`${formElements.EconomicActivityCompanyId}`).val(dataCustomerInfo.EconomicActivityCompanyId).attr("readonly", true).trigger('change');
                $(`${formElements.Email}`).val(dataCustomerInfo.CustomerEmail).attr("readonly", true);
                $(`${formElements.Phone}`).val(dataCustomerInfo.Phones).attr("readonly", true);
                $(`${formElements.Notes}`).text(dataCustomerInfo.Notes).attr("readonly", true);
                $(`${formElements.Address}`).val(dataCustomerInfo.Address.AddressLine1).attr("readonly", true);
                $(`${formElements.City}`).val(dataCustomerInfo.Address.City).attr("readonly", true);
                $(`${formElements.PostalCode}`).val(dataCustomerInfo.Address.ZipCode).attr("readonly", true);
                $(`${formElements.Relationship}`).val("ES EL MISMO CLIENTE").attr("readonly", true);
                $(`${formElements.EconomicActivityDescription}`).attr("readonly", true);
            }

            GetCustomerEconomicalActivityCompanyByCustomerId(dataCustomerInfo.Id, formElements.EconomicActivityCompanyId);
        });
    }

    $("#copy-customer-data").on("click", function () {
        var customerCode = $("input[name='CustomerCode']").val();
        setSenderDataWithCustomer(customerCode);

        $("#clean-sender-data").removeClass("hidden");

        $("#clean-sender-data").on("click", function () {
            cleanCustomerWidgetInfo();
            cleanFormElementsInfo();
            disabledBeneficiaryInfoInputs(false);
        });
    });

    $(`#${uniquePrefix}-cfs-widget-SelectedCustomerId`).on("change", function () {
        var beneficiaryCustomerId = $(this).val();
        var transactionCustomerId = $("input[name ='CustomerId']").val();

        if (beneficiaryCustomerId == transactionCustomerId) {
            $(`${formElements.Relationship}`).val("ES EL MISMO CLIENTE");
        }

        GetCustomerEconomicalActivityCompanyByCustomerId(beneficiaryCustomerId, `${formElements.EconomicActivityCompanyId}`);
    });
};


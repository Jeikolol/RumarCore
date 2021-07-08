var WizardDatatableSelector = function (uniqueIdPrefix, formElemntsMapping) {

    var uniquePrefix = uniqueIdPrefix;
    var formElements = new FormElements(formElemntsMapping);

    var bankFormElements = null;
    var bankInfo = null;
    var selft = this;
    init();
    this.fillBeneficiaryInfoStep = function (mappedObject) {
        var beneficiary = new BeneficiaryInfo(mappedObject);

        $(`#${uniquePrefix}-cfs-widget-search-by-code-command`).attr("disabled", true);
        $(`#${uniquePrefix}-cfs-widget-search-by-identification-command`).attr("disabled", true);
        $(`#${uniquePrefix}-cfs-widget-CustomerCode`).attr("readonly", true);
        $(`#${uniquePrefix}-cfs-widget-IdentificationTypeId`).val(beneficiary.IdentificationTypeId).attr("readonly", true).trigger('change');
        $(`#${uniquePrefix}-cfs-widget-FirstName`).val(beneficiary.FirstName).attr("readonly", true);
        $(`#${uniquePrefix}-cfs-widget-LastName`).val(beneficiary.LastName).attr("readonly", true);
        $(`#${uniquePrefix}-cfs-widget-FullName`).val(`${beneficiary.FirstName} ${beneficiary.LastName}`);
        $(`#${uniquePrefix}-cfs-widget-Identification`).val(beneficiary.Identification).attr("readonly", true);
        $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).val(beneficiary.IdentificationCountryId).attr("readonly", true);
        $(`#${uniquePrefix}-cfs-widget-IdentificationCountryId`).trigger('change');

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
        
        $.get(select2DataUrl, function (data) {
            if (data) {
                var newOption = new Option(data.text, data.id, false, true);

                $(`${formElements.EconomicActivityId}`).append(newOption).attr("readonly", true).trigger('change');
            }
        });

        $(`${formElements.EconomicActivityDescription}`).val(beneficiary.EconomicActivityDescription).attr("readonly", true);
        $(`${formElements.IsEditingBeneficiaryInfoId}`).iCheck('enable');
        $(`${formElements.EditBeneficiaryInfoContainerId}`).show('fast');

        $(`${formElements.ClearFormButtonId}`).on("click", function () {
            cleanCustomerWidgetInfo();
            cleanFormElementsInfo();
            clearBankStep();

            disabledBeneficiaryInfoInputs(false);
            changeReadOnlyStatusBankForm(false);
            changeStatusTransferenceInformation(false);
        });
    }

    this.cleanBeneficiaryStep = function () {
        cleanCustomerWidgetInfo();
        cleanFormElementsInfo();
        clearBankStep();

        disabledBeneficiaryInfoInputs(false);
        changeReadOnlyStatusBankForm(false);
        changeStatusTransferenceInformation(false);
    }

    this.fillBankInfoStep = function (formElements, dataInformation) {
        bankFormElements = new BankFormElements(formElements);
        bankInfo = new BankInformation(dataInformation);

        if (bankInfo.Ach) {
            //$(`${bankFormElements.Ach.ActionButton}`).trigger("change");
            $(`${bankFormElements.Ach.AccountNumber}`).val(bankInfo.Ach.AccountNumber);
            $(`${bankFormElements.Ach.BankAddress}`).val(bankInfo.Ach.BankAddress);

            fillBankSelector(bankFormElements.Ach.BankSelectorUniqueIdPrefix, bankInfo.Ach.BankSelectionData.BankId, bankInfo.Ach.BankSelectionData.BankCountryId);

            if (bankInfo.Intermediary) {    
                $(`${bankFormElements.Ach.HasIntermediary}`).iCheck("check");
                $(`${bankFormElements.Ach.Intermediary.Type}`).val(bankInfo.Intermediary.Type).trigger("change");

                if (bankInfo.Intermediary.Type === 2) {
                    $(`${bankFormElements.Ach.Intermediary.SwiftIntermediary.BankAddress}`).val(bankInfo.Intermediary.SwiftIntermediary.BankAddress);
                    var intermediarySwiftIdPrefix = bankFormElements.Ach.Intermediary.SwiftIntermediary.BankSwiftSelectorUniqueIdPrefix;
                    var intermediaryBankSwiftIdValue = bankInfo.Intermediary.SwiftIntermediary.BankSwiftSelectionData.BankSwiftId;
                    fillBankSwiftSelector(intermediarySwiftIdPrefix,intermediaryBankSwiftIdValue);
                }
                if (bankInfo.Intermediary.Type === 1) {
                    $(`${bankFormElements.Ach.Intermediary.AchIntermediary.BankAddress}`).val(bankInfo.Intermediary.AchIntermediary.BankAddress);
                    var bankIdPrefix = bankFormElements.Ach.Intermediary.AchIntermediary.BankSelectionUniqueIdPrefix;
                    var bankIdValue = bankInfo.Intermediary.AchIntermediary.BankSelectionData.BankId;
                    var bankCountryIdValue = bankInfo.Intermediary.AchIntermediary.BankSelectionData.BankCountryId;
                    fillBankSelector(bankIdPrefix,bankIdValue,bankCountryIdValue);
                }
            }
        }

        //if (bankInfo.Swift) {
        //    $(`${bankFormElements.Swift.ActionButton}`).trigger("change");
        //    $(`${bankFormElements.Swift.AccountNumber}`).val(bankInfo.Swift.AccountNumber);
        //    $(`${bankFormElements.Swift.BankAddress}`).val(bankInfo.Swift.BankAddress);
        //    var swiftIdPrefix = bankFormElements.Swift.BankSwiftSelectorUniqueIdPrefix;
        //    var bankSwiftIdValue = bankInfo.Swift.BankSwiftSelectionData.BankSwiftId;
        //    fillBankSwiftSelector(swiftIdPrefix,bankSwiftIdValue);
        //}
        changeReadOnlyStatusBankForm(true);
        changeStatusTransferenceInformation(true);
    };

    this.setBankInfo = function (data) {
        if (data.Bank) {
            $("select[name='TransferenceInformation.BankCountryId']").val(data.Bank.CountryId).trigger("change");
            $("input[name='TransferenceInformation.BankRoutingNumber']").val(data.Bank.RoutingNumber);
            $("input[name='TransferenceInformation.BankName']").val(data.Bank.Name);
            $("input[name='TransferenceInformation.AchAccountNumber']").val(data.AccountNumber);
            $("input[name='TransferenceInformation.BankAddress']").val(data.Bank.Address);
            $("input[name='TransferenceInformation.BankId']").val(data.Bank.Id);

            if (data.SibWorldCity) {
                var newOption = new Option(`${data.SibWorldCity.Code} - ${data.SibWorldCity.Description}`, data.SibWorldCityId, false, false);
                $("select[name='TransferenceInformation.SibWorldCityId']").val(data.SibWorldCityId);
                $("select[name='TransferenceInformation.SibWorldCityId']").append(newOption).trigger('change');
            }
        }

        changeStatusTransferenceInformation(true);
    }

    this.setBankInternationcalInfo = function (data) {
        //$("select[name='TransferenceInputInformation.BankSwiftCountryId']").val(data.BankSwift.CountryId).trigger("change");

        if (data.BankSwift) {
            $("input[name='TransferenceInformation.SwiftNumber']").val(data.BankSwift.SwiftCode);
            $("input[name='TransferenceInformation.SwiftAccountNumber']").val(data.BankSwift.SwiftCode);
            $("input[name='TransferenceInformation.BankName']").val(`${data.BankSwift.Institution} [${data.BankSwift.CityHeading}]`);
            $("input[name='TransferenceInformation.SwiftAccountNumber']").val(data.BankAddress);
        }

        $("select[name='TransferenceInputInformation.OriginCountryId']").val(data.BankSwift.CountryId).trigger("change");
       
        changeStatusTransferenceInformation(true);
    }

    function clearBankStep () {
        $(`${bankFormElements.Ach.AccountNumber}`).val("");
        $(`${bankFormElements.Ach.BankAddress}`).val("");
        $(`${bankFormElements.Ach.BankSelectorUniqueIdPrefix}-bankId`).val("").trigger("change");
        $(`${bankFormElements.Ach.BankSelectorUniqueIdPrefix}-bank-country-id`).val("").trigger("change");
      
        $(`${bankFormElements.Ach.ActionButton}`).trigger("change");
        $(`${bankFormElements.Ach.HasIntermediary}`).iCheck("uncheck");
       
        $(`${bankFormElements.Ach.Intermediary.Type}`).val("");
        $(`${bankFormElements.Ach.Intermediary.AchIntermediary.BankSelectionUniqueIdPrefix}-bankId`).val("").trigger("change");
        $(`${bankFormElements.Ach.Intermediary.AchIntermediary.BankSelectionUniqueIdPrefix}-bank-country-id`).val("").trigger("change");
        $(`${bankFormElements.Ach.Intermediary.AchIntermediary.BankAddress}`).val("");
        
        $(`${bankFormElements.Ach.Intermediary.SwiftIntermediary.BankSwiftSelectorUniqueIdPrefix}-bankSwiftId`).val("").trigger("change");
        $(`${bankFormElements.Ach.Intermediary.SwiftIntermediary.BankAddress}`).val("");

        $(`${bankFormElements.Swift.AccountNumber}`).val("");
        $(`${bankFormElements.Swift.BankAddress}`).val("");
        $(`${bankFormElements.Swift.BankSwiftSelectorUniqueIdPrefix}-bankSwiftId`).val("").trigger("change");

        $("select[name='TransferenceInformation.BankCountryId']").val("").trigger("change");
        $("input[name='TransferenceInformation.BankRoutingNumber']").val("");
        $("input[name='TransferenceInformation.BankName']").val("");
        $("input[name='TransferenceInformation.AchAccountNumber']").val("");
        $("input[name='TransferenceInformation.BankAddress']").val("");
    };

    function changeReadOnlyStatusBankForm(booleanState) {
        if (bankFormElements && bankFormElements.hasOwnProperty("Ach") && bankFormElements.Ach) {
            $(`${bankFormElements.Ach.AccountNumber}`).attr("readonly", booleanState);
            $(`${bankFormElements.Ach.BankAddress}`).attr("readonly", booleanState);
            $(`${bankFormElements.Ach.BankSelectorUniqueIdPrefix}-bankId`).attr("readonly", booleanState);
            $(`${bankFormElements.Ach.BankSelectorUniqueIdPrefix}-bank-country-id`).attr("readonly", booleanState);

            var checkState = booleanState ? "disable" : "enable";

            $(`${bankFormElements.Ach.HasIntermediary}`).iCheck(checkState);


            $(`${bankFormElements.Ach.Intermediary.Type}`).attr("readonly", booleanState);
            $(`${bankFormElements.Ach.Intermediary.AchIntermediary.BankSelectionUniqueIdPrefix}-bank-country-id`).attr("readonly", booleanState);
            $(`${bankFormElements.Ach.Intermediary.AchIntermediary.BankSelectionUniqueIdPrefix}-bankId`).attr("readonly", booleanState);
            $(`${bankFormElements.Ach.Intermediary.AchIntermediary.BankAddress}`).attr("readonly", booleanState);

            $(`${bankFormElements.Ach.Intermediary.SwiftIntermediary.BankSwiftSelectorUniqueIdPrefix}-bankSwiftId`).attr("readonly", booleanState);
            $(`${bankFormElements.Ach.Intermediary.SwiftIntermediary.BankAddress}`).attr("readonly", booleanState);

            $(`${bankFormElements.Swift.AccountNumber}`).attr("readonly", booleanState);
            $(`${bankFormElements.Swift.BankAddress}`).attr("readonly", booleanState);
            $(`${bankFormElements.Swift.BankSwiftSelectorUniqueIdPrefix}-bankSwiftId`).attr("readonly", booleanState);
            $(`${bankFormElements.Ach.BankSelectorUniqueIdPrefix}-bankId`).attr("readonly", booleanState);

            $(`${bankFormElements.Ach.BankSelectorUniqueIdPrefix}-bank-country-id`).attr("readonly", true);
        }

    }

    function changeStatusTransferenceInformation(isDisabled) {
        $("select[name='TransferenceInformation.BankCountryId']").attr("readonly", isDisabled);

        $("input[name='TransferenceInformation.BankRoutingNumber']").attr("readonly", isDisabled);
        $("input[name='TransferenceInformation.BankName']").attr("readonly", isDisabled);
        $("input[name='TransferenceInformation.AchAccountNumber']").attr("readonly", isDisabled);
        $("input[name='TransferenceInformation.BankAddress']").attr("readonly", isDisabled);

        $("select[name='TransferenceInputInformation.OriginCountryId']").attr("readonly", isDisabled);
        $("input[name='TransferenceInformation.SwiftNumber']").attr("readonly", isDisabled);
        $("input[name='TransferenceInformation.BankName']").attr("readonly", isDisabled);
        $("input[name='TransferenceInformation.AchAccountNumber']").attr("readonly", isDisabled);
        $("input[name='TransferenceInformation.BankAddress']").attr("readonly", isDisabled);

        $("select[name='TransferenceInputInformation.BankSwiftCountryId']").attr("readonly", isDisabled);
        $("select[name='TransferenceInformation.SibWorldCityId']").attr("readonly", isDisabled);
    }

    function fillBankSelector(internalUniqueIdPrefix, bankId, bankCountryId) {
        
        var select2GetBankCountryNameUrl = `/CountryBank/GetCountryById?id=${bankCountryId}`;

        $.get(select2GetBankCountryNameUrl, function (data) {
            if (data) {
                var newOption = new Option(data.text, data.id, false, true);

                $(`${internalUniqueIdPrefix}-bank-country-id`).append(newOption).trigger('change');
            }
        });

        var select2GetBankNameUrl = `/CountryBank/GetBankById?id=${bankId}`;
        
        $.get(select2GetBankNameUrl, function (data) {
            if (data) {
                var newOption = new Option(data.text, data.id, false, true);

                $(`${internalUniqueIdPrefix}-bankId`).append(newOption).trigger('change');
            }
        });
    }

    function fillBankSwiftSelector(internalUniqueIdPrefix, bankSwiftId) {
        var select2GetBankNameUrl = `/Bank/GetBankSwiftById?bankSwiftId=${bankSwiftId}`;
        $.get(select2GetBankNameUrl, function (data) {
            if (data) {
                var newOption = new Option(data.Description, data.Id, false, true);
                $(`${internalUniqueIdPrefix}-bankSwiftId`).append(newOption).attr("readonly", true).trigger('change');
            }
        });
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
            changeReadOnlyStatusBankForm(false);
            changeStatusTransferenceInformation(false);
        });

        $(`${formElements.IsEditingBeneficiaryInfoId}`).on('ifUnchecked', function (event) {
            disableFormElementsInputs(true);
            changeReadOnlyStatusBankForm(true);
            changeStatusTransferenceInformation(true);
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


    function BankFormElements(mappingObject) {
        return {
            Ach: {
                ActionButton: mappingObject.AchActionButton,
                ClickableActionButton : mappingObject.AchClickableButton,
                BankSelectorUniqueIdPrefix: mappingObject.BankSelectorUniqueIdPrefix,
                AccountNumber: mappingObject.AccountNumber,
                BankAddress: mappingObject.BankAddress,
                HasIntermediary: mappingObject.HasIntermediary,
                Intermediary: {
                    Type: mappingObject.IntermediaryType,
                    AchIntermediary: {
                        BankSelectionUniqueIdPrefix: mappingObject.IntermediaryBankSelectionUniqueIdPrefix,
                        BankAddress: mappingObject.IntermediaryBankAddress
                    },
                    SwiftIntermediary: {
                        BankSwiftSelectorUniqueIdPrefix: mappingObject.IntermediaryBankSwiftSelectorUniqueIdPrefix,
                        BankAddress: mappingObject.IntermediaryBankSwiftAddress
                    }
                }
            },
            Swift: {
                ActionButton: mappingObject.SwiftActionButton,
                ClickableActionButton : mappingObject.SwiftClickableButton,
                BankSwiftSelectorUniqueIdPrefix: mappingObject.BankSwiftSelectorUniqueIdPrefix,
                AccountNumber: mappingObject.SwiftAccountNumber,
                BankAddress: mappingObject.SwiftBankAddress
            }
        };
    }

    function BankInformation(mappingObject) {

        var information = {};
        if (mappingObject.AchInformation != null) {
            information.Ach = {
                AccountNumber: mappingObject.AchInformation.AccountNumber,
                BankAddress: mappingObject.AchInformation.BankAddress,
                BankSelectionData: {
                    BankId: mappingObject.AchInformation.BankSelectionData.BankId,
                    BankCountryId: mappingObject.AchInformation.BankSelectionData.BankCountryId
                }
            }

            if (mappingObject.AchInformation.AchIntermediator !== null) {
                information.Intermediary = {
                    Type: mappingObject.AchInformation.IntermediatorType,
                    AchIntermediary: {
                        BankAddress: mappingObject.AchInformation.AchIntermediator.BankAddress,
                        BankSelectionData: {
                            BankId: mappingObject.AchInformation.AchIntermediator.BankSelectionData.BankId,
                            BankCountryId: mappingObject.AchInformation.AchIntermediator.BankSelectionData.BankCountryId
                        }
                    }
                }
            }
            if (mappingObject.AchInformation.SwiftIntermediator !== null) {
                information.Intermediary = {
                    Type: mappingObject.AchInformation.IntermediatorType,
                    SwiftIntermediary: {
                        BankAddress: mappingObject.AchInformation.SwiftIntermediator.BankAddress,
                        BankSwiftSelectionData: {
                            BankSwiftId: mappingObject.AchInformation.SwiftIntermediator.BankSwiftSelectionData.BankSwiftId
                        }
                    }
                }
            }
        }
        if (mappingObject.SwiftInformation !== null) {
            information.Swift = {
                AccountNumber: mappingObject.SwiftInformation.AccountNumber,
                BankAddress: mappingObject.SwiftInformation.BankAddress,
                BankSwiftSelectionData: {
                    BankSwiftId: mappingObject.SwiftInformation.BankSwiftSelectionData.BankSwiftId
                }
            }
        }
        return information;
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
            IdentificationCountryId: mappingObject.CountryId,
            EconomicActivityId: mappingObject.EconomicalActivityId,
            EconomicActivityDescription: mappingObject.EconomicalActivityDescription,
            Email: mappingObject.Email,
            Phone: mappingObject.Phone,
            Notes: mappingObject.Notes,
            EntityId: mappingObject.EntityId,
            Relationship: mappingObject.Relationship,
            EconomicActivityCompanyId: mappingObject.EconomicalActivityCompanyId,
            BeneficiaryCountryId: mappingObject.CountryId,
            City: mappingObject.City,
            PostalCode: mappingObject.PostalCode
        }
    }

    function setBeneficiaryDataWithCustomer(customerCode) {
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

                if (dataCustomerInfo.IdentificationCountryId == 1 && dataCustomerInfo.IdentificationTypeId) {
                    $(`#${uniquePrefix}-cfs-widget-LastName`).val("").attr("readonly", true);
                }
                else {
                    $(`#${uniquePrefix}-cfs-widget-LastName`).val(dataCustomerInfo.LastName).attr("readonly", true);
                }
                
                $(`#${uniquePrefix}-cfs-widget-FullName`).val(`${dataCustomerInfo.FirstName} ${dataCustomerInfo.LastName}`);

                var personPhoto = dataCustomerInfo.PhotoUrl === null
                    ? "/Content/img/person-placeholder-small.png"
                    : dataCustomerInfo.PhotoUrl; 

                $(`#${uniquePrefix}-person-photo`).attr("src", personPhoto);
                $(`${formElements.EntityId}`).val(dataCustomerInfo.EntityId);
                $(`${formElements.EconomicActivityId}`).val(dataCustomerInfo.EconomicActivityId).attr("readonly", true).trigger('change');
                $(`${formElements.EconomicActivityCompanyId}`).val(dataCustomerInfo.EconomicActivityCompanyId).attr("readonly", true).trigger('change');
                $(`${formElements.Email}`).val(dataCustomerInfo.CustomerEmail).attr("readonly", true);
                $(`${formElements.Phone}`).val(dataCustomerInfo.Phones).attr("readonly", true);
                $(`${formElements.Notes}`).text(dataCustomerInfo.Notes).attr("readonly", true);
                $(`${formElements.Address}`).val(dataCustomerInfo.Address.AddressLine1).attr("readonly", true);
                $(`${formElements.BeneficiaryCountryId}`).val(dataCustomerInfo.Address.CountryId).attr("readonly", true).trigger('change');
                $(`${formElements.Relationship}`).val("ES EL MISMO CLIENTE").attr("readonly", true);
                $(`${formElements.EconomicActivityDescription}`).attr("readonly", true);

                GetCustomerEconomicalActivityCompanyByCustomerId(dataCustomerInfo.Id, formElements.EconomicActivityCompanyId);
            }
        });
    }

    $(`#${uniquePrefix}-cfs-widget-SelectedCustomerId`).on("change", function () {
        var beneficiaryCustomerId = $(this).val();
        var transactionCustomerId = $("input[name ='CustomerId']").val();

        if (beneficiaryCustomerId == transactionCustomerId) {
            $(`${formElements.Relationship}`).val("ES EL MISMO CLIENTE");
        }

        GetCustomerEconomicalActivityCompanyByCustomerId(beneficiaryCustomerId,
            `${formElements.EconomicActivityCompanyId}`);
    });

    $(`#${uniquePrefix}-copy-customer-data`).on("click", function () {
        var customerCode = $("input[name='CustomerCode']").val();

        setBeneficiaryDataWithCustomer(customerCode);

        $(`#${uniquePrefix}-clean-beneficiary-data`).removeClass("hidden");

        $(`#${uniquePrefix}-clean-beneficiary-data`).on("click", function () {
            cleanCustomerWidgetInfo();
            cleanFormElementsInfo();
            disabledBeneficiaryInfoInputs(false);
        });
    });
};


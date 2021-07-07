var CustomerFinderWidgetInit = function (uniqueIdPrefix) {
    var jce = 3; //Enum customerFoundSource.JCE
    var dgii = 4; //Enum customerFoundSource.Dgii
    var customerIndex = 1;

    var refreshSelect2 = function ($input, data) {
        $input.html('').parent().find("span.select2-container").remove();
        $input.select2({
            data: data,
            width: "100%",
            placeholder: "Seleccione una opción"
        });
    }

    var loadCountryLookup = function () {
        var countriesLookup = $(`#${uniqueIdPrefix}-cf-widget-IdentificationCountryId`);

        var cacheName = $.cacheConstants.countryCacheName;

        $.getCacheItem(cacheName, function (data) {
            if (data) {
                var mapped = data.map(function (item) {
                    return { id: item.Id, text: item.Name }
                });

                refreshSelect2(countriesLookup, mapped);
            }
        });

        countriesLookup.select2({
            width: "100%",
            placeholder: "Seleccione un Pais",
            allowClear: true
        });
    };

    var loadIdentificationTypeLookup = function () {
        var identificationTypeLookup = $(`#${uniqueIdPrefix}-cf-widget-IdentificationTypeId`);
        var cacheName = $.cacheConstants.identicationTypesForLocalCustomersCacheName;

        $.getCacheItem(cacheName, function (data) {
            var selectedIdentificationType = 2;

            if (data) {
                var mapped = data.map(function (item) {
                    return { id: item.Id, text: item.Description }
                });

                refreshSelect2(identificationTypeLookup, mapped);

                if ($("#IdentificationTypeId").val())
                    selectedIdentificationType = $("#IdentificationTypeId").val();

                $(`#${uniqueIdPrefix}-cf-widget-IdentificationTypeId`).val(selectedIdentificationType);
                $(`#${uniqueIdPrefix}-cf-widget-IdentificationTypeId`).trigger("change");
            };
        });

        identificationTypeLookup.select2({
            width: "100%",
            placeholder: "Seleccione un Tipo de Identificacion",
            allowClear: true
        });
    };

    function clearWidget() {
        $(`#${uniqueIdPrefix}-cf-widget-FirstName`).val("");
        $(`#${uniqueIdPrefix}-cf-widget-LastName`).val("");
          
        $(`#${uniqueIdPrefix}-cf-widget-Identification`).val("");
        $(`#${uniqueIdPrefix}-cf-widget-Identification`).focus();
        $(`#${uniqueIdPrefix}-person-photo`).attr("src", "/Content/img/person-placeholder-small.png");
        $(`#${uniqueIdPrefix}-cf-widget-IdentificationCountryId`).val(1).trigger("change");
        $(`#${uniqueIdPrefix}-cf-widget-IdentificationTypeId`).val(2).trigger("change");
        $(`#${uniqueIdPrefix}-cf-widget-Identification`).attr("data-CustomerFoundSource", 0);

        $(".personAge").parent().addClass("hidden");

        notifyMessage("");
        changeStateWidgetElements(false);
    };

    function changeStateWidgetElements(isDisabled) {
        $(`#${uniqueIdPrefix}-cf-widget-FirstName`).attr("readonly", isDisabled);
        $(`#${uniqueIdPrefix}-cf-widget-LastName`).attr("readonly", isDisabled);

        $(`#${uniqueIdPrefix}-cf-widget-Identification`).attr("readonly", isDisabled);
        $(`#${uniqueIdPrefix}-cf-widget-IdentificationCountryId`).attr("disabled", isDisabled);
        $(`#${uniqueIdPrefix}-cf-widget-IdentificationTypeId`).attr("disabled", isDisabled);
        $(`#${uniqueIdPrefix}-search-by-identification-command`).attr("disabled", isDisabled);

        notifyMessage("");
    };

    function validateLocalIdentification(indentificationType, identification) {
        var identificationIsValid = true;

        if (indentificationType == 1) {
            if (!$.SDQ.validarRNC(identification)) {
                notifyMessage("RNC Invalido, favor verificar.");
                identificationIsValid = false;
            }
        } else if (indentificationType == 2) {
            if (!$.SDQ.validarCedula(identification)) {
                notifyMessage("Cedula Invalida, favor verificar.");
                identificationIsValid = false;
            }
        }

        $(`#${uniqueIdPrefix}-cf-widget-Identification`).focus();

        return identificationIsValid;
    }

    function notifyMessage(message) {
        $(`#${uniqueIdPrefix}-cf-widget-error-message`).html(message);
    };

    var findCustomerByIdentification = function () {
        //$(`#${uniqueIdPrefix}-cf-widget-FirstName`).val("");
        //$(`#${uniqueIdPrefix}-cf-widget-LastName`).val("");
        
        $("#customerId").val("");    
        $(`#${uniqueIdPrefix}-person-photo`).attr("src", "/Content/img/person-placeholder-small.png");

        var identfication = $(`#${uniqueIdPrefix}-cf-widget-Identification`).val();
        var identificationType = $(`#${uniqueIdPrefix}-cf-widget-IdentificationTypeId`).val();

        if (identfication.length <= 0 || identificationType <= 0) {
            return;
        };

        var url = "/CustomerFinderWidget/SearchPersonByIdentification";
        var searchByIdCommand = $(`#${uniqueIdPrefix}-search-by-identification-command`);

        if (!validateLocalIdentification(identificationType, identfication))
            return null;

        searchByIdCommand.ladda("start");
        var param = {
            IdentificationTypeId: identificationType,
            Identification: identfication
        };

        $.post(url, param, function (data) {
           searchByIdCommand.ladda("stop");
            if (!data) {
                return;
            }

            if (data.hasOwnProperty("InvalidIdentification") && data.InvalidIdentification) {
                notifyMessage("Identificacion Invalida, favor verificar.");
                $(`#${uniqueIdPrefix}-cf-widget-Identification`).val("");
                $(`#${uniqueIdPrefix}-cf-widget-Identification`).focus();
                return;
            }

            if (data.hasOwnProperty("FirstName")) {
                if (data.CustomerId > 0) {
                    var haveValidateCustomerExistence = $(`#${uniqueIdPrefix}-HaveValidateCustomerExistence`).val()
                    if (haveValidateCustomerExistence.toLowerCase() == "true") {
                        var customerLink = "<a target='_blank' href='/Customer/Details/" + data.CustomerId + "'>aqui</a>";
                        var message = "Existe un cliente con esta identificacion. Haga click " + customerLink + " para ver los detalles.";

                        $(`#${uniqueIdPrefix}-cf-widget-Identification`).removeAttr("data-CustomerFoundSource");
                        $("#customerId").val(data.CustomerId);

                        notifyMessage(message);
                    } else {
                        setCustomerData(data);
                    }
                } else {
                    setCustomerData(data);
                };
            } else {
                $.seachOnListRisk();
            };
        });
    };

    $(`#${uniqueIdPrefix}-search-by-identification-command`).ladda().click(function () {
        findCustomerByIdentification();
    });

    $(`#${uniqueIdPrefix}-clear-cf-widget`).click(function () {
        clearWidget();
    });

    $(`#${uniqueIdPrefix}-cf-widget-Identification`).keypress(function (e) {
        if (e.which == 13) {
            findCustomerByIdentification();
        }

        var identificationTypeId = parseInt($(`#${uniqueIdPrefix}-cf-widget-IdentificationTypeId`).val());

        if (isLowerCase(e.key) && identificationTypeId == IDENTIFICATION_TYPE_CONSTANTS.Passport && e.which != 13) {
            e.target.value = e.target.value + e.key.toUpperCase();
        }

        return validateIdentificationByIdentifiationType(e, identificationTypeId);
    });

    $(`#${uniqueIdPrefix}-cf-widget-Identification`).change(function (e) {
        $(`#${uniqueIdPrefix}-search-by-identification-command`).trigger("click");
    });

    $(`#${uniqueIdPrefix}-cf-widget-Identification`).focus();

    $(`#${uniqueIdPrefix}-cf-widget-FirstName`).keypress(function(e) {
        if ($(`#${uniqueIdPrefix}-cf-widget-IdentificationTypeId`).val() != IDENTIFICATION_TYPE_CONSTANTS.Rnc) {
            return validateName(e);
        }

        return true;
    });

    $(`#${uniqueIdPrefix}-cf-widget-LastName`).keypress(function (e) {
        if ($(`#${uniqueIdPrefix}-cf-widget-IdentificationTypeId`).val() != IDENTIFICATION_TYPE_CONSTANTS.Rnc) {
            return validateName(e);
        }

        return true;
    });

    loadCountryLookup();
    loadIdentificationTypeLookup();

    $(`#${uniqueIdPrefix}-cf-widget-IdentificationTypeId`).on("change", function () {
        var identificationTypeId = $(`#${uniqueIdPrefix}-cf-widget-IdentificationTypeId`).val();

        if (identificationTypeId == IDENTIFICATION_TYPE_CONSTANTS.Rnc || identificationTypeId == IDENTIFICATION_TYPE_CONSTANTS.InternationalTaxId) {
            $("input[name='FirstName']").prev().text("Nombre Empresa");
            $("input[name='LastName']").prev().text("Nombre Comercial");
            $(".personAge").prev().text("TPO. Constitución");
        } else {
            $("input[name='FirstName']").prev().text("Nombres");
            $("input[name='LastName']").prev().text("Apellidos");
            $(".personAge").prev().text("EDAD");
        }
    });

    $(`#${uniqueIdPrefix}-cf-widget-IdentificationCountryId`).on("change", function () {
        var identificationTypeLookup = $(`#${uniqueIdPrefix}-cf-widget-IdentificationTypeId`);
        var optionSelected = $(`#${uniqueIdPrefix}-cf-widget-IdentificationTypeId option:selected`).val();

        var currentCountryId = $(`#${uniqueIdPrefix}-cf-widget-IdentificationCountryId option:selected`).val();

        if (currentCountryId === undefined || currentCountryId === 0) {
            return;
        }

        var cacheName = "";

        if ($(`#${uniqueIdPrefix}-cf-widget-IdentificationCountryId option:selected`).val() == 1) {
            cacheName = $.cacheConstants.identicationTypesForLocalCustomersCacheName;
        } else {
            cacheName = $.cacheConstants.identicationTypesForInternacionalCustomersCacheName;
        }

        $.getCacheItem(cacheName, function (data) {
            if (data) {
                var mapped = data.map(function (item) {
                    return { id: item.Id, text: item.Description }
                });

                refreshSelect2(identificationTypeLookup, mapped);

                $(`#${uniqueIdPrefix}-cf-widget-IdentificationTypeId`).val(optionSelected);
                $(`#${uniqueIdPrefix}-cf-widget-IdentificationTypeId`).trigger("change");
            }
        });
    });

    $.changeStateWidgetElementsFromOutsite = function (isActive)
    {
        changeStateWidgetElements(isActive);
    }

    function setCustomerData(data) {
        $(`#${uniqueIdPrefix}-cf-widget-FirstName`).val(data.FirstName);
        $(`#${uniqueIdPrefix}-cf-widget-LastName`).val(data.LastName);
        $(`#${uniqueIdPrefix}-cf-widget-IdentificationCountryId`).val(data.CountryId);
        $(`#${uniqueIdPrefix}-cf-widget-IdentificationCountryId`).trigger("change");

        $.seachOnListRisk();

        if (data.CustomerFoundSource == jce || data.CustomerFoundSource == dgii || data.CustomerFoundSource == customerIndex) {
            $(`#${uniqueIdPrefix}-cf-widget-Identification`)
                .attr("data-CustomerFoundSource", data.CustomerFoundSource);

            if (data.Sex != null && data.Sex != undefined && data.Sex != "") {
                $(`#${uniqueIdPrefix}-cf-widget-Identification`)
                    .attr("data-Customer-Sex", data.Sex);
            } else {
                $(`#${uniqueIdPrefix}-cf-widget-Identification`).removeAttr("data-Customer-Sex");
            }

            if (data.BirthDateToView != null &&
                data.BirthDateToView != undefined &&
                data.BirthDateToView != "") {
                $(`#${uniqueIdPrefix}-cf-widget-Identification`).attr("data-Customer-BirthDate", data.BirthDateToView);
                var personAge = CalculatePersonAge(data.BirthDateToView);

                $(".personAge").text(personAge);
                $(".personAge").parent().removeClass("hidden");

                if (data.CustomerFoundSource == jce) {
                    validatePersonAge(personAge, $("#personMaximumAge").val());
                    changeLabelByMaximumAge(".personAge", personAge >= $("#personMaximumAge").val());
                }

                $(`#${uniqueIdPrefix}-cf-widget-Identification`).attr("data-Customer-BirthPlace", data.BirthPlace);
                $(`#${uniqueIdPrefix}-cf-widget-Identification`).attr("data-Customer-MaritalStatus", data.MaritalStatus);
            } else {
                $(`#${uniqueIdPrefix}-cf-widget-Identification`).removeAttr("data-Customer-BirthDate");
            }
        } else {
            $(`#${uniqueIdPrefix}-cf-widget-Identification`).removeAttr("data-CustomerFoundSource");
            $(`#${uniqueIdPrefix}-cf-widget-Identification`).removeAttr("data-Customer-BirthDate");
            $(`#${uniqueIdPrefix}-cf-widget-Identification`).removeAttr("data-Customer-Sex");
        }  

        if (data.hasOwnProperty("PhotoUrl") && data.PhotoUrl && data.PhotoUrl !== "") {
            $(`#${uniqueIdPrefix}-person-photo`).attr("src", data.PhotoUrl);
        }

        changeStateWidgetElements(true); //Disabled  elements 
    }
}
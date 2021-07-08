var CustomerFinderWidgetSearchInit = function (uniqueIdPrefix, dropdownParentParameter = "") {
    if (dropdownParentParameter == "") {
        var refreshSelect2 = function ($input, data) {
            $input.html('').parent().find("span.select2-container").remove();
            $input.select2({
                data: data,
                width: "100%",
                placeholder: "Seleccione una opcion"
            });
        }
    }
    else {
        var refreshSelect2 = function ($input, data) {
            $input.html('').parent().find("span.select2-container").remove();
            $input.select2({
                data: data,
                width: "100%",
                placeholder: "Seleccione una opcion",
                dropdownParent: $(dropdownParentParameter)
            });
        }
    }

    //Init
    var allowNameEditing = $(`#${uniqueIdPrefix}-AllowNameEditing`).val();

    var loadCountryLookup = function () {
        var countriesLookup = $(`#${uniqueIdPrefix}-cfs-widget-IdentificationCountryId`);
        var selectedCountry = $(`#${uniqueIdPrefix}-cfs-widget-IdentificationCountryId option:selected`).val();
        var url = "/Lookups/GetCountries";

        $.get(url, function (data) {
            if (data) {
                var mapped = data.map(function (item) {
                    return { id: item.Id, text: item.Name }
                });
                refreshSelect2(countriesLookup, mapped);

                if (selectedCountry !== "") {
                    $(`#${uniqueIdPrefix}-cfs-widget-IdentificationCountryId`).val(selectedCountry);
                } else {
                    $(`#${uniqueIdPrefix}-cfs-widget-IdentificationCountryId`).val(1);
                }
                $(`#${uniqueIdPrefix}-cfs-widget-IdentificationCountryId`).trigger("change");


            };
        });

        countriesLookup.select2({
            width: "100%",
            placeholder: "Seleccione un Pais",
            allowClear: true
        });
    };

    var loadIdentificationTypeLookup = function () {
        var identificationTypeLookup = $(`#${uniqueIdPrefix}-cfs-widget-IdentificationTypeId`);
        var selectedIdentification = $(`#${uniqueIdPrefix}-cfs-widget-IdentificationTypeId option:selected`).val();
        var url = "/Lookups/GetIdenticationTypes";

        $.get(url, function (data) {
            if (data) {
                var mapped = data.map(function (item) {
                    return { id: item.Id, text: item.Description }
                });
                refreshSelect2(identificationTypeLookup, mapped);

                if (selectedIdentification !== "") {
                    $(`#${uniqueIdPrefix}-cfs-widget-IdentificationTypeId`).val(selectedIdentification);
                } else {
                    $(`#${uniqueIdPrefix}-cfs-widget-IdentificationTypeId`).val(2);
                }
                $(`#${uniqueIdPrefix}-cfs-widget-IdentificationTypeId`).trigger("change");

            };
        });

        identificationTypeLookup.select2({
            width: "100%",
            placeholder: "Seleccione un Tipo de Identificacion",
            allowClear: true
        });
    };

    loadCountryLookup();
    loadIdentificationTypeLookup();

    //Methods

    function clearWidget(clearCustomerCode) {
        if (clearCustomerCode) {
            $(`#${uniqueIdPrefix}-cfs-widget-CustomerCode`).val("");
        }

        $(`#${uniqueIdPrefix}-cfs-widget-CustomerCode`).removeAttr("disabled");
        $(`#${uniqueIdPrefix}-cfs-widget-SelectedCustomerId`).val(0);
        $(`#${uniqueIdPrefix}-cfs-widget-SelectedCustomerId`).trigger('change');

        $(`#${uniqueIdPrefix}-cfs-widget-CustomerCode`).focus();
        $(`#${uniqueIdPrefix}-cfs-widget-FirstName`).val("").trigger('change');;
        $(`#${uniqueIdPrefix}-cfs-widget-LastName`).val("").trigger('change');;
        $(`#${uniqueIdPrefix}-cfs-widget-Identification`).val("").trigger('change');;

        if (allowNameEditing) {
            $(`#${uniqueIdPrefix}-cfs-widget-FirstName`).removeAttr("readonly");
            $(`#${uniqueIdPrefix}-cfs-widget-LastName`).removeAttr("readonly");
        } else {
            $(`#${uniqueIdPrefix}-cfs-widget-FirstName`).attr("readonly", true);
            $(`#${uniqueIdPrefix}-cfs-widget-LastName`).attr("readonly", true);
        }
        clearPersonPhoto();
        notifyMessage("");
    };

    function notifyMessage(message) {
        $(`#${uniqueIdPrefix}-cfs-widget-error-message`).html(message);
    };

    function notifyStatus(status, customerId, customerNamerFullName) {
        swal({
            type: 'warning',
            title: 'Cliente Inactivo',
            html: `El Cliente <a href="/Customer/details/?id=${customerId}">${customerNamerFullName}</a>  
                    esta en estatus <b>"${status}"</b> y no puede ser utilizado para realizar transacciones.`,
            confirmButtonText: 'Cerrar'
        });
    }

    var findCustomerByCode = function () {
        clearWidget(false);

        var customerCode = $(`#${uniqueIdPrefix}-cfs-widget-CustomerCode`).val();
        if (customerCode.length <= 0) {
            $(`#${uniqueIdPrefix}-cfs-widget-CustomerCode`).focus();
            return;
        };

        var url = "/CustomerFinderWidget/SearchCustomerByCode?code=" + customerCode;
        var searchByCodeCommand = $(`#${uniqueIdPrefix}-cfs-widget-search-by-code-command`);
        searchByCodeCommand.attr("disabled", "disabled");
        searchByCodeCommand.ladda("start");

        $.get(url, function (data) {
            searchByCodeCommand.ladda("stop");
            searchByCodeCommand.removeAttr("disabled");

            if (data && data.hasOwnProperty("Id") && data.Id > 0) {
                if (data.IsActive) {
                    $(`#${uniqueIdPrefix}-cfs-widget-SelectedCustomerId`).val(data.Id);
                    $(`#${uniqueIdPrefix}-cfs-widget-SelectedCustomerId`).trigger('change');
                    $(`#${uniqueIdPrefix}-cfs-widget-Identification`).val(data.Identification).trigger('change');
                    $(`#${uniqueIdPrefix}-cfs-widget-FirstName`).val(data.FirstName).trigger('change');

                    if (data.IdentificationCountryId == 1 && data.IdentificationTypeId == 1) {
                        $(`#${uniqueIdPrefix}-cfs-widget-LastName`).val("").trigger('change');
                    }
                    else {
                        $(`#${uniqueIdPrefix}-cfs-widget-LastName`).val(data.LastName).trigger('change');
                    }

                    $(`#${uniqueIdPrefix}-cfs-widget-FirstName`).attr("readonly", "true");
                    $(`#${uniqueIdPrefix}-cfs-widget-LastName`).attr("readonly", "true");

                    $(`#${uniqueIdPrefix}-cfs-widget-IdentificationCountryId`).val(data.IdentificationCountryId).trigger('change');
                    $(`#${uniqueIdPrefix}-cfs-widget-IdentificationTypeId`).val(data.IdentificationTypeId).trigger('change');

                    if (data.hasOwnProperty("PhotoUrl") && data.PhotoUrl && data.PhotoUrl !== "") {
                        $(`#${uniqueIdPrefix}-person-photo`).attr("src", data.PhotoUrl);
                    }
                } else {
                    notifyStatus(data.CurrentStatusDescription, data.Id, data.FirstName + " " + data.LastName);
                }

                return;
            }
            notifyMessage("No existe un Cliente con este codigo.");
        });
    };

    $(`#${uniqueIdPrefix}-cfs-widget-search-by-code-command`).ladda().click(function () {
        findCustomerByCode();
    });

    function clearPersonPhoto() {
        var placeholderUrl = "/Content/img/person-placeholder-small.png";

        $(`#${uniqueIdPrefix}-person-photo`).attr("src", placeholderUrl);
    }

    var findCustomerByIdentification = function () {
        if ($(`#${uniqueIdPrefix}-cfs-widget-IdentificationTypeId`).val() != 3) {
            $(`#${uniqueIdPrefix}-cfs-widget-FirstName`).val("").trigger('change');
            $(`#${uniqueIdPrefix}-cfs-widget-LastName`).val("").trigger('change');
        }

        notifyMessage("");
        clearPersonPhoto();

        var identfication = $(`#${uniqueIdPrefix}-cfs-widget-Identification`).val();
        var identificationType = $(`#${uniqueIdPrefix}-cfs-widget-IdentificationTypeId`).val();

        if (identfication.length <= 0 || identificationType <= 0) {
            $(`#${uniqueIdPrefix}-cfs-widget-Identification`).focus();
            return;
        };

        var url = "/CustomerFinderWidget/SearchPersonByIdentification";

        var searchByIdCommand = $(`#${uniqueIdPrefix}-cfs-widget-search-by-identification-command`);
        searchByIdCommand.attr("disabled", "disabled");
        searchByIdCommand.ladda("start");

        var param = {
            IdentificationTypeId: identificationType,
            Identification: identfication
        };

        $.post(url, param, function (data) {
            searchByIdCommand.ladda("stop");
            searchByIdCommand.removeAttr("disabled");

            if (!data) {
                return;
            }

            if (data.hasOwnProperty("InvalidIdentification") && data.InvalidIdentification) {
                notifyMessage("Identificacion Invalida, favor verificar.");
                //$(`#${uniqueIdPrefix}-cfs-widget-Identification").val("");
                //$(`#${uniqueIdPrefix}-cfs-widget-Identification").focus();
                return;
            }

            if (data.hasOwnProperty("FirstName")) {
                if (data.CustomerId > 0) {
                    if (data.IsActive) {
                        $(`#${uniqueIdPrefix}-cfs-widget-SelectedCustomerId`).val(data.CustomerId);
                        $(`#${uniqueIdPrefix}-cfs-widget-SelectedCustomerId`).trigger('change');
                        $(`#${uniqueIdPrefix}-cfs-widget-CustomerCode`).val(data.CustomerCode);
                        $(`#${uniqueIdPrefix}-cfs-widget-CustomerCode`).attr("disabled", "disabled");
                        $(`#${uniqueIdPrefix}-cfs-widget-FirstName`).attr("readonly", true);
                        $(`#${uniqueIdPrefix}-cfs-widget-LastName`).attr("readonly", true);
                    } else {
                        notifyStatus(data.CurrentStatusDescription, data.CustomerId, data.FullName);
                    }
                }

                if (data.CustomerId <= 0) {
                    notifyMessage("Esta Persona/Empresa no existe en la Base de Datos de Clientes.");
                }

                if (!data.IsActive) return null;

                $(`#${uniqueIdPrefix}-cfs-widget-IdentificationCountryId`).val(data.CountryId);
                $(`#${uniqueIdPrefix}-cfs-widget-IdentificationCountryId`).trigger("change");
                $(`#${uniqueIdPrefix}-cfs-widget-FirstName`).val(data.FirstName).trigger('change');
                if (data.CountryId == 1 && param.IdentificationTypeId == 1) {
                    $(`#${uniqueIdPrefix}-cfs-widget-LastName`).val("").trigger('change');
                }
                else {
                    $(`#${uniqueIdPrefix}-cfs-widget-LastName`).val(data.LastName).trigger('change');
                }

                if (data.hasOwnProperty("PhotoUrl") && data.PhotoUrl && data.PhotoUrl !== "") {
                    $(`#${uniqueIdPrefix}-person-photo`).attr("src", data.PhotoUrl);
                }
            };

            $.seachOnListRisk();
        });
    };

    $(`#${uniqueIdPrefix}-cfs-widget-search-by-identification-command`).ladda().on('click', function () {
        findCustomerByIdentification();
    });

    $(`#${uniqueIdPrefix}-clear-cfs-widget`).on('click', function () {
        clearWidget(true);
    });

    $(`#${uniqueIdPrefix}-cfs-widget-Identification`).blur(function () {
        var identfication = $(`#${uniqueIdPrefix}-cfs-widget-Identification`).val();
        var identificationType = $(`#${uniqueIdPrefix}-cfs-widget-IdentificationTypeId`).val();

        if (identfication.length <= 0 || identificationType <= 0) {
            return;
        };
        findCustomerByIdentification();
    });

    $(`#${uniqueIdPrefix}-cfs-widget-Identification`).focus();

    $(`#${uniqueIdPrefix}-cfs-widget-FirstName`).on("change keyup", function () {
        setFullName();
    });

    $(`#${uniqueIdPrefix}-cfs-widget-LastName`).on("change keyup", function () {
        setFullName();
    });

    $(`#${uniqueIdPrefix}-cfs-widget-Identification`).keypress(function (e) {
        if (e.which === 13) {
            $(`#${uniqueIdPrefix}-cfs-widget-search-by-identification-command`).trigger("click");
        }

        var identificationTypeId = parseInt($(`#${uniqueIdPrefix}-cfs-widget-IdentificationTypeId`).val());

        return validateIdentificationByIdentifiationType(e, identificationTypeId);
    });

    $(`#${uniqueIdPrefix}-cfs-widget-CustomerCode`).keypress(function (e) {
        if (e.which === 13) {
            $(`#${uniqueIdPrefix}-cfs-widget-search-by-code-command`).trigger("click");
        }
    });

    function setFullName() {
        var firstName = $(`#${uniqueIdPrefix}-cfs-widget-FirstName`).val();
        var lastName = $(`#${uniqueIdPrefix}-cfs-widget-LastName`).val();
        var fullName = `${firstName} ${lastName}`;
        $(`#${uniqueIdPrefix}-cfs-widget-FullName`).val(fullName);
    }

    $.setWitgetControlsAcesibility = function(isDisabled) {
        isDisabled = !isDisabled;

        $(`#${uniqueIdPrefix}-cfs-widget-CustomerCode`).attr("disabled", isDisabled);
        $(`#${uniqueIdPrefix}-cfs-widget-IdentificationCountryId`).val(0);
        $(`#${uniqueIdPrefix}-cfs-widget-IdentificationCountryId`).trigger('change');
        $(`#${uniqueIdPrefix}-cfs-widget-IdentificationCountryId`).attr("disabled", isDisabled);

        $(`#${uniqueIdPrefix}-cfs-widget-IdentificationTypeId`).val(0);
        $(`#${uniqueIdPrefix}-cfs-widget-IdentificationTypeId`).trigger('change');
        $(`#${uniqueIdPrefix}-cfs-widget-IdentificationTypeId`).attr("disabled", isDisabled);

        $(`#${uniqueIdPrefix}-cfs-widget-FirstName`).val("").attr("disabled", isDisabled);
        $(`#${uniqueIdPrefix}-cfs-widget-LastName`).val("").attr("disabled", isDisabled);
        $(`#${uniqueIdPrefix}-cfs-widget-Identification`).val("").attr("disabled", isDisabled);
        $(`#${uniqueIdPrefix}-cfs-widget-search-by-code-command`).attr("disabled", isDisabled);
        $(`#${uniqueIdPrefix}-cfs-widget-search-by-identification-command`).attr("disabled", isDisabled);

        if (isDisabled) {
            $(`#${uniqueIdPrefix}-cfs-widget-adv-search-command`).addClass("hidden");
            $(`#${uniqueIdPrefix}-clear-cfs-widget`).addClass("hidden");
        } else {
            $(`#${uniqueIdPrefix}-cfs-widget-adv-search-command`).removeClass("hidden");
            $(`#${uniqueIdPrefix}-clear-cfs-widget`).removeClass("hidden");
        }
    }

    $.searchCustomerByIdentification = function () {
        findCustomerByIdentification(); 
    }
};
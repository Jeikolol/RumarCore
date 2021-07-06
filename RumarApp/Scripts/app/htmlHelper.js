/*
*
* HTML Helper Functions 
*
*/
function getPhotoPlaceHolder(elementId) {
    var placeHolder = "/Content/img/person-placeholder-small.png";
    var element = document.getElementById(elementId);
    element.src = placeHolder;
}

function getCurrencyWithFlag(currencyCode) {
    return `<img src="/Content/currencyFlags/${currencyCode.toLowerCase()}.png" class='img-flag-currency' width="30" height="20"> ${
        currencyCode}`;
}

function convertToCurrencyFormat(quantity) {
    return quantity.toLocaleString('en', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
}

function convertToRateFormat(quantity) {
    return quantity.toLocaleString('en', { minimumFractionDigits: 4, maximumFractionDigits: 4 });
}

function getBankAccountInformationWidget(element, id) {
    var url = "/BankAccount/GetbankAccountInformation?id=" + id;

    $.get(url, function(data) {
        $(element).html(data);
    });
}

function getCustomerPhotoWidget(element, customerId) {
    if (customerId == 0)
    return; 

    var url = "/Customer/GetCustomerPhotoWidgetData?customerId=" + customerId;

    $.get(url, function (data) {
        $(element).html(data);
    });
}

function getCustomerInformationWidget(element, customerId) {
    if (customerId == 0)
        return;

    var url = "/Customer/GetCustomerInformationWidgetData?customerId=" + customerId;

    $.get(url, function (data) {
        $(element).html(data);
    });
}

function organizeDetail() {
    $("#customerInformationWiget").addClass("hidden");
    $("#transaction-information").removeClass("col-lg-4").addClass("col-lg-8");
    $(".no-visivility").remove();
}

function downloadCsvFile(url) {
    $.showLoadingModal();

    $.post(url, function (data) {
        var blobData = new Blob([data.FileContent], { type: "application/json" });
        var currentUrl = window.URL.createObjectURL(blobData);
        var anchorDownload = document.createElement('a');

        anchorDownload.href = currentUrl;
        anchorDownload.download = data.FileName;

        var node = document.body.appendChild(anchorDownload);

        anchorDownload.click();
        document.body.removeChild(node);
    })
    .always(function () {
        $.hideLoadingModal();
    });
}

function isValidDate(dateString) {
    dateString = dateString.replace(/\//g, "-");
    var regEx = /^\d{4}-\d{2}-\d{2}$/;

    return dateString.match(regEx);
}

function getYearByDate(date) {
    var dateObject = new Date(date);

    return dateObject.getFullYear();
}

function CalculatePersonAge(birthDate) {
    birthDate = birthDate.replace(/\//g, "-");

    if (!isValidDate(birthDate)) {
        console.error("La fecha enviada no es valida");
    }

    var birthDayYear = getYearByDate(birthDate);
    var personAge = new Date().getFullYear() - birthDayYear;

    return personAge;
}

function validatePersonAge(age, maximumAge) {
    var isValidAge = age >= maximumAge;

    if (isValidAge) {
        showErrorSwal(age, maximumAge);
    }

    return isValidAge;
}

function showErrorSwal(age, maximumAge) {
    swal({
        type: 'warning',
        title: `Esta Persona tiene ${age} Años,La Edad Máxima Permitida es ${maximumAge} Años. Se generara una alerta`
    });
}

function changeLabelByMaximumAge(element, isMAximunAge) {
    if (isMAximunAge) {
        $(element).removeClass("label-info");
        $(element).addClass("label-danger");
    } else {
        $(element).removeClass("label-danger");
        $(element).addClass("label-info");
    }
   
}

function validateName(e) {
    var rex = /.*([^a-zA-ZñÑ ]).*/g;

    return !rex.test(e.key);
}

function validateIdentificationByIdentifiationType(e, idnetificationTypeId) {
    var regex;

    switch (idnetificationTypeId) {
        case IDENTIFICATION_TYPE_CONSTANTS.Rnc:
            regex = new RegExp("^[0-9]");
            break;
        case IDENTIFICATION_TYPE_CONSTANTS.Cedula:
            regex = new RegExp("^[0-9]");
            break;
        case IDENTIFICATION_TYPE_CONSTANTS.Passport:
            regex = new RegExp("^[A-Z0-9]");
            break;
        case IDENTIFICATION_TYPE_CONSTANTS.License:
            regex = new RegExp("^[0-9]");
            break;
        case IDENTIFICATION_TYPE_CONSTANTS.InternationalTaxId:
            regex = new RegExp("^[A-Z0-9-]");
            break;
        default:
            return true;
    }

    return regex.test(e.key);
}

function isLowerCase(character) {
    return /[a-z]/.test(character);
}

function getCurrencyFlagByCurrencyCodeAndName(currencyCode, currencyName) {
    return `<span><img src="/Content/currencyFlags/${currencyCode.toLowerCase()
        }.png" width="30" height="20" alt="${currencyName}">`;
}

function getBadgeForBusinessRequestStatus(businessOportunityStatusVal, businessOportunityStatusDescription) {
    var cssClass = "warning";
    var icon = "fa-clock-o";

    switch (businessOportunityStatusVal) {
        case BUSINESS_OPORTUNITY_STATUS_CONSTANTS.Approved:
            cssClass = "primary";
            icon = " fa-check-circle-o";
            break;
        case BUSINESS_OPORTUNITY_STATUS_CONSTANTS.Declined:
            cssClass = "danger";
            icon = "fa-times-circle-o";
            break;
        case BUSINESS_OPORTUNITY_STATUS_CONSTANTS.Executed:
            cssClass = "info";
            icon = "far fa-check-square";
            break;

    }

    return `<span><i class='fa ${icon} fa-lg color-${cssClass}'></i> ${businessOportunityStatusDescription}</span>`;
}

function convertToDateFormat(date) {
    var dateConverted = new Date(date.match(/\d+/)[0] * 1);

    return dateConverted.toLocaleDateString();
} 

function convertToHoursFormat(date) {
    var dateConverted = new Date(date.match(/\d+/)[0] * 1);

    return dateConverted.toLocaleTimeString();
} 

function setAveragetRateByBankAccountCurrency(currencyId, currencyCode, rateContainer) {
    if (currencyCode.toUpperCase() === "DOP") {
        $(rateContainer).val("1.0000");
        return;
    }

    var url = `/Rate/GetAverageRateByCurrencyId?currencyId=${currencyId}`;

    $.postWithAjaxNotificationAndCallback(url, null, function (data) {
        if (data) {
            $(rateContainer).val(data.AverageRate);
        }
    });
}

function changeBtnStatus(btnName, isDisabled) {
    $(btnName).attr("disabled", isDisabled);
}

function setBusinessRequestTransactionType(transactionType) {
    var businessRequestType = "";

    switch (transactionType) {
        case 1:
            businessRequestType = "Solicitud de Compra de Efectivo";
            break;
        case 2:
            businessRequestType = "Solicitud de Compra de Cheque";
            break;
        case 3:
            businessRequestType = "Solicitud de Compra de Transferencia";
            break;
        case 4:
            businessRequestType = "Solicitud de Venta de Efectivo";
            break;
        case 5:
            businessRequestType = "Solicitud de Venta de Cheque";
            break;
        case 6:
            businessRequestType = "Solicitud de Venta de Transferencia";
            break;
        case 7:
            businessRequestType = "Solicitud de Canje de Divisa";
            break;
    }

    return businessRequestType;
}

function convertToDouble(number) {
    if (typeof number !== "string")
        return number;

    return Number(number.replace(/[^0-9\.-]+/g, ""));
}

function setTransactionTotalMinusCommission(amount, comissionTotal, rate) {
    if (typeof amount === "string")
        amount = convertToDouble(amount);

    if (typeof comissionTotal === "string")
        comissionTotal = convertToDouble(comissionTotal);

    if (typeof rate === "string")
        rate = convertToDouble(rate);

    if (isNaN(comissionTotal))
        return null;

    if (amount > 0 && rate > 0) {
        var totalComission = (amount - comissionTotal) * rate;

        $("#amount-rate-total-with-comission-label")
            .text(totalComission.toLocaleString('en', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
    }
}

function setTransactionTotalPlusCommissionInLocalCurrency(amount, comissionTotal, rate) {
    if (typeof amount === "string")
        amount = convertToDouble(amount);

    if (typeof comissionTotal === "string")
        comissionTotal = convertToDouble(comissionTotal);

    if (typeof rate === "string")
        rate = convertToDouble(rate);

    if (isNaN(comissionTotal))
        return null;

    if (amount > 0 && rate > 0) {
        var totalComission = (amount + comissionTotal) * rate;

        $("#amount-rate-total-with-comission-label")
            .text(totalComission.toLocaleString('en', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
    }
}

function openInNewTab(url) {
    var win = window.open(url, '_blank');
    win.focus();
}
function getStatusElement(isReversed) {
    var className = isReversed ? "danger" : "success";
    var status = isReversed ? "Anulado" : "Activo";
    var icon = isReversed ? "fa-ban" : "fa-check-circle-o";

    var element =
        `<div style='font-size: 13px'><span class='label label-${className}'><i class="fa ${icon} fa-lg fa-fw"></i> ${status}</span> </div>`;
    return element;
}


function downloadCsvFileByParameter(url, parameter) {
    $.showLoadingModal();

    $.post(url, parameter, function (data) {
        var blobData = new Blob([data.FileContent], { type: "application/json" });
        var currentUrl = window.URL.createObjectURL(blobData);
        var anchorDownload = document.createElement('a');

        anchorDownload.href = currentUrl;
        anchorDownload.download = data.FileName;

        var node = document.body.appendChild(anchorDownload);

        anchorDownload.click();
        document.body.removeChild(node);
    }).always(function () {
        $.hideLoadingModal();
    });
}

function getBusinessRequestDetailsUrl(businessRequestTypeId, id) {
    var url = "";

    switch (businessRequestTypeId) {
    case 1:
        url = `/CashPurchaseBusinessRequest/details?id=${id}`;
        break;
    case 2:
        url = `/CheckPurchaseBusinessRequest/details?id=${id}`;
        break;
    case 3:
        url = `/TransferencePurchaseBusinessRequest/details?id=${id}`;
        break;
    case 4:
        url = `/CashSaleBusinessRequest/details?id=${id}`;
        break;
    case 5:
        url = `/CheckSaleBusinessRequest/details?id=${id}`;
        break;
    case 6:
        url = `/TransferenceSaleBusinessRequest/details?id=${id}`;
        break;
    case 7:
        url = `/ExchangeBusinessRequest/details?id=${id}`;
        break;
    }

    return url;
}

function validateMaximumRate(rateElement, maximumRate) {
    if ($(rateElement).val() > maximumRate) {
        toastr["error"](`La tasa maxima permitida es <b>${convertToRateFormat(maximumRate)}<b>`, "Error de Tasa");
        $(rateElement).parent().addClass("has-error");

        return false;
    }

    return true;
}

function validateMinimumRate(rateElement, minRate) {
    if ($(rateElement).val() < minRate) {
        toastr["error"](`La tasa minima permitida es <b>${convertToRateFormat(minRate)}<b>`, "Error de Tasa");
        $(rateElement).parent().addClass("has-error");

        return false;
    }

    return true;
}


function validateLocalIdentification(indentificationType, identification, identificationElement) {
    var identificationIsValid = true;

    if (indentificationType == 1) {
        if (!$.SDQ.validarRNC(identification)) {
            toastr["warning"]("Favor Verificar.", "RNC Invalido");

            identificationIsValid = false;
        }
    } else if (indentificationType == 2) {
        if (!$.SDQ.validarCedula(identification)) {
            toastr["warning"]("Favor Verificar.", "Cedula Invalido");
            identificationIsValid = false;
        }
    }

    $(`#${identificationElement}`).focus();

    return identificationIsValid;
}

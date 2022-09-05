/*
*
* HTML Helper Functions 
*
*/
//if ($.cacheConstants === undefined) {
//    $.getScript("/Scripts/app/localStorageCacheHelper.js");
//}
function getPhotoPlaceHolder(elementId) {
    var placeHolder = "/Content/img/person-placeholder-small.png";
    var element = document.getElementById(elementId);
    element.src = placeHolder;
}

function getCurrencyWithFlag(currencyCode) {
    return `<img src="/Content/currencyFlags/${currencyCode.toLowerCase()}.png" class='img-flag-currency' width="30" height="20"> ${currencyCode}`;
}

function convertToCurrencyFormat(quantity) {
    return quantity.toLocaleString('en', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
}

function convertToRateFormat(quantity) {
    return quantity.toLocaleString('en', { minimumFractionDigits: 4, maximumFractionDigits: 4 });
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

//function CalculatePersonAge(birthDate) {
//    loadServerDateToGlobal();
//    birthDate = birthDate.replace(/\//g, "-");

//    if (!isValidDate(birthDate)) {
//        console.error("La fecha enviada no es valida");
//        return 0;
//    }

//    var birthdaySplit = getDateSplitArray(birthDate);
//    var currentServerDate = window.serverDate;

//    var personAge = currentServerDate.Year - birthdaySplit[0];

//    if (currentServerDate.Month < birthdaySplit[1]) {
//        personAge--;
//    } else if (currentServerDate.Month === birthdaySplit[1] && currentServerDate.Day < birthdaySplit[2]) {
//        personAge--;
//    }

//    return personAge;
//}

function getDateSplitArray(date) {
    var dSplit = date.split("-");

    dSplit[0] = parseInt(dSplit[0]);
    dSplit[1] = parseInt(dSplit[1]);
    dSplit[2] = parseInt(dSplit[2]);

    return dSplit;
}

//function showErrorSwal(age, maximumAge) {
//    swal({
//        type: 'warning',
//        title: `Esta Persona tiene ${age} Años, La Edad Máxima Permitida es ${maximumAge} Años. Se generara una alerta`
//    });
//}

//function showErrorSwalAdult(age) {
//    swal({
//        type: 'warning',
//        title: `Esta Persona tiene ${age} Años, La Edad Mínima Permitida es 18 Años`
//    });
//}

//function changeLabelByMaximumAge(element, isMAximunAge) {
//    if (isMAximunAge) {
//        $(element).removeClass("label-info");
//        $(element).addClass("label-danger");
//    } else {
//        $(element).removeClass("label-danger");
//        $(element).addClass("label-info");
//    }

//}

function validateName(e) {
    var rex = /.*([^a-zA-ZñÑ ]).*/g;

    return !rex.test(e.key);
}

function validateFullName(e) {
    var rex = /.*([^a-zA-ZñÑ ]).*/g;

    return !rex.test(e);
}

//function validateIdentificationByIdentifiationType(e, idnetificationTypeId) {
//    var regex;

//    switch (idnetificationTypeId) {
//        case IDENTIFICATION_TYPE_CONSTANTS.Rnc:
//            regex = new RegExp("^[0-9]");
//            break;
//        case IDENTIFICATION_TYPE_CONSTANTS.Cedula:
//            regex = new RegExp("^[0-9]");
//            break;
//        case IDENTIFICATION_TYPE_CONSTANTS.Passport:
//            regex = new RegExp("^[A-Z0-9]");
//            break;
//        case IDENTIFICATION_TYPE_CONSTANTS.License:
//            regex = new RegExp("^[0-9]");
//            break;
//        case IDENTIFICATION_TYPE_CONSTANTS.InternationalTaxId:
//            regex = new RegExp("^[A-Z0-9-]");
//            break;
//        default:
//            return true;
//    }

//    return regex.test(e.key);
//}

function isLowerCase(character) {
    return /[a-z]/.test(character);
}

function convertToDateFormat(date) {
    var dateConverted = new Date(date.match(/\d+/)[0] * 1);

    return dateConverted.toLocaleDateString();
}

function convertToHoursFormat(date) {
    var dateConverted = new Date(date.match(/\d+/)[0] * 1);

    return dateConverted.toLocaleTimeString();
}

function changeBtnStatus(btnName, isDisabled) {
    $(btnName).attr("disabled", isDisabled);
}

function convertToDouble(number) {
    if (typeof number !== "string")
        return number;

    return Number(number.replace(/[^0-9\.-]+/g, ""));
}

function openInNewTab(url) {
    var win = window.open(url, '_blank');
    win.focus();
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
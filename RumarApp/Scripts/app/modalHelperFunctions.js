/*
 *
 *   Estas son las clases Helpers para usarse en los modales
 *
 */

$.removeHash = function () {
    history.pushState("", document.title, window.location.pathname
        + window.location.search);
}

$.formIsValid = function (formElement, callback) {
    $(formElement).validator("validate");
    if (!$(formElement).validator("validate").has(".has-error").length) {
        callback();
    }
}

function submitFormModal(url) {
    $("form").validator("validate");
    if (!$("form").validator("validate").has(".has-error").length) {
        var viewModel = $("form").serialize();
        $.postWithAjaxNotification(url, viewModel);
    }
}

function disableElementIfEmptyValue(elementToDisable, elementOfValue) {
    if ($(elementOfValue).val() !== "") {
        $(elementToDisable).prop("disabled", false);
    } else {
        $(elementToDisable).prop("disabled", true);
    }
}

function getModal(url, container) {
    $.get(url, function (data) {
        $(container).html(data);
        $(container).modal({ backdrop: 'static', keyboard: false });
        $(container).modal('show');
    });
}

function postAddAttachment(url, viewModel, container) {
    $.showLoadingModal();
    $.post(url, viewModel)
        .done(function (data) {
            $(container).html(data);
            $(container).modal({ backdrop: 'static', keyboard: false });
            $.hideLoadingModal();
            $(container).modal('show');
        });
}

function getModalWithViewModel(url, viewModel, container) {
    $.showLoadingModal();
    $.get(url, viewModel)
        .done(function (data) {
            $(container).html(data);
            $(container).modal({ backdrop: 'static', keyboard: false });
            $.hideLoadingModal();
            $(container).modal('show');
        });
}

function putCancelButtonToSmartWizard(positionLeft) {
    $(".sw-toolbar-bottom").append('<div class="btn-group navbar-btn pull-left" role="group" style="left:' + positionLeft + ';"><button type="button" data-dismiss="modal" class="btn btn-danger btn-outline cancel-smart-wizard-btn">Cancelar</button></div>');
    $(".cancel-smart-wizard-btn").on("click", $.removeHash);
}

function moveButtonsSmartWizard(position) {
    $(".sw-toolbar-bottom .pull-right").css("left", position);
}

function putCancelButtonToSmartWizardId(smartwizardId, positionLeft) {
    $(`#${smartwizardId} .sw-toolbar-bottom`).append('<div class="btn-group navbar-btn pull-left" role="group" style="left:' + positionLeft + ';"><button type="button" data-dismiss="modal" class="btn btn-danger btn-outline cancel-smart-wizard-btn">Cancelar</button></div>');
    $(".cancel-smart-wizard-btn").on("click", $.removeHash);
}

function moveButtonsSmartWizardId(smartwizardId, position) {
    $(`#${smartwizardId} .sw-toolbar-bottom .pull-right`).css("left", position);
}

function selectedOptionDefault(elementId, text) {
    $(elementId + " > option").each(function () {
        var searchText = $(this).text().toLowerCase();
        if (text.search(searchText) >= 0) {
            $(elementId).val($(this).val()).trigger('change');
        }
    });
}

function removeOptionBySelectedElement(elementId, text) {
    $(elementId + " > option").each(function () {
        var searchText = $(this).text().toLowerCase();
        if (text.toLowerCase().search(searchText) >= 0) {
            $(this).remove();
        }
    });
}

$.showLoadingModal = function () {
    $('body').loadingModal({ animation: 'threeBounce' });
}

$.hideLoadingModal = function () {
    $('body').loadingModal('hide');
    $('body').loadingModal('destroy');
}

$.getModalWithLoader = function (url, container) {
    $.showLoadingModal();

    $.get(url, function (data) {
        if (data.hasOwnProperty("Type") && data.Type == "error") {
            $.hideLoadingModal();
            toastr[data.Type](data.Message, data.Title);

            return null;
        }

        $(container).html(data);
        $(container).modal({ backdrop: 'static', keyboard: false });
        $.hideLoadingModal();
        $(container).modal('show');
    })
     .always(function () {
       $.hideLoadingModal();
    });
}

$.getModalWithLoaderAndParameter = function (url, parameter, container) {
    $.showLoadingModal();

    $.get(url, parameter, function (data) {
        if (data.hasOwnProperty("Type") && data.Type == "error") {
            toastr[data.Type](data.Message, data.Title);
            return null;
        }

        $(container).html(data);
        $(container).modal({ backdrop: 'static', keyboard: false });
        $.hideLoadingModal();
        $(container).modal('show');
    })
    .always(function () {
        $.hideLoadingModal();
     });
};

$.getModalWithLoaderAndParameter = function (url, parameter, container) {
    $.showLoadingModal();

    $.get(url, parameter, function (data) {
        if (data.hasOwnProperty("Type") && data.Type == "error") {
            toastr[data.Type](data.Message, data.Title);
            return null;
        }

        $(container).html(data);
        $(container).modal({ backdrop: 'static', keyboard: false });
        $.hideLoadingModal();
        $(container).modal('show');
    })
    .always(function () {
        $.hideLoadingModal();
    });
};


$.retrieveModalWithLoaderAndParameter = function (url, parameter, container) {
    $.showLoadingModal();

    $.post(url, parameter, function (data) {
        if (data.hasOwnProperty("Type") && data.Type == "error") {
            toastr[data.Type](data.Message, data.Title);
            return null;
        }

        $(container).html(data);
        $(container).modal({ backdrop: 'static', keyboard: false });
        $.hideLoadingModal();
        $(container).modal('show');
    })
    .always(function () {
        $.hideLoadingModal();
    });
};

$.getModalWithLoaderAndCallback = function (url, container, callback) {
    $.showLoadingModal();
    $.get(url, function (data) {
        $(container).html(data);
        $(container).modal({ backdrop: 'static', keyboard: false });
        $.hideLoadingModal();
        $(container).modal('show');
        callback();
    });
}

$.postWithAjaxNotification = function (url, payload) {
    $.showLoadingModal();
    $.ajax({
        type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
        url: url, // the url where we want to POST
        data: payload, // our data object
        dataType: 'json' // what type of data do we expect back from the server
    })
        .always(function (al) {
            $.hideLoadingModal();
        })
        // using the done promise callback
        .done(function (json) {
            if (json.hasOwnProperty("Type") && json.Type == "error") {
                toastr[json.Type](json.Message, json.Title);
                return null;
            }

            if (json.hasOwnProperty("isRedirect") && json.isRedirect) {
                window.location.assign(json.redirectUrl);
            } else {
                window.location.reload();
            }
        })
        .fail(function (failData) {
            var data = failData.responseJSON;

            if (data) {
                toastr[data.Type](data.Message, data.Title);
            }
        });
}

$.postWithAjaxNotificationWithContentType = function (url, payload) {
    $.showLoadingModal();
    $.ajax({
        type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
        url: url, // the url where we want to POST
        data: payload, // our data object
        contentType: 'application/json; charset=utf-8',
        dataType: 'json' // what type of data do we expect back from the server
    })
        .always(function (al) {
            $.hideLoadingModal();
        })
        // using the done promise callback
        .done(function (json) {
            if (json.hasOwnProperty("Type") && json.Type == "error") {
                toastr[json.Type](json.Message, json.Title);
                return null;
            }

            if (json.hasOwnProperty("isRedirect") && json.isRedirect) {
                window.location.assign(json.redirectUrl);
            } else {
                window.location.reload();
            }
        })
        .fail(function (failData) {
            var data = failData.responseJSON;

            if (data) {
                toastr[data.Type](data.Message, data.Title);
            }
        });
}

$.postWithAjaxNotificationAndCallback = function (url, payload, callback, errcallback) {
    $.showLoadingModal();

    $.ajax({
        type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
        url: url, // the url where we want to POST
        data: payload, // our data object
        dataType: 'json' // what type of data do we expect back from the server
    })
    .always(function () {
        $.hideLoadingModal();
    })
    // using the done promise callback
    .done(function (json) {
        if (json.hasOwnProperty("Type") && json.Type == "error") {
            toastr[json.Type](json.Message, json.Title);
            return null;
        }

        if (json.hasOwnProperty("Type") && json.Type == "errorWithSwal") {
            errcallback(json);
            return null;
        }

        if (json.hasOwnProperty("isRedirect") && json.isRedirect) {
            window.location.href = json.redirectUrl;
        } else {
            callback(json);
        }
    })
    .fail(function (failData) {
        var data = failData.responseJSON;
        if (data) {
            toastr[data.Type](data.Message, data.Title);
        }
    });
}

$.getWithAjaxNotification = function (url) {
    $.showLoadingModal();
    $.ajax({
        type: 'GET',
        url: url, // the url where we want to GET
        dataType: 'json' // what type of data do we expect back from the server
    })
        .always(function () {
            $.hideLoadingModal();
        })
        // using the done promise callback
        .done(function (data) {
            if (data.HasError || data.HasWarning) {
                toastr[data.Type](data.Message, data.Title);
            } else if (data.isRedirect) {
                window.location.href = data.redirectUrl;
            } else {
                window.location.reload();
            }
        })
        .fail(function (failData) {
            var data = failData.responseJSON;
            if (data) {
                toastr[data.Type](data.Message, data.Title);
            }
        });
}

$.getWithAjaxNotificationAndCallback = function (url, callback) {
    $.showLoadingModal();
    $.ajax({
        type: 'GET',
        url: url, // the url where we want to GET
        dataType: 'json' // what type of data do we expect back from the server
    })
        .always(function () {
            $.hideLoadingModal();
        })
        // using the done promise callback
        .done(function (data) {
            if (data.HasError || data.HasWarning) {
                toastr[data.Type](data.Message, data.Title);
            } else if (data.isRedirect) {
                window.location.href = data.redirectUrl;
            } else {
                callback(data);
            }
        })
        .fail(function (failData) {
            var data = failData.responseJSON;
            if (data) {
                toastr[data.Type](data.Message, data.Title);
            }
        });
}

$.submitFormModalWithAjaxNotification = function (formElement) {
    $(formElement).validator("validate");

    if (!$(formElement).validator("validate").has(".has-error").length) {
        var viewModel = $(formElement).serialize();
        var url = $(formElement).attr("action"); // the url where we want to POST

        $.postWithAjaxNotification(url, viewModel);
    }
}

$.refreshSelect2 = function ($input, data) {
    $input.html('').parent().find("span.select2-container").remove();
    $input.select2({
        data: data,
        width: "100%",
        placeholder: "Seleccione una opcion"
    });
}

$.submitFormModalWithCallback = function(url, callback) {
    $("form").validator("validate");
    if (!$("form").validator("validate").has(".has-error").length) {
        var viewModel = $("form").serialize();
        $.postWithAjaxNotificationAndCallback(url, viewModel, callback);
    }
}

function addElementToSelect2(select2Id, element) {
    $(select2Id).append(element).trigger("change");
    $(select2Id).val(0).trigger('change');
}

function select2WithPlaceHolder(element, placeHolder) {
    $(element).select2({
        placeholder: placeHolder,
        allowClear: false,
    });
}

function select2WithPlaceHolderAllowClear(element, placeHolder) {
    $(element).select2({
        placeholder: placeHolder,
        allowClear: true
    });
}

function loadBanchCashBoxMessengerWidget() {
    $.get("/BranchCashBoxMessengerWidget/Index", function (data) {
        $("#banchCashBoxMessengerWidget").html(data);
    });
}

function isFisicalPerson(personType) {
    var fisicalPerson = 1;
    var diplomaticPerson = 4;
    var pep = 7;

    return personType == fisicalPerson || personType == diplomaticPerson || personType == pep;
}

function selectedOptionByValue(selectedValue, elementId) {
    $(elementId).val(selectedValue).trigger("change");
}

function convertCurrencyToDouble(number) {
    return Number(number.replace(/[^0-9\.-]+/g, ""));
}

function getFormatCurrency(amount) {
    return amount.toLocaleString('en', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
} 

function getCustomerEconomicalActivityByCustomerId(customerId, select2Id) {
    var url = `/Customer/GetCustomerEconomicalActivityByCustomerId?customerId=${customerId}`;

    $.get(url, function (data) {
        var newOption = new Option(`${data.Code} - ${data.Description}`, data.Id, false, false);
        $(select2Id).append(newOption).trigger('change');
        $(select2Id).val(data.Id).trigger('change');
    });
}

function GetCustomerEconomicalActivityCompanyByCustomerId(customerId, select2Id) {
    var url = `/Customer/GetCustomerEconomicalActivityCompanyByCustomerId?customerId=${customerId}`;

    $.get(url, function (data) {
        $(select2Id).val(data.Id).trigger('change');
    });
}

function normalizeImageUrl(imageUrl) {
    var isValid = true;

    if (!imageUrl)
        isValid = false;

    return isValid ? imageUrl : "/Content/img/person-placeholder-small.png";
}

function downloadFile(url, fileName) {
    $.showLoadingModal();

    $.get(url, function (data) {
        $.hideLoadingModal();

        if (data.hasOwnProperty("Type") && data.Type == "error") {
            toastr[data.Type](data.Message, data.Title);
            return null;
        }

        var link = document.createElement('a');
        link.href = url;
        link.download = fileName;
        link.dispatchEvent(new MouseEvent('click'));
    });
}

function downloadFileUsingPost(url, param) {
    $.post(url, param, function (data) {
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

function validateEmail(email) {
    var regex = /\S+@\S+\.\S+/;

    if (typeof email !== "string")
        return false;

    return regex.test(email);
}

function validateWebPage(webPage) {
    var regex = /^((ftp|http|https):\/\/)?(www.)?(?!.*(ftp|http|https|www.))[a-zA-Z0-9_-]+(\.[a-zA-Z]+)+((\/)[\w#]+)*(\/\w+\?[a-zA-Z0-9_]+=\w+(&[a-zA-Z0-9_]+=\w+)*)?$/gm;

    if (typeof webPage !== "string")
        return false;

    return regex.test(webPage);
}


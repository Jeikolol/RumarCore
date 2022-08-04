$(document).ready(function () {
    $('.add-item').click(function () {
        var command = $(this);
        var url = command.attr('data-url-action');

        $.get(url, function (data) {
            var modalPage = $('#item-modal');

            modalPage.html(data);
            //$('#modal-view').addClass("modal-size");
            modalPage.modal({
                backdrop: 'static',
                keyboard: false
            });
        });
    });
});

function getModal(url, modalElement) {
    $.get(url, function (data) {
        var modalPage = $(`#${modalElement}`);

        modalPage.html(data);
        //$('#modal-view').addClass("modal-size");
        modalPage.modal({
            backdrop: 'static',
            keyboard: false
        });
    });
}

function postModal(url, params, modalElement) {
    $.post(url, params, function (data) {
        var modalPage = $(`#${modalElement}`);

        modalPage.html(data);
        //$('#modal-view').addClass("modal-size");
        modalPage.modal({
            backdrop: 'static',
            keyboard: false
        });
    });
}
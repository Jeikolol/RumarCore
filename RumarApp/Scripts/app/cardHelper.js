$.openCardAndLoadContent = function (elementId, url, table, isFirstOpen) {
    if (!$(`#${elementId} .collapse-button .fa-chevron-down`).length && isFirstOpen) {
        $.getWithAjaxNotificationAndCallback(url,
            function (resultData) {
                if (resultData.hasOwnProperty("ExecutedSuccesfully") && resultData.ExecutedSuccesfully) {
                    table.clear().draw().rows.add(resultData.Data).draw();
                }
            });

        $(`#${elementId} .card-wrapper`).css({ "overflow": "", "max-height": "" });
        
    } else {
        $(`#${elementId} .card-wrapper`).css("overflow", "hidden");
    }
}

$.refreshCardContent = function (elementId, url, table, isfirstOpen)
{
    $(`#${elementId} .card-refresh .fas`).addClass("fa-spin");

    if (!isfirstOpen) {
        $.getWithAjaxNotificationAndCallback(url, function (resultData) {
            if (resultData.hasOwnProperty("ExecutedSuccesfully") && resultData.ExecutedSuccesfully) {
                table.clear().draw().rows.add(resultData.Data).draw();

                $(`#${elementId} .card-wrapper`).css({ "overflow": "", "max-height": "" });
            }
        });
    }

    $(`#${elementId} .card-wrapper`).css("overflow", "hidden");
    $(`#${elementId} .card-refresh .fas`).removeClass("fa-spin");
}
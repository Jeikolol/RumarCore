var InitBankSwiftSelector = function (elementNameId) {
    select2WithPlaceHolder(`#${elementNameId}`, "Escriba codigo de swift para buscar...");
    //https://stackoverflow.com/questions/28958620/using-select2-4-0-0-with-infinite-data-and-filter#29018243
    var query = {};
    var $element = $(`#${elementNameId}`);

    function markMatch(text, term) {
        var match = text.toUpperCase().indexOf(term.toUpperCase());
        var $result = $('<span></span>');

        if (match < 0) {
            return $result.text(text);
        }

        $result.text(text.substring(0, match));

        var $match = $('<span class="select2-rendered__match"></span>');
        $match.text(text.substring(match, match + term.length));

        $result.append($match);

        $result.append(text.substring(match + term.length));

        return $result;
    }


    $element.each(function (index) {
        var $this = $(this);

        var endpointUrl = $this.data('ajaxurl');
        $this.select2({
            placeholder: "Escriba el código de swift que desea buscar...",
            minimumInputLength: 4,
            ajax: {
                url: endpointUrl,
                dataType: 'json',
                delay: 250,
                data: function (params) {
                    return {
                        swiftNumber: params.term,
                        page: params.page
                    };
                },
                processResults: function (data) {
                    return {
                        results: $.map(data,
                            function (obj) {
                                return { id: obj.Id, text: obj.Description };
                            })
                    };
                }
            },
            templateResult: function (item) {
                if (item.loading) {
                    return item.text;
                }

                var term = query.term || '';
                var $result = markMatch(item.text, term);

                return $result;
            },
            language: {
                searching: function (params) {
                    query = params;
                    return 'Buscando Swift…';
                },
                noResults: function () {
                    return "Swift no encontrado";
                },
                inputTooShort: function () {
                    return 'Escriba 4 o mas carácteres para buscar...';
                }
            }
        });
    });
}
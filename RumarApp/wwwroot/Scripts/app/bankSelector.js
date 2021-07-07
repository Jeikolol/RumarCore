var initBankSelector = function(countryIdElement,bankIdElement) {
        var countryEndpointUrl = $(`#${countryIdElement}`).data('ajaxurl');
        var bankEndpointUrl = $(`#${bankIdElement}`).data('ajaxurl');

        $(`#${bankIdElement}`).attr("readonly", true);

        var countryUrl = '/LookUps/GetCountries';

        $.get(countryUrl, function (json) {
            $(`#${countryIdElement}`).select2({
                data: json.map(function (item) {
                    return { id: item.Id, text: item.Name };
                }),
                placeholder: "Buscar Pais"
            });
        });

        $(`#${countryIdElement}`).on('change', function () {
            if ($(`#${countryIdElement}`).attr("readonly") === 'readonly') {
                $(`#${bankIdElement}`).attr("readonly", true);
            } else {
                $(`#${bankIdElement}`).attr("readonly", false);

                $(`#${bankIdElement}`).find('option').remove();
            }
        });

        $(`#${bankIdElement}`).select2({
            placeholder: "Seleccionar Banco",
            minimumInputLength: 3,
            width: '100%',
            ajax: {
                url: bankEndpointUrl,
                dataType: 'json',
                delay: 250,
                data: function (params) {
                    var query = {
                        countryId: $(`#${countryIdElement} :selected`).val(),
                        q: params.term
                    }
                    return query;
                },
                processResults: function(data) {
                    return {
                        results: $.map(data, function(obj) {
                            return { id: obj.Id, text: obj.RoutingNumberAndName };
                        })
                    };
                }

            }
    });
    }
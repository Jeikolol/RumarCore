//DataTable 
function attachDataTable(table, column = 0, sorting = "asc" ) {
   return $(table).DataTable(
        {
            responsive: true,
            dom: '<"top">rt<"bottom"lp><"clear">',
            lengthMenu: [25, 50, 100, 200],
            "order": [[column, sorting]],
            language: {
                emptyTable: "No hay Datos para mostrar",
                paginate: {
                    "first": "Primera",
                    "last": "Ultima",
                    "next": "Proxima",
                    "previous": "Anterior"
                },
                lengthMenu: "Mostrando _MENU_ Registros"
            }
        });
}

function attachDataTableWithoutPagination(table) {
    return $(table).DataTable(
        {
            responsive: true,
            "paging": false,
            "ordering": false,
            "info": false,
            "searching": false
        });
}

function attachBusinessRequestDataTable(table) {
   return $(table).DataTable(
        {
            responsive: true,
            dom: '<"top">rt<"bottom"lp><"clear">',
            lengthMenu: [25, 50, 100, 200],
            "order": [[1, "desc"]],
            language: {
                emptyTable: "No hay Solicitudes para mostrar",
                paginate: {
                    "first": "Primera",
                    "last": "Ultima",
                    "next": "Proxima",
                    "previous": "Anterior"
                },
                lengthMenu: "Mostrando _MENU_ Solicitudes",
            }
        });
}

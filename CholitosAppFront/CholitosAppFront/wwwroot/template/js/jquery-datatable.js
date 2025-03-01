$(function () {

    //Exportable table
    $('.js-exportable').DataTable({
        dom: 'Bfrtip',
        responsive: true,
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ],
        language: {
            "processing": "Procesando...",
            "search": "Buscar:",
            "lengthMenu": "Mostrar _MENU_ entradas",
            "info": "Mostrando _START_ - _END_ de _TOTAL_ registros",
            "infoEmpty": "No hay datos para mostrar",
            "infoFiltered": "(Filtrado de _MAX_ registros)",
            "loadingRecords": "Cargando...",
            "zeroRecords": "No se encontraron coincidencias",
            "emptyTable": "No hay datos disponibles en la tabla",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            },
            "aria": {
                "sortAscending": "Activar para ordenar la columna de manera ascendente",
                "sortDescending": "Activar para ordenar la columna de manera descendente"
            },
        },
    });
});
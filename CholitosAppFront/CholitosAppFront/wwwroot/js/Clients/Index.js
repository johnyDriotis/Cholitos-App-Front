

$(document).on('click', '.eliminar-cliente', function () {
    var idCliente = $(this).data('idcliente');
    var nombreCompleto = $(this).data('nombrecompleto');

    showCancelMessage(
        'Eliminar cliente ... ',
        '¿Seguro quiere eliminar el cliente ' + nombreCompleto,
        'Confirmar',
        'Cancelar',
        function () {
            // console.log('Eliminar cliente')
            $.ajax({
                url: '/Client/DeleteClient',
                type: 'post',
                dataType: 'json',
                data: {
                    IdCliente: idCliente
                },
                success: function (resp) {
                    if (resp.errorGenerado == null && resp.generoError == false) {
                        javascriptRedirect('/Client/Index');
                    }
                    else {
                        showNotification('alert-danger', 'Ocurrio un error al eliminar el cliente', 'top', 'center');
                    }
                },
                error: function (xhr, status) {
                    // console.log(xhr.responseText);
                    showNotification('alert-danger', 'Ocurrio un error al eliminar el cliente', 'top', 'center');
                }
            });
        },
        function () {
        }
    );
});

$(document).on('click', '.cambiar-estado', function () {
    var estadoEnviar = false;
    var idCliente = $(this).data('idcliente');
    var nombreCompleto = $(this).data('nombrecompleto');
    var estado = $(this).data('estado');

    estadoEnviar = estado == 'A' ? "I": "A";

    showCancelMessage(
        'Cambiar estado de cliente ... ',
        '¿Seguro quiere cambiar el estado del cliente ' + nombreCompleto,
        'Confirmar',
        'Cancelar',
        function () {
            // console.log('Cambiar estado del cliente')
            $.ajax({
                url: '/Client/ChangeStateClient',
                type: 'post',
                dataType: 'json',
                data: {
                    IdCliente: idCliente,
                    Estado: estadoEnviar
                },
                success: function (resp) {
                    if (resp.errorGenerado == null && resp.generoError == false) {
                        javascriptRedirect('/Client/Index');
                    }
                    else {
                        showNotification('alert-danger', 'Ocurrio un error al cambiar el estado del cliente', 'top', 'center');
                    }
                },
                error: function (xhr, status) {
                    // console.log(xhr.responseText);
                    showNotification('alert-danger', 'Ocurrio un error al cambiar el estado del cliente', 'top', 'center');
                }
            });
        },
        function () {
        }
    );
});
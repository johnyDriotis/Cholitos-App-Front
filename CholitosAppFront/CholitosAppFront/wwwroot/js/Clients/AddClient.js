$('#frmAgregarCliente').validate({
    rules: {
        'txtPrimerNombre': {
            required: true,
            maxlength: 30
        },
        'txtPrimerApellido': {
            required: true,
            maxlength: 30
        }
    },
    messages: {
        'txtPrimerNombre': {
            required: "* Este campo es requerido ...",
            maxlength: "* 30 caracteres permitidos ..."
        },
        'txtPrimerApellido': {
            required: "* Este campo es requerido ...",
            maxlength: "* 30 caracteres permitidos ..."
        }
    },
    highlight: function (input) {
        $(input).parents('.form-line').addClass('error');
    },
    unhighlight: function (input) {
        $(input).parents('.form-line').removeClass('error');
    },
    errorPlacement: function (error, element) {
        $(element).parents('.form-group').append(error);
    },
    submitHandler: function (form) {
        var estadoEnviar = $('#chkEstado').is(':checked') ? "A" : "I";

        $.ajax({
            url: '/Client/AddClient',
            type: 'post',
            dataType: 'json',
            data: {
                PrimerNombre: $('#txtPrimerNombre').val(),
                SegundoNombre: $('#txtSegundoNombre').val(),
                PrimerApellido: $('#txtPrimerApellido').val(),
                SegundoApellido: $('#txtSegundoApellido').val(),
                ApellidoCasada: $('#txtApellidoCasada').val(),
                Estado: estadoEnviar
            },
            success: function (resp) {
                //console.log(resp);
                if (resp.errorGenerado == null && resp.generoError == false) {
                    showNotification('alert-success', 'Cliente almacenado satisfactoriamente', 'top', 'center');
                    cleanFormFields();
                }
                else {
                    showNotification('alert-danger', 'Ocurrio un error al guardar el cliente', 'top', 'center');
                    cleanFormFields();
                }
            },
            error: function (xhr, status) {
                // console.log(xhr.responseText);
                showNotification('alert-danger', 'Ocurrio un error al guardar el cliente', 'top', 'center');
                cleanFormFields();
            }
        });
    }
});

function cleanFormFields() {
    $('#txtPrimerNombre').val('');
    $('#txtSegundoNombre').val('');
    $('#txtPrimerApellido').val('');
    $('#txtSegundoApellido').val('');
    $('#txtApellidoCasada').val('');
}

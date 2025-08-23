
$(document).ready(function () {

    // Configuraciones iniciales
    $('#chkEstado').attr('checked', true);
    $('#chkEstado').attr('disabled', true);

    $('#btnCapturarHuellas').attr('disabled', true);

    $('#divCustomErrorImage').css('display', 'none');

    configImageDefault();
});

// Validaciones de formulario
$('#frmAgregarCliente').validate({
    rules: {
        'txtPrimerNombre': {
            required: true,
            maxlength: 30
        },
        'txtPrimerApellido': {
            required: true,
            maxlength: 30
        },
        imgCustom: {
            required: true
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
        },
        'imgCustom': {
            required: "* Este campo es requerido ..."
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
        showErrorLabelImage();
        enableImage();

        var primerNombre = $('#txtPrimerNombre').val();
        var primerApellido = $('#txtPrimerApellido').val();
        var clsHuella = $('#fingerPrintImage').hasClass('loadImage');

        if (isNullOrEmpty(primerNombre) == false && isNullOrEmpty(primerApellido) == false && clsHuella) {
            $.ajax({
                url: '/Client/AddClient',
                type: 'post',
                dataType: 'json',
                data: {
                    HuellaDactilar: $('#hdnBase64HuellaDactilar').val(),
                    PrimerNombre: primerNombre,
                    SegundoNombre: $('#txtSegundoNombre').val(),
                    PrimerApellido: primerApellido,
                    SegundoApellido: $('#txtSegundoApellido').val(),
                    ApellidoCasada: $('#txtApellidoCasada').val(),
                    Estado: 'A'
                },
                success: function (resp) {
                    //console.log(resp);
                    if (resp.item.codigoCliente != null) {
                        showNotification('alert-success', 'Cliente almacenado satisfactoriamente', 'top', 'center');
                    }
                    else {
                        showNotification('alert-danger', 'Ocurrio un error al guardar el cliente', 'top', 'center');
                    }
                    cleanFormFields();
                    cleanImageField();
                    configImageAfterSave();
                },
                error: function (xhr, status) {
                    // console.log(xhr.responseText);
                    showNotification('alert-danger', 'Ocurrio un error al guardar el cliente', 'top', 'center');
                    cleanFormFields();
                    cleanImageField();
                    configImageAfterSave();
                }
            });
        }
    }
});

$(document).on('click', '#btnCapturarHuellas', function () {

    showProgressModal('Por favor, coloque su dedo en el dispositivo dactilar', 'Capturando');

    $.ajax({
        url: '/Client/GetFingerPrintCaptures',
        type: 'post',
        dataType: 'json',
        success: function (resp) {
            //console.log(resp);

            if (resp.isError) {
                showNotification('alert-danger', resp.errorMessage, 'top', 'center');
                cleanImageField();
                $('#btnCapturarHuellas').attr('disabled', true);
                return;
            }
            else {
                var images = resp.item.base64ImgsFingerPrint;
                document.getElementById('fingerPrintImage').src = 'data:image/png;base64,' + images[0];
                $('#hdnBase64HuellaDactilar').val(images[0]);
                configImageDefault();
                $('#fingerPrintImage').addClass('loadImage');
            }
        },
        error: function (xhr, status) {
            // console.log(xhr.responseText);
            showNotification('alert-danger', 'Ocurrio un error al guardar el cliente', 'top', 'center');
            cleanFormFields();
        },
        complete: function (xhr) {
            $('#loadingModal').modal('hide');
        }
    });
})

$(document).on('keyup', '#txtPrimerNombre', function () {
    if ($(this).val().length == 0) {
        $('#btnCapturarHuellas').attr('disabled', true);
        $('#divCustomErrorImage').css('display', 'none');
    }
})

$(document).on('keyup', '#txtPrimerApellido', function () {
    if ($(this).val().length == 0) {
        $('#btnCapturarHuellas').attr('disabled', true);
        $('#divCustomErrorImage').css('display', 'none');
    }
})


// Funciones. 
function cleanFormFields() {
    $('#txtPrimerNombre').val('');
    $('#txtSegundoNombre').val('');
    $('#txtPrimerApellido').val('');
    $('#txtSegundoApellido').val('');
    $('#txtApellidoCasada').val('');
}

function configImageDefault() {
    var imageDefault = document.getElementById('fingerPrintImage');
    imageDefault.style.width = "170px";
    imageDefault.style.height = "120px";
}

function showErrorLabelImage() {
    var primerNombre = $('#txtPrimerNombre').val();
    var primerApellido = $('#txtPrimerApellido').val();
    var clsHuella = $('#fingerPrintImage').hasClass('loadImage');

    if (isNullOrEmpty(primerNombre) == false && isNullOrEmpty(primerApellido) == false && clsHuella == false) {
        $('#divCustomErrorImage').css('display', 'inline');
    }
}

function enableImage() {
    var primerNombre = $('#txtPrimerNombre').val();
    var primerApellido = $('#txtPrimerApellido').val();

    if (isNullOrEmpty(primerNombre) == false && isNullOrEmpty(primerApellido) == false) {
        $('#btnCapturarHuellas').attr('disabled', false);
    }
    else {
        $('#btnCapturarHuellas').attr('disabled', true);
    }
}

function cleanImageField() {
    $('#divCustomErrorImage').css('display', 'none');
}

function configImageAfterSave() {
    $('#fingerPrintImage').removeClass('loadImage');
    $('#btnCapturarHuellas').attr('disabled', true);
    $('#fingerPrintImage').attr('src', '/img/imageDefault.png');
}

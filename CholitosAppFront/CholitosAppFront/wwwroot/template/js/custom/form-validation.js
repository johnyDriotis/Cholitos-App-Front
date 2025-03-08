$(function () {
    $('#form_validation').validate({
        //submitHandler: function (form) {
        //    $(form).ajaxSubmit();
        //},
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
        }
    });
});

/**
 * Redirecciona a una url, segun se indique.
 * @param {any} url Url destino
 * @returns
 */
function javascriptRedirect(url) {
    return window.location.href = url;
}

/**
 * Mostrar notificacion de plugin bootstrap notify personalizada
 * @param {any} colorName Color de la alerta
 * @param {any} text Texto que muestra la alerta
 * @param {any} placementFrom Colocacion de la alerta
 * @param {any} placementAlign Alineacion de la alerta
 * @param {any} animateEnter Animacion de inicio
 * @param {any} animateExit Animacion de salida
 */
function showNotification(colorName, text, placementFrom, placementAlign, animateEnter, animateExit) {
    if (colorName === null || colorName === '') { colorName = 'bg-black'; }
    if (text === null || text === '') { text = 'Ejemplo de texto para showNotification'; }
    if (animateEnter === null || animateEnter === '') { animateEnter = 'animated fadeInDown'; }
    if (animateExit === null || animateExit === '') { animateExit = 'animated fadeOutUp'; }
    var allowDismiss = true;

    $.notify({
        message: text
    },
        {
            type: colorName,
            allow_dismiss: allowDismiss,
            newest_on_top: true,
            timer: 1000,
            placement: {
                from: placementFrom,
                align: placementAlign
            },
            animate: {
                enter: animateEnter,
                exit: animateExit
            },
            template: '<div data-notify="container" class="bootstrap-notify-container alert alert-dismissible {0} ' + (allowDismiss ? "p-r-35" : "") + '" role="alert">' +
                '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
                '<span data-notify="icon"></span> ' +
                '<span data-notify="title">{1}</span> ' +
                '<span data-notify="message">{2}</span>' +
                '<div class="progress" data-notify="progressbar">' +
                '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
                '</div>' +
                '<a href="{3}" target="{4}" data-notify="url"></a>' +
                '</div>'
        });
}

/**
 * Mostrar alerta de plugin sweetalert de confirmacion
 * @param {any} title Titulo de la alerta
 * @param {any} text Texto que contendra la alerta
 * @param {any} confirmButtonText Texto del boton de confirmar
 * @param {any} cancelButtonText Texto del boton de cancelar
 */
function showCancelMessage(title, text, confirmButtonText, cancelButtonText, functionConfirm, functionCancel, cerrarAlConfirmar = true, cerrarAlCancelar = true) {
    if (title === null || title === '') { title = "¿Estas seguro?"; }
    if (text === null || text === '') { text = "No seras capaz de recuperar"; }
    if (confirmButtonText === null || confirmButtonText === '') { confirmButtonText = "Si, borrar ahora!"; }
    if (cancelButtonText === null || cancelButtonText === '') { cancelButtonText = "No, Cancelar operacion!!"; }

    swal({
        title: title,
        text: text,
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: confirmButtonText,
        cancelButtonText: cancelButtonText,
        closeOnConfirm: cerrarAlConfirmar,
        closeOnCancel: cerrarAlCancelar
    }, function (isConfirm) {
        if (isConfirm) {
            functionConfirm();
            
        } else {
            functionCancel();
        }
    });
}

/**
 * Alerta de plugin sweetalert para mostrar mensaje de exito
 * @param {any} textSuccess Texto de exito
 * @param {any} complementTextSuccess Texto que complementa al mensaje de exito
 */
function sweetAlertSuccess(textSuccess, complementTextSuccess) {
    swal(textSuccess, complementTextSuccess, "success");
}

/**
 * Alerta de plugin sweetalert para mostrar mensaje de error
 * @param {any} textError Texto de error
 * @param {any} complementTextError Texto que complementa al mensaje de error
 */
function sweetAlertError(textError, complementTextError) {
    swal(textError, complementTextError, "error");
}

function isNullOrEmpty(field) {
    if (field == null || field == undefined || field == '') {
        return true;
    }
    return false;
}
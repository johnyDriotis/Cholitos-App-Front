
function showProgressModal(textModal = '', textProgressBar = '') {
    $('#loadingModal').modal('show');
    $('#loadingModalLabel').text(textModal);
    $('#barText').text(textProgressBar);
}

jQuery.loadScript = function (url, callback) {
    jQuery.ajax({
        url: url,
        dataType: 'script',
        success: callback,
        async: true
    });
}

$.loadScript('https://rawgit.com/RobinHerbots/Inputmask/3.x/dist/jquery.inputmask.bundle.js', function () {
    $("#CPF").inputmask("999.999.999-99", { removeMaskOnSubmit: true });
});

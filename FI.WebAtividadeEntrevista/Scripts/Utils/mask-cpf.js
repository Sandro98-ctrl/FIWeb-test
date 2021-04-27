
jQuery.loadScript = function (url) {
    jQuery.ajax({
        url: url,
        dataType: 'script',
        async: false
    });
}

$.loadScript('https://rawgit.com/RobinHerbots/Inputmask/3.x/dist/jquery.inputmask.bundle.js');

$("#CPF").inputmask("999.999.999-99", { removeMaskOnSubmit: true });

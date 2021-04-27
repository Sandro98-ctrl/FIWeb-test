
$(document).ready(function () {
    $('#beneficiariosModal').click(function () {
        $.ajax({
            url: urlBenef,
            method: "GET",
            error:
                function (r) {
                    if (r.status == 400)
                        ModalDialog("Ocorreu um erro", r.responseJSON);
                    else if (r.status == 500)
                        ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
                },
            success:
                function (r) {
                    ShowBenefModal(r)
                }
        });
    })
})

function ShowBenefModal(html) {
    var random = Math.random().toString().replace('.', '');
    var html = '<div id="' + random + '" class="modal fade">    ' +
               '    <div class="modal-dialog">                  ' +
               '        <div class="modal-content">             ' +
                            html +  
               '        </div>                                  ' +
               '    </div>                                      ' +
               '</div>                                          ';

    $('body').append(html);
    $('#' + random).modal('show');
}

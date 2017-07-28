//Para mais informações sobre máscaras visitar o seguinte endereço:
//http://plugins.jquery.com/mask/
$(document).ready(function () {
    $(".mascaraTelefone").mask("(00) 00000-0000");
    $(".mascaraCep").mask("00000-000");
    $('.mascaraValores').mask('000.000,00', {reverse: true});
})

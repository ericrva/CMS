//Para mais configurações do datetime picker visitar o seguinte endereço:
//https://uxsolutions.github.io/bootstrap-datepicker/?#sandbox

$(document).ready(function () {

    $('.dateTimePicker').datepicker({
        format: "dd/mm/yyyy",
        todayBtn: "linked",
        clearBtn: true,
        language: "pt-BR",
        autoclose: true,
        todayHighlight: true
    });

    $('.mesAno').datepicker({
        format: "01/mm/yyyy",
        todayBtn: "linked",
        clearBtn: true,
        language: "pt-BR",
        autoclose: true,
        todayHighlight: true
    });

});
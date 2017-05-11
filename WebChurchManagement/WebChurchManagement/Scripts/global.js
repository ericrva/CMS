$(document).ready(function () {
    $('#superTable').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ registros por página",
            "zeroRecords": "Nenhum registro encontrado.",
            "info": "Mostrando página _PAGE_ de _PAGES_",
            "infoEmpty": "Nenhum registro disponível.",
            "infoFiltered": "(Filtrado de um total de _MAX_ registros)",
            "search": "Pesquisar",
            "decimal": ",",
            "thousands": ".",
            "paginate": {
                "first": "Primeiro",
                "previous": "Anterior",
                "next": "Seguinte",
                "last": "Último"
            }
        }
    });
});
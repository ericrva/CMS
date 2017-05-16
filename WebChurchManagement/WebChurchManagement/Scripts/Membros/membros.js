function buscaEnderecoCep() {

    var cep = $("#Cep").val();

    if (cep) {

        $.ajax({
            type: "GET",
            url: "https://viacep.com.br/ws/" + $("#Cep").val() + "/json/",
            datatype: "json",
            success: function (json) {

                var logradouro = json.logradouro;
                var bairro = json.bairro;
                var cidade = json.localidade;
                var uf = json.uf;

                $("#Rua").val(logradouro);
                $("#Bairro").val(bairro);
                $("#Cidade").val(cidade);
                $("#Uf").val(uf);

            },
            error: function (erro) {
                alert("Ocorreu um erro inesperado durante a busca do endereço. " + erro.statusText);
            }

        });

    }

}

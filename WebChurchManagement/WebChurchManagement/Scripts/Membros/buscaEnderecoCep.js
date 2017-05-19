function buscaEnderecoCep() {

    var cep = $("#Cep").val();

    if (cep) {

        $.ajax({
            type: "GET",
            url: "https://viacep.com.br/ws/" + cep + "/json/",
            datatype: "json",
            success: function (json) {

                if (json.erro) {

                    alert("Endereço não encontrado. Verifique o cep.");

                } else {

                    var logradouro = json.logradouro;
                    var bairro = json.bairro;
                    var cidade = json.localidade;
                    var uf = json.uf;

                    $("#Rua").val(logradouro);
                    $("#Bairro").val(bairro);
                    $("#Cidade").val(cidade);
                    $("#Uf").val(uf);

                }

            },
            error: function (erro) {
                alert("Ocorreu um erro inesperado durante a busca do endereço. " + erro.statusText);
            }

        });

    }

}

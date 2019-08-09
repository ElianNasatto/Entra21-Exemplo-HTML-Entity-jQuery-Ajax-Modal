$(function () {

    $("#pessoa-tabela").DataTable({
        ajax: "http://localhost:53131/pessoa/obtertodos",
        serverSide: true,
        columns: [
            { "data": "Id" },
            { "data": "Nome" },
            { "data": "CPF" },
            {
                render: function (data, type, row) {
                    return "<button class='btn btn-primary botao-editar'>Editar</button> <button class='btn btn-primary botao-apagar' > Apagar</button>";
                }
            }
        ]
    })

    $("#pessoa-botao-salvar").on("click", function () {
        $nome = $("#pessoa-campo-nome").val();
        $cpf = $("#pessoa-campo-cpf").val();

        $.ajax({
            url: "http://localhost:53131/pessoa/inserir",
            method : "post",
            data: {
                Nome: $nome,
                CPF: $cpf
            },
            success: function (data) { alert("deu boa") },
            error: function (err) { alert("nao consegue") }
        })
    })

});
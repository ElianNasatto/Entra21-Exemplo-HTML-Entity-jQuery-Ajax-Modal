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
    });
});
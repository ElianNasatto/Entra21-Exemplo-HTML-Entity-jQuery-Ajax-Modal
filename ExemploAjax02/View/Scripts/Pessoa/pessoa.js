$(function () {
    $idAlterar = -1;

    $tabelaPessoa = $("#pessoa-tabela").DataTable({
        ajax: "http://localhost:53131/pessoa/obtertodos",
        serverSide: true,
        columns: [
            { "data": "Id" },
            { "data": "Nome" },
            { "data": "CPF" },
            {
                render: function (data, type, row) {
                    return "<button class='btn btn-primary botao-editar' data-id='" + row.Id + "' > Editar</button > <button class='btn btn-danger botao-apagar' data-id='" + row.Id + "'> Apagar</button>";
                }
            }
        ]
    })

    $("#pessoa-botao-salvar").on("click", function () {
        $nome = $("#pessoa-campo-nome").val();
        $cpf = $("#pessoa-campo-cpf").val();

        if ($idAlterar == -1) {
            inserir($nome, $cpf);
        } else {
            alterar($nome, $cpf);
        }

    });

    function alterar($nome, $cpf) {
        $.ajax({
            url: "http://localhost:53131/pessoa/update",
            method: "post",
            data: {
                id: $idAlterar,
                nome: $nome,
                cpf: $cpf
            },
            success: function (data) { $idAlterar = -1, $("#modal-categoria").modal('hide'); $tabelaPessoa.ajax.reload() },
            error: function (err) { $idAlterar = -1, alert("Erro") }
        })
    }

    function inserir($nome, $cpf) {
        $.ajax({
            url: "http://localhost:53131/pessoa/inserir",
            method: "post",
            data: {
                Nome: $nome,
                CPF: $cpf
            },
            success: function (data) { $("#modal-categoria").modal('hide'); $tabelaPessoa.ajax.reload() },
            error: function (err) { alert("Erro") }
        })


    }

    $(".table").on("click", ".botao-apagar", function () {
        $confirma = confirm("Deseja apagar?");
        if ($confirma == true) {

            $idApagar = $(this).data("id");

            $.ajax({
                url: "http://localhost:53131/pessoa/apagar?id=" + $idApagar,
                method: "get",
                data: {
                    id: $idApagar
                },
                success: function (data) { $tabelaPessoa.ajax.reload() },
                error: function (err) { alert("Erro ao apagar") }
            })
        }
    })

    $(".table").on("click", ".botao-editar", function () {
        $idAlterar = $(this).data("id");
        $.ajax(
            {
                url: "http://localhost:53131/pessoa/obterpeloid?id=" + $idAlterar,
                method: "get",
                success: function (data) {
                    $("#pessoa-campo-nome").val(data.Nome),
                    $("#pessoa-campo-cpf").val(data.CPF),
                    $("#modal-categoria").modal("show")
                },
                error: function (err)
                {
                    alert("Erro ao editar")
                }


            })
    })

});
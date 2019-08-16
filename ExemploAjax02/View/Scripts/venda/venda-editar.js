$(function () {
    $idVenda = $("#id").val();

    $tabela = $("#venda-produtos-index").DataTable({
        ajax: "/produto/obtertodospeloidvenda?idVenda=" + $idVenda,
        serverSide: true,
        columns: [

            { data: "Nome" },
            { data: "Quantidade" },
            { data: "Valor" },
            {
                render: function (data, type, row) {
                    return "<button class='btn btn-primary botao-editar' data-id=" + row.Id + ">Editar</button>\
<button class='btn btn-danger botao-apagar' data-id=" + row.Id + ">Apagar</button>";
                }
            }
        ]
    });

    $("#modal-produto-salvar").on("click", function () {
        $nome = $("#modal-produto-nome").val();
        $quantidade = $("#modal-produto-valor").val();
        $valor = $("#modal-produto-valor").val();
        if ($idAlterar == -1) {
            inserir($nome, $quantidade, $valor);
        } else {
            Alterar($nome, $quantidade, $valor);
        }

    });


    function inserir($nome,$quantidade,$valor) {

        $.ajax({
            url: "/produto/cadastro",
            method: "post",
            data: {
                nome: $nome,
                quantidade: $quantidade,
                valor: $valor,
                idVenda: $idVenda
            },
            success: function (data) { $tabela.ajax.reload(); $("#venda-produto-modal").modal("hide"); LimparCampos(); },
            error: function (err) { alert("Não foi possivel cadastrar"); }
        });

    }

    $("#venda-produtos-index").on("click", ".botao-apagar", function () {
        $id = $(this).data("id");
        $.ajax({
            url: "/produto/apagar?id=" + $id,
            method: "get",
            success: function () {
                $tabela.ajax.reload();

            },
            error: function () {
                alert("não foi possivel apagar");
            }
        });
    });

    $("#venda-produtos-index").on("click", ".botao-editar", function () {
        $id = $(this).data("id");
        $.ajax({
            url: "/produto/obterpeloid?id=" + $id,
            method: "get",
            success: function (data) {
                $idAlterar = $id;
                $("#modal-produto-nome").val(data.Nome);
                $("#modal-produto-quantidade").val(data.Quantidade);
                $("#modal-produto-valor").val(data.Valor);
                $("#venda-produto-modal").modal("show");

            },
            error: function (err) {
                alert("Não foi possivel buscar o registro");
            }
        })

    });

    function Alterar($nome, $quantidade, $valor) {
        $.ajax({

            url: "/produto/alterar",
            method: "post",
            data: {
                nome: $nome,
                quantidade: $quantidade,
                valor: $valor,
                id: $idAlterar

            },
            success: function (data) {

                $("#venda-produto-modal").modal("hide");
                $tabela.ajax.reload();
                LimparCampos();
            },
            erro: function (err) {
                alert("Não foi possivel alterar");
            }
        });

    }

    function LimparCampos() {
        $("#modal-produto-nome").val("");
        $("#modal-produto-quantidade").val("");
        $("#modal-produto-valor").val("");
        $idAlterar = -1;
    }

})
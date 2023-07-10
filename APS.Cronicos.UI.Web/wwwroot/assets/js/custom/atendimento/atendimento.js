
function preencheTbAtendimento() {

    let cns = $("#Paciente_Cns").val();

    requisicao("/Atendimento/Atendimento/ConsultarPorCNS/" + cns, "POST").done(function (retorno) {

        if (retorno.flSucesso) {

            preencheTabelaAtendimento(false, retorno.lstAtendimento);

        } else {
            toastr.error(retorno.mensagem);
        }
    })
}

$(".incluir-atendimento").off("click").on("click", function () {

    $(".loading").fadeIn();

    $("#conteudo").load("/Atendimento/Atendimento/Cadastro", function () {
        $("#titulo").text("Incluir Atendimento");
        $("#modal").modal();

        $(".loading").fadeOut();

        $("#frm-Atendimento").submit(function (event) {

            event.preventDefault();
            event.stopPropagation();

            $("#Atendimento_CnsPaciente").val($("#Paciente_Cns").val());

            requisicao("/Atendimento/Atendimento/Cadastro", "POST", $("#frm-Atendimento").find(":input").serialize())

                .done(function (retorno) {

                    if (retorno.flSucesso) {

                        preencheTabelaAtendimento(true, retorno.lstAtendimento);

                        toastr.success("Atendimento Incluído com sucesso!");

                    } else {
                        toastr.error(retorno.mensagem);
                    }

                    $('#modal').modal('toggle');
                })
        })
    });
});

$('#tb-atendimento').on('click', '.editar-atendimento', function (e) {

    let idAtendimento = $(this).closest("tr").data("id");

    $(".loading").fadeIn();

    $("#conteudo").load("/Atendimento/Atendimento/Editar/" + idAtendimento, function () {
        $("#titulo").text("Editar Atendimento");

        $("#modal").modal();

        $(".loading").fadeOut();

        $("#frm-Atendimento").submit(function (event) {

            event.preventDefault();
            event.stopPropagation();

            $("#Atendimento_CnsPaciente").val($("#Paciente_Cns").val());

            requisicao("/Atendimento/Atendimento/Cadastro", "POST", $("#frm-Atendimento").find(":input").serialize())

                .done(function (retorno) {

                    if (retorno.flSucesso) {

                        preencheTabelaAtendimento(true, retorno.lstAtendimento);

                        toastr.success("Atendimento Incluído com sucesso!");

                    } else {
                        toastr.error(retorno.mensagem);
                    }

                    $('#modal').modal('toggle');
                })
        })
    });
});

$('#tb-atendimento').on('click', '.excluir-atendimento', function (e) {

    let idAtendimento = $(this).closest("tr").data("id");

    toastr.error("<br /><br /><button type='button' id='confirmationButtonYes' class='btn clear'>Sim</button>", 'Deseja excluir teste atendimento?', {

        closeButton: false,
        allowHtml: true,
        onShown: function (toast) {

            $("#confirmationButtonYes").click(function () {

                requisicao("/Atendimento/Atendimento/Excluir/" + idAtendimento, "POST")

                    .done(function (retorno) {

                        if (retorno.flSucesso) {

                            toastr.success(retorno.mensagem);
                            preencheTabelaAtendimento(true, retorno.lstAtendimento);

                        } else {
                            toastr.error(retorno.mensagem);
                        }
                    })
            });
        }
    });
});

function preencheTabelaAtendimento(destroy, lst) {

    if (destroy) {
        $("#tb-atendimento").DataTable().clear().destroy();
    }

    $("#tmpl-atendimentos").tmpl(lst).appendTo("#tb-atendimento > tbody");
    $("#tb-atendimento").DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Portuguese.json"
        },
        "autoWidth": false
    });
}

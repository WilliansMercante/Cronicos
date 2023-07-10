function preencheTbAvaliacao() {

    let cns = $("#Paciente_Cns").val();

    requisicao("/AvaliacaoRisco/AvaliacaoRisco/ConsultarPorCNS/" + cns, "POST").done(function (retorno) {

        if (retorno.flSucesso) {

            preencheTabelaAvaliacao(false, retorno.lstAvaliacaoRisco);

        } else {
            toastr.error(retorno.mensagem);
        }
    })
}

$(".incluir-avaliacao").off("click").on("click", function () {

    $(".loading").fadeIn();

    let cns = $("#Paciente_Cns").val();

    $("#conteudo").load("/AvaliacaoRisco/AvaliacaoRisco/Cadastro/" + cns, function () {
        $("#titulo").text("Incluir Avaliação de Risco");
        $("#modal").modal();

        $(".loading").fadeOut();

        imc();
        flAMG()
        $("#AvaliacaoRisco_Altura").mask("9.99");

        $("#frm-Avaliacao").submit(function (event) {

            event.preventDefault();
            event.stopPropagation();

            $("#AvaliacaoRisco_CnsPaciente").val($("#Paciente_Cns").val());

            requisicao("/AvaliacaoRisco/AvaliacaoRisco/Cadastro", "POST", $("#frm-Avaliacao").find(":input").serialize())

                .done(function (retorno) {

                    if (retorno.flSucesso) {

                        preencheTabelaAvaliacao(true, retorno.lstAvaliacaoRisco);
                        toastr.success("Atendimento Incluído com sucesso!");

                    } else {
                        toastr.error(retorno.mensagem);
                    }

                    $('#modal').modal('toggle');
                })
        })
    });
});

$('#tb-avaliacao').on('click', '.editar-avaliacao', function (e) {

    let idAtendimento = $(this).closest("tr").data("id");

    $(".loading").fadeIn();

    $("#conteudo").load("/AvaliacaoRisco/AvaliacaoRisco/Editar/" + idAtendimento, function () {
        $("#titulo").text("Editar Atendimento");

        imc();
        flAMG();

        $("#AvaliacaoRisco_Altura").mask("9.99");
        $("#modal").modal();

        if ($("#AvaliacaoRisco_FlAmg").is(":checked")) {
            habilitaDtLaudo();
        }

        $(".loading").fadeOut();

        $("#frm-Avaliacao").submit(function (event) {

            event.preventDefault();
            event.stopPropagation();

            $("#Atendimento_CnsPaciente").val($("#Paciente_Cns").val());

            requisicao("/AvaliacaoRisco/AvaliacaoRisco/Cadastro", "POST", $("#frm-Avaliacao").find(":input").serialize())

                .done(function (retorno) {

                    if (retorno.flSucesso) {

                        preencheTabelaAvaliacao(true, retorno.lstAvaliacaoRisco);
                        toastr.success("Avaliação editada com sucesso!");

                    } else {
                        toastr.error(retorno.mensagem);
                    }

                    $('#modal').modal('toggle');
                })
        })
    });
});

$('#tb-avaliacao').on('click', '.excluir-avaliacao', function (e) {

    let idAvaliacao = $(this).closest("tr").data("id");

    toastr.error("<br /><br /><button type='button' id='confirmationButtonYes' class='btn clear'>Sim</button>", 'Deseja excluir teste atendimento?', {

        closeButton: false,
        allowHtml: true,
        onShown: function (toast) {

            $("#confirmationButtonYes").click(function () {

                requisicao("/AvaliacaoRisco/AvaliacaoRisco/Excluir/" + idAvaliacao, "POST")

                    .done(function (retorno) {

                        if (retorno.flSucesso) {

                            toastr.success(retorno.mensagem);
                            preencheTabelaAvaliacao(true, retorno.lstAvaliacaoRisco);

                        } else {
                            toastr.error(retorno.mensagem);
                        }
                    })
            });
        }
    });
});

function preencheTabelaAvaliacao(destroy, lst) {

    if (destroy) {
        $("#tb-avaliacao").DataTable().clear().destroy();
    }

    for (var i = 0; i < lst.length; i++) {

        let retorno = calculaImc(lst[i].peso, (lst[i].altura / 100));

        lst[i]["imc"] = (retorno.imc).toFixed(2);        
        lst[i]["classificacao"] = retorno.mensagem;
        lst[i]["classe"] = retorno.classe;
    }

    $("#tmpl-avaliacoes").tmpl(lst).appendTo("#tb-avaliacao > tbody");
    $("#tb-avaliacao").DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Portuguese.json"
        },
        "autoWidth": false
    });
}

function imc() {

    $('#gerarImc').click(function () {

        let peso = $('#AvaliacaoRisco_Peso').val();
        let altura = $('#AvaliacaoRisco_Altura').val();

        let retorno = calculaImc(peso, altura);

        $("#mensagemImc").html(retorno.mensagem);

        if (retorno.imc == "") {
            $("#resultadoImc").html(retorno.imc);
        } else {
            $("#resultadoImc").html("IMC: " + retorno.imc);
        }

        if (retorno.classe == "") {
            $("#divResultadoIMC").removeClass();
        } else {
            $("#divResultadoIMC").removeClass().addClass(retorno.classe);
        }
    });
}

function flAMG() {

    $("#AvaliacaoRisco_FlAmg").on('click', function () {

        if ($("#AvaliacaoRisco_FlAmg").is(":checked"))
            habilitaDtLaudo()
        else
            desabilitaDtLaudo()
    })
}

function habilitaDtLaudo() {

    $("#divLaudo").show();
    $("#AvaliacaoRisco_DtUltimolaudo").attr("required", true);
}

function desabilitaDtLaudo() {

    $("#divLaudo").hide();
    $("#AvaliacaoRisco_DtUltimolaudo").attr("required", false);
    $("#AvaliacaoRisco_DtUltimolaudo").val("");
}

function calculaImc(peso, altura) {

    let retorno = new Object();
    let imc = peso / (altura * altura);
    let mensagem = "";
    let classe = "";

    if (peso != "" && altura != "") {

        switch (true) {

            case (imc <= 18.5):
                mensagem = "Peso Baixo";
                classe = "alert alert-danger alert-dismissable";
                break;

            case (imc > 18.5 && imc <= 24.9):
                mensagem = "Peso Normal ou Adequado";
                classe = "alert alert-success alert-dismissable";
                break;

            case (imc > 24.9 && imc <= 29.9):
                mensagem = "Sobrepeso";
                classe = "alert alert-warning alert-dismissable";
                break;

            case (imc > 29.9 && imc <= 34.9):
                mensagem = "Obesidade Grau 1";
                classe = "alert alert-danger alert-dismissable";
                break;

            case (imc > 34.9 && imc <= 39.9):
                mensagem = "Obesidade Grau 2";
                classe = "alert alert-danger alert-dismissable";

            default:
                mensagem = "Obesidade Grau 3 ou Mórbida";
                classe = "alert alert-danger alert-dismissable"
                break;
        }

    } else {
        imc = "";
        mensagem = "";
        classe = "";
    }

    retorno.imc = imc;
    retorno.mensagem = mensagem;
    retorno.classe = classe;
    return retorno;
}

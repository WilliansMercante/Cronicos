var paciente;
var pacienteUnidade;

$(document).ready(function () {

    function desabilitaListaAtendimento() {
        $("#liAtendimento").css('pointer-events', 'none');
        $("#liAtendimento").prop("disabled", true);
    }

    desabilitaListaAtendimento();

    function desabilitaListaAvaliacao() {
        $("#liAvaliacao").css('pointer-events', 'none');
        $("#liAvaliacao").prop("disabled", true);
    }

    desabilitaListaAvaliacao();

    function habilitaListaAtendimento() {
        $("#liAtendimento").css('pointer-events', 'auto');
        $("#liAtendimento").prop("disabled", false);
    }

    function habilitaListaAvaliacao() {
        $("#liAvaliacao").css('pointer-events', 'auto');
        $("#liAvaliacao").prop("disabled", false);
    }

    $("#Paciente_Cns").keypress(function (e) {

        if (e.keyCode === 13) {
            e.preventDefault();
            $("#btnPesquisar").click();
            return false;
        }
    });

    $('#frm-paciente').bind("keypress", function (e) {

        if ((e.keyCode == 10) || (e.keyCode == 13)) {
            e.preventDefault();
        }
    });

    $("#btnPesquisar").on("click", function () {

        let cns = $("#Paciente_Cns").val();

        if (validarCns(cns)) {

            requisicao("/Paciente/Paciente/ConsultarPorCNS/" + cns, "POST").done(function (retorno) {

                if (retorno.flSucesso) {

                    paciente = retorno.dadosPaciente.paciente;
                    pacienteUnidade = retorno.dadosPaciente.pacienteUnidade;

                    preencheTbAtendimento();
                    preencheTbAvaliacao();

                    if (paciente != null) {

                        preencherDadosPaciente();

                        if (pacienteUnidade != null) {
                            preencherDadosPacienteUnidade();
                            habilitaListaAtendimento();
                            habilitaListaAvaliacao();


                        } else {

                            toastr.info("Paciente sem vinculo nesta unidade, por favor completar os dados");
                        }

                        toastr.info(retorno.mensagem);
                        desabilitarCampos();

                    } else {

                        $("#btnEditar,#btnCancelar").css("display", "none");
                        $("#btnSalvar,.divBotoesEdicao").css("display", "block");
                        toastr.warning(retorno.mensagem);
                    }

                    $("#divDadosPaciente,#divDadosUnidade,#divDiagnostico").css("display", "block");
                    $("#Paciente_Cns").attr("readonly", true);
                    $("#divPequisar").css("display", "none");
                    $("#divRecarregar").css("display", "block");
                }
                else {
                    toastr.error(retorno.mensagem);
                }
            })
        }
        else {

            toastr.error("CNS inválido");
            $("#divDadosPaciente").css("display", "none");
            $("#divDadosPaciente").find(":input").val("");
        }
    })

    function desabilitarCampos() {
        $("#frm-paciente").find(":input,input[type=checkbox]").not("#btnEditar").attr("disabled", true);
        $("#btnEditar").css("display", "block");
        $("#btnSalvar,#btnCancelar").css("display", "none");
    }

    function preencherDadosPaciente() {

        if (paciente.flObito && !$("#Paciente_FlObito").is(":checked")) {
            $("#Paciente_FlObito").click();
        }

        $("#Paciente_Id").val(paciente.id);
        $("#Paciente_Nome").val(paciente.nome);
        $("#Paciente_Cpf").val(paciente.cpf);
        $("#Paciente_Rg").val(paciente.rg);
        $("#Paciente_DtNascimento").val(moment(paciente.dtNascimento).format("DD/MM/YYYY"));
        $("#Paciente_NrCelular").val(paciente.nrCelular);
        $("#Paciente_NrTelResidencial").val(paciente.nrTelResidencial);
        $("#Paciente_NrTelContato").val(paciente.nrTelContato);
        $("#Paciente_Email").val(paciente.email);
        $("#Paciente_IdSexo").val(paciente.idSexo);
        $("#Paciente_NmPai").val(paciente.nmPai);
        $("#Paciente_NmMae").val(paciente.nmMae);
        $("#Paciente_Cep").val(paciente.cep);
        $("#Paciente_Logradouro").val(paciente.logradouro);
        $("#Paciente_NrLogradouro").val(paciente.nrLogradouro);
        $("#Paciente_Bairro").val(paciente.bairro);
        $("#Paciente_Complemento").val(paciente.complemento);
        $("#Paciente_Municipio").val(paciente.municipio);
        $("#Paciente_UF").val(paciente.uf);

        if (paciente.dtProvavelObito) {
            $("#Paciente_DtProvavelObito").val(moment(paciente.dtProvavelObito).format("DD/MM/YYYY"));
        }
    }

    function preencherDadosPacienteUnidade() {
        $("#PacienteUnidade_Id").val(pacienteUnidade.id);

        if (pacienteUnidade.flForaDeArea && !$("#PacienteUnidade_FlForaDeArea").is(":checked")) {
            $("#PacienteUnidade_FlForaDeArea").click();
            desabilitarCamposEquipe();
        }
        else {

            $("#PacienteUnidade_Prontuario").val(pacienteUnidade.prontuario);

            if (pacienteUnidade.idEquipe) {

                $("#PacienteUnidade_IdEquipe").val(pacienteUnidade.idEquipe);

                requisicaoProfissionais().done(function (retorno) {

                    carregarProfissionaisPorEquipe(retorno.medicos, retorno.enfermeiros);

                    $("#PacienteUnidade_CpfEnfermeiro").val(pacienteUnidade.cpfEnfermeiro);
                    $("#PacienteUnidade_CpfMedico").val(pacienteUnidade.cpfMedico);

                    atualizaNomesPacienteUnidade();

                })
            } else {

                $("#PacienteUnidade_IdEquipe").val("");
            }
        }

        if (pacienteUnidade.diagnostico != null) {
            $("#PacienteUnidade_IdDiagnostico").val(pacienteUnidade.idDiagnostico);
        }
    }

    function atualizaNomesPacienteUnidade() {
        let valorEnfermeiro = $("#PacienteUnidade_CpfEnfermeiro :selected").val();
        $("#PacienteUnidade_NomeEnfermeiro").val(valorEnfermeiro != "" ? $("#PacienteUnidade_CpfEnfermeiro :selected").text() : "");

        let valorMedico = $("#PacienteUnidade_CpfMedico :selected").val();
        $("#PacienteUnidade_NomeMedico").val(valorMedico != "" ? $("#PacienteUnidade_CpfMedico :selected").text() : "");

        let valorEquipe = $("#PacienteUnidade_IdEquipe :selected").val();
        $("#PacienteUnidade_NomeEquipe").val(valorEquipe != "" ? $("#PacienteUnidade_IdEquipe :selected").text() : "");
  
    }

    function limpaNomesPacienteUnidade() {
        $("#PacienteUnidade_NomeEnfermeiro").val("");
        $("#PacienteUnidade_NomeMedico").val("");
        $("#PacienteUnidade_NomeEquipe").val("");    
    }

    function flForaDeArea() {

        $("#PacienteUnidade_FlForaDeArea").on('click', function () {

            if ($("#PacienteUnidade_FlForaDeArea").is(":checked")) {
                desabilitarCamposEquipe();
                limpaNomesPacienteUnidade();
            } else {
                habilitarCamposEquipe();
            }                
        })
    }

    flForaDeArea();

    function desabilitarCamposEquipe() {

        $("#divEquipe").hide();
        $("#PacienteUnidade_Prontuario").removeAttr("required");
        $("#PacienteUnidade_Prontuario").val("");
        $("#PacienteUnidade_IdEquipe").val("");
        $("#PacienteUnidade_CpfEnfermeiro").val("");
        $("#PacienteUnidade_CpfMedico").val("");
    }

    function habilitarCamposEquipe() {

        $("#divEquipe").show();
        $("#PacienteUnidade_Prontuario").attr("required", true);
        $("#PacienteUnidade_IdEquipe").val($("#IdEquipe option:first").val());
        $("#PacienteUnidade_CpfEnfermeiro").val($("#CpfEnfermeiro option:first").val());
        $("#PacienteUnidade_CpfMedico").val($("#CpfMedico option:first").val());
    }

    $("#PacienteUnidade_IdEquipe").on("change", function () {

        if ($(this).val() != "") {

            requisicaoProfissionais().done(function (retorno) {
                if (retorno.flSucesso) {
                    carregarProfissionaisPorEquipe(retorno.medicos, retorno.enfermeiros);
                    atualizaNomesPacienteUnidade();
                }
                else {
                    toastr.error(retorno.mensagem);
                }
            })

        } else {

            $("#PacienteUnidade_CpfEnfermeiro").val($("#CpfEnfermeiro option:first").val());
            $("#PacienteUnidade_CpfMedico").val($("#CpfMedico option:first").val());
        }
    })

    $("#PacienteUnidade_CpfEnfermeiro").on("change", function () {
         let valorEnfermeiro = $("#PacienteUnidade_CpfEnfermeiro :selected").val();
        $("#PacienteUnidade_NomeEnfermeiro").val(valorEnfermeiro != "" ? $("#PacienteUnidade_CpfEnfermeiro :selected").text() : "");
    });

    $("#PacienteUnidade_CpfMedico").on("change", function () {

        let valorMedico = $("#PacienteUnidade_CpfMedico :selected").val();
        $("#PacienteUnidade_NomeMedico").val(valorMedico != "" ? $("#PacienteUnidade_CpfMedico :selected").text() : "");
    });

    $("#PacienteUnidade_IdEquipe").on("change", function () {

        let valorEquipe = $("#PacienteUnidade_IdEquipe :selected").val();
        $("#PacienteUnidade_NomeEquipe").val(valorEquipe != "" ? $("#PacienteUnidade_IdEquipe :selected").text() : "");
    });

    function requisicaoProfissionais() {

        let idEquipe = $("#PacienteUnidade_IdEquipe").val();
        return requisicao("/Paciente/Paciente/ConsultarProfissionaisPorEquipe/" + idEquipe, "POST");
    }

    function carregarProfissionaisPorEquipe(lstMedicos, lstEnfermeiros) {

        var seletorMedico = $("#PacienteUnidade_CpfMedico");
        var seletorEnfermeiro = $("#PacienteUnidade_CpfEnfermeiro");

        preencheCombo(lstMedicos, seletorMedico);
        preencheCombo(lstEnfermeiros, seletorEnfermeiro);
    }

    function preencheCombo(lst, seletor) {

        var $itens = [];

        $itens.push(
            $('<option></option>')
                .val('')
                .html('Sem Profissional de Referência')
                .prop('selected', true)
        );

        $.each(lst, function (index, obj) {

            $itens.push(
                $('<option></option>')
                    .val(obj.cpf)
                    .html(obj.nome)
            );
        });

        seletor.empty().append($itens);
    }

    $("#Paciente_Cep").blur(function () {

        var cep = $(this).val().replace(/\D/g, '');

        if (cep != "") {

            var validacep = /^[0-9]{8}$/;

            if (validacep.test(cep)) {
                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        $("#Paciente_Logradouro").val(dados.logradouro);
                        $("#Paciente_Bairro").val(dados.bairro);
                        $("#Paciente_Municipio").val(dados.localidade);
                        $("#Paciente_UF").val(dados.uf);
                    }
                    else {
                        toastr.error("CEP não encontrado.");
                        limparDadosEndereco();
                    }
                });

            } else {

                toastr.error("Formato de CEP inválido.");
                limparDadosEndereco();
            }
        } else {

            limparDadosEndereco();
        }
    });

    function limparDadosEndereco() {

        $("#Paciente_Logradouro").val("");
        $("#Paciente_Bairro").val("");
        $("#Paciente_Municipio").val("");
        $("#Paciente_UF").val("");
        $("#Paciente_Cep").val("");
    }

    $(".data").mask("99/99/9999");
    $(".cpf").mask("999.999.999-99");
    $(".telefone").mask("(99) 9999-9999?9");
    $(".cep").mask("99999-999");

    $("#btnEditar").off("click").on("click", function () {

        desabilitaListaAtendimento();
        desabilitaListaAvaliacao();

        $("#btnEditar,#btnCancelar,#btnSalvar").toggle();
        $("#frm-paciente").find(":input,input[type=checkbox]").attr("disabled", false);

    })

    $("#btnCancelar").off("click").on("click", function () {

        preencherDadosPaciente();

        if (pacienteUnidade != null) {
            preencherDadosPacienteUnidade();
        } else {
            limpaDadosPacienteUnidade();
            $("#divEquipe").show();
        }

        if ($("#PacienteUnidade_Id").val() != 0) {
            habilitaListaAtendimento();
            habilitaListaAvaliacao();
        }

        $("#btnEditar,#btnCancelar,#btnSalvar").toggle();
        $("#frm-paciente").find(":input,input[type=checkbox]").not("#btnEditar").attr("disabled", true);
    })

    $("#frm-paciente").on("submit", function (event) {

        event.preventDefault();
        event.stopPropagation();

        requisicao("/Paciente/Paciente/Cadastro", "POST", $("#frm-paciente").find(":input").serialize())

            .done(function (retorno) {

                if (retorno.flSucesso) {

                    toastr.success(retorno.mensagem);

                    paciente = new Object();
                    paciente.id = retorno.idPaciente
                    pacienteUnidade = new Object();
                    pacienteUnidade.id = retorno.idPacienteUnidade

                    $("#Paciente_Id").val(retorno.idPaciente);
                    $("#PacienteUnidade_Id").val(retorno.idPacienteUnidade);
                    desabilitarCampos();

                    if (retorno.idPacienteUnidade != 0) {

                        habilitaListaAtendimento();
                        habilitaListaAvaliacao();

                    } else {

                        desabilitaListaAtendimento();
                        desabilitaListaAvaliacao();
                    }

                }
                else {
                    toastr.error(retorno.mensagem);
                }
            })
    })

    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })

    function flObito() {

        $("#Paciente_FlObito").on('click', function () {

            if ($("#Paciente_FlObito").is(":checked"))
                habilitaDtObito();
            else
                desabilitaObito();
        })
    }

    flObito();

    function habilitaDtObito() {

        $("#divDtObito").show();
        $("#Paciente_DtProvavelObito").attr("required", true);
    }

    function desabilitaObito() {

        $("#divDtObito").hide();
        $("#Paciente_DtProvavelObito").attr("required", false);
        $("#Paciente_DtProvavelObito").val("");
    }

    function limpaDadosPacienteUnidade() {

        $("#PacienteUnidade_FlForaDeArea").prop("checked", false);
        $("#PacienteUnidade_Prontuario").val("");
        $("#PacienteUnidade_IdEquipe").val("");
        $("#PacienteUnidade_CpfEnfermeiro").val("");
        $("#PacienteUnidade_CpfMedico").val("");
    };
});


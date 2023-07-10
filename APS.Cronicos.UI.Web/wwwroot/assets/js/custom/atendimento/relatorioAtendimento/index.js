$(document).ready(function () {

    $("#gerarRelatorioAtendimentos").off('click').on('click', function () {

        let flPacientesSemAtendimento

        if ($("#FlPacientesSemAtendimento").is(":checked")) {
            flPacientesSemAtendimento = true
        } else {
            flPacientesSemAtendimento = false
        }
        let cnsPaciente = $("#Paciente_Cns").val();
        let idTipoAtendimento = $("#TipoAtendimento_Id").val();
        let dtInicioAtendimento = $("#DtInicioAtendimento").val();
        let dtFimAtendimento = $("#DtFimAtendimento").val();

        window.open("/Atendimento/RelatorioAtendimento/RptAtendimento?flPacientesSemAtendimento=" + flPacientesSemAtendimento +
            "&cnsPaciente=" + cnsPaciente +
            "&idTipoAtendimento=" + idTipoAtendimento +
            "&dtInicioAtendimento=" + dtInicioAtendimento +
            "&dtFimAtendimento=" + dtFimAtendimento, "_blank");
    })

    $("#FlPacientesSemAtendimento").on('click', function () {

        if ($("#FlPacientesSemAtendimento").is(":checked"))
            desabilitarCamposAtendimento();
        else
            habilitarCamposAtendimento();
    })

    function desabilitarCamposAtendimento() {

        $("#divAtendimento").hide();
        $("#Paciente_Cns").val("");
        $("#TipoAtendimento_Id").val("");
        $("#DtInicioAtendimento").val("");
        $("#DtFimAtendimento").val("");
    }

    function habilitarCamposAtendimento() {

        $("#divAtendimento").show();
    }

});



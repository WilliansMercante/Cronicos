$(document).ready(function () {

    $("#gerarRelatorioPacientes").off('click').on('click', function () {

        let flForaDeArea

        if ($("#PacienteUnidade_FlForaDeArea").is(":checked")) {
            flForaDeArea = true
        } else {
            flForaDeArea = false
        }
        let prontuario = $("#PacienteUnidade_Prontuario").val();
        let idEquipe = $("#PacienteUnidade_IdEquipe").val();
        let cpfEnfermeiro = $("#PacienteUnidade_CpfEnfermeiro").val();
        let cpfMedico = $("#PacienteUnidade_CpfMedico").val();
        let idDiagnostico = $("#PacienteUnidade_IdDiagnostico").val();

        window.open("/Paciente/RelatorioPaciente/RptPaciente?flForaDeArea=" + flForaDeArea +
                "&prontuario=" + prontuario +
                "&idEquipe=" + idEquipe +
                "&cpfEnfermeiro=" + cpfEnfermeiro +
                "&cpfMedico=" + cpfMedico +
                "&idDiagnostico=" + idDiagnostico, "_blank");
    })

    function flForaDeArea() {

        $("#PacienteUnidade_FlForaDeArea").on('click', function () {

            if ($("#PacienteUnidade_FlForaDeArea").is(":checked"))
                desabilitarCampos();
            else
                habilitarCampos();
        })
    }

    flForaDeArea();

    function desabilitarCampos() {

        $("#divEquipe").hide();
        $("#PacienteUnidade_Prontuario").removeAttr("required");
        $("#PacienteUnidade_Prontuario").val("");
        $("#PacienteUnidade_IdEquipe").val("");
        $("#PacienteUnidade_CpfEnfermeiro").val("");
        $("#PacienteUnidade_CpfMedico").val("");
    }

    function habilitarCampos() {

        $("#divEquipe").show();
        $("#PacienteUnidade_Prontuario").attr("required", true);
        $("#PacienteUnidade_IdEquipe").val($("#IdEquipe option:first").val());
        $("#PacienteUnidade_CpfEnfermeiro").val($("#CpfEnfermeiro option:first").val());
        $("#PacienteUnidade_CpfMedico").val($("#CpfMedico option:first").val());
    }   
       
});



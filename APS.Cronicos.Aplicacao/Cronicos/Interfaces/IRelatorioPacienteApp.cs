using APS.Cronicos.ViewModels.Cronicos;
using APS.Cronicos.ViewModels.Cronicos.Paciente;

namespace APS.Cronicos.Aplicacao.Cronicos.Interfaces
{
    public interface IRelatorioPacienteApp
    {
        RptPacienteViewModel RptPaciente(int idUnidade, bool flForaDeArea, string prontuario, string cpfEnfermeiro, string cpfMedico, int? idEquipe, int? idDiagnostico);
    }
}

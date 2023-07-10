using APS.Cronicos.Aplicacao.Corporativo.Interfaces;
using APS.Cronicos.Aplicacao.Cronicos.Interfaces;
using APS.Cronicos.ViewModels.Cronicos.Paciente;

namespace APS.Cronicos.Aplicacao.Cronicos
{
    public sealed class RelatorioPacienteApp : IRelatorioPacienteApp
    {
        private readonly IPacienteUnidadeApp _pacienteUnidadeApp;
        private readonly IPacienteApp _pacienteApp;
        public RelatorioPacienteApp
        (
            IPacienteUnidadeApp pacienteUnidadeApp,
            IPacienteApp pacienteApp
        )
        {
            _pacienteUnidadeApp = pacienteUnidadeApp;
            _pacienteApp = pacienteApp;
        }

        public RptPacienteViewModel RptPaciente
        (
            int idUnidade,
            bool flForaDeArea,
            string prontuario,
            string cpfEnfermeiro,
            string cpfMedico,
            int? idEquipe,
            int? idDiagnostico
        )
        {
            var lstPacienteUnidade = _pacienteUnidadeApp.ListarPorFiltro
            (
                idUnidade,
                flForaDeArea,
                prontuario,
                cpfEnfermeiro,
                cpfMedico,
                idEquipe,
                idDiagnostico
            );

            var oRelatorio = new RptPacienteViewModel();

            foreach (var pacienteUnidade in lstPacienteUnidade)
            {

                var oPaciente = _pacienteApp.ConsultarPorCNS(pacienteUnidade.CnsPaciente);

                if (oPaciente != null)
                {

                    oRelatorio.DadosPaciente.Add(new DadosPacienteViewModel
                    {
                        Paciente = oPaciente,
                        PacienteUnidade = pacienteUnidade,
                        Diagnostico = pacienteUnidade.Diagnostico,
                    });
                }

            };

            return oRelatorio;
        }
    }
}

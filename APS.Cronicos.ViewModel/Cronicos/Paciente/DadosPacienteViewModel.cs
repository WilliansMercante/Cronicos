using APS.Cronicos.ViewModels.Corporativo;

namespace APS.Cronicos.ViewModels.Cronicos.Paciente
{
    public class DadosPacienteViewModel
    {
        public PacienteUnidadeViewModel PacienteUnidade { get; set; }
        public PacienteViewModel Paciente { get; set; }
        public DiagnosticoViewModel Diagnostico { get; set; }
    }
}

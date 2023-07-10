using APS.Cronicos.UI.Web.Areas.Atendimento.ViewModels;
using APS.Cronicos.UI.Web.Areas.AvaliacaoRisco.ViewModels;

namespace APS.Cronicos.UI.Web.Areas.Paciente.ViewModels.Paciente
{
    public class IndexViewModel
    {
        public DadosPacienteViewModel Paciente { get; set; }
        public AvaliacaoRiscoViewModel AvaliacaoRisco { get; set; } = new AvaliacaoRiscoViewModel();
        public AtendimentoViewModel Atendimento { get; set; } = new AtendimentoViewModel();
    }
}

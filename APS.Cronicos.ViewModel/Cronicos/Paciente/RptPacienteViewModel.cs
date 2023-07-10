using System.Collections.Generic;

namespace APS.Cronicos.ViewModels.Cronicos.Paciente
{
    public class RptPacienteViewModel
    {
        public int IdUnidade { get; set; }
        public string NomeUnidade { get; set; }
        public List<DadosPacienteViewModel> DadosPaciente { get; set; } = new List<DadosPacienteViewModel>();
    }
}

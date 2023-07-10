using APS.Cronicos.ViewModels.Corporativo;
using APS.Cronicos.ViewModels.Cronicos;

using Microsoft.AspNetCore.Mvc.Rendering;

using System.Collections.Generic;

namespace APS.Cronicos.UI.Web.Areas.Paciente.ViewModels.Paciente
{
    public class DadosPacienteViewModel
    {
        public Cronicos.ViewModels.Corporativo.PacienteViewModel Paciente { get; set; }
        public PacienteUnidadeViewModel PacienteUnidade { get; set; } = new PacienteUnidadeViewModel();
        public SelectList ListarSexo { get; set; } = new SelectList(new List<string>());
        public SelectList Medicos { get; set; } = new SelectList(new List<string>());
        public SelectList Enfermeiros { get; set; } = new SelectList(new List<string>());
        public SelectList Equipes { get; set; } = new SelectList(new List<string>());
        public SelectList Diagnosticos { get; set; } = new SelectList(new List<string>());
    }
}

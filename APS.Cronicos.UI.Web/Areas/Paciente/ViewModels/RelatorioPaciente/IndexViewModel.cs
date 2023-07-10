using APS.Cronicos.ViewModels.Corporativo;
using APS.Cronicos.ViewModels.Cronicos;

using Microsoft.AspNetCore.Mvc.Rendering;

using System.Collections.Generic;

namespace APS.Cronicos.UI.Web.Areas.Paciente.ViewModels.RelatorioPaciente
{
    public class IndexViewModel
    {
        public PacienteViewModel Paciente { get; set; }
        public PacienteUnidadeViewModel PacienteUnidade { get; set; } = new PacienteUnidadeViewModel();
        public SelectList ListarSexo { get; set; } = new SelectList(new List<string>());
        public List<SelectListItem> Medicos { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Enfermeiros { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Equipes { get; set; } = new List<SelectListItem>();
        public SelectList Diagnosticos { get; set; } = new SelectList(new List<string>());
    }
}

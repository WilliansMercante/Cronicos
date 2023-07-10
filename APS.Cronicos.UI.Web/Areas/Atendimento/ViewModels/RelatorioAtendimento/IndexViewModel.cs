using APS.Cronicos.ViewModels.Corporativo;
using APS.Cronicos.ViewModels.Cronicos;

using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;

namespace APS.Cronicos.UI.Web.Areas.Atendimento.ViewModels.RelatorioAtendimento
{
    public class IndexViewModel
    {
        public SelectList TiposAtendimento { get; set; } = new SelectList(new List<string>());
        public TipoAtendimentoViewModel TipoAtendimento { get; set; }
        public PacienteViewModel Paciente { get; set; }
        public bool FlPacientesSemAtendimento { get; set; }

        public DateTime DtInicioAtendimento { get; set; } = new DateTime(DateTime.Now.Year, (DateTime.Now.Month - 1), 1);
        public DateTime DtFimAtendimento { get; set; } = DateTime.Now;

      

    }
}

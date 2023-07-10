using APS.Cronicos.ViewModels.Corporativo;

using Microsoft.AspNetCore.Mvc.Rendering;

using System.Collections.Generic;

namespace APS.Cronicos.UI.Web.Areas.Atendimento.ViewModels
{
    public class CadastroViewModel
    {
        public SelectList TiposAtendimento { get; set; } = new SelectList(new List<string>());
        public Cronicos.ViewModels.Cronicos.AtendimentoViewModel Atendimento { get; set; }        
    }
}

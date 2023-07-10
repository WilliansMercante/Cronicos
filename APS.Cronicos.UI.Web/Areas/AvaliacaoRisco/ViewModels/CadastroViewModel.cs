using Microsoft.AspNetCore.Mvc.Rendering;

using System.Collections.Generic;

namespace APS.Cronicos.UI.Web.Areas.AvaliacaoRisco.ViewModels
{
    public class CadastroViewModel
    {
        public SelectList EstratificacoesRisco { get; set; } = new SelectList(new List<string>());
        public SelectList TiposDiabetes { get; set; } = new SelectList(new List<string>());
        public Cronicos.ViewModels.Cronicos.AvaliacaoRiscoViewModel AvaliacaoRisco { get; set; }
        public bool flDiabetes { get; set; }
    }
}

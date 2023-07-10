using System.Collections.Generic;

namespace APS.Cronicos.ViewModels.RetornoApi
{
    public class RetornoApiViewModel
    {
        public List<string> Objetos { get; set; } = new List<string>();
        public string Mensagem { get; set; }
        public bool FlSucesso { get; set; }
    }
}

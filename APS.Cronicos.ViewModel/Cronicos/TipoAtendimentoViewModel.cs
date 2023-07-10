using System;
using System.Collections.Generic;
using System.Text;

namespace APS.Cronicos.ViewModels.Cronicos
{
    public class TipoAtendimentoViewModel
    {
        public int Id { get; set; }
        public string TipoAtendimento { get; set; }
        public string Sigla { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}

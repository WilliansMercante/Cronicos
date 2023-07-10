using System;

namespace APS.Cronicos.ViewModels.Cronicos
{
    public class AtendimentoViewModel
    {
        public int Id { get; set; }
        public int IdTipoAtendimento { get; set; }
        public int IdUnidade { get; set; }
        public string CnsPaciente { get; set; }
        public DateTime DtReferencia { get; set; }
        public DateTime DtCadastro { get; set; }

        public TipoAtendimentoViewModel TipoAtendimento { get; set; }
    }
}

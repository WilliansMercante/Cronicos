using System;

namespace APS.Cronicos.ViewModels.Cronicos
{
    public class AvaliacaoDiabetesViewModel
    {
        public int Id { get; set; }
        public int IdAvaliacaoRisco { get; set; }
        public int IdTipoDiabetes { get; set; }
        public string CnsPaciente { get; set; }
        public bool FlAmg { get; set; }
        public bool FlInsulinoDependente { get; set; }
        public DateTime DtUltimaAvaliacaoPes { get; set; }
        public DateTime DtUltimoLaudo { get; set; }
        public DateTime DtCadastro { get; set; }

        public TipoDiabetesViewModel TipoDiabetes { get; set; }
    }
}

using APS.Cronicos.Dominio.EntidadeBase;

using System;

namespace APS.Cronicos.Dominio.Cronicos.Entidades
{
    public class AvaliacaoRiscoEntity : Entidade
    {
        public int IdEstratificacaoRisco { get; set; }
        public int IdUnidade { get; set; }
        public string CnsPaciente { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public DateTime DtEstratificacao { get; set; }
        public string Observacao { get; set; }
        public DateTime DtCadastro { get; set; }
        public int? IdTipoDiabetes { get; set; }
        public bool FlAmg { get; set; }
        public bool FlInsulinoDependente { get; set; }
        public DateTime? DtAvaliacaoPes { get; set; }
        public DateTime? DtUltimolaudo { get; set; }

        public EstratificacaoRiscoEntity EstratificacaoRisco { get; set; }
        public TipoDiabetesEntity TipoDiabetes { get; set; }
    }
}

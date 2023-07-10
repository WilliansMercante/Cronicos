using APS.Cronicos.Dominio.EntidadeBase;

using System;

namespace APS.Cronicos.Dominio.Cronicos.Entidades
{
    public class TipoDiabetesEntity : Entidade
    {
        public string TipoDiabetes { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}

using APS.Cronicos.Dominio.EntidadeBase;

using System;

namespace APS.Cronicos.Dominio.Cronicos.Entidades
{
    public class EstratificacaoRiscoEntity : Entidade
    {
        public string EstratificacaoRisco { get; set; }
        public DateTime DtCadastro { get; set; }
        public bool FlAtivo { get; set; }
    }
}

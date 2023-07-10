using APS.Cronicos.Dominio.EntidadeBase;

using System;

namespace APS.Cronicos.Dominio.Cronicos.Entidades
{
    public class AtendimentoEntity : Entidade
    {
        public int IdTipoAtendimento { get; set; }
        public int IdUnidade { get; set; }
        public string CnsPaciente { get; set; }
        public DateTime DtReferencia { get; set; }
        public DateTime DtCadastro { get; set; }

        public TipoAtendimentoEntity TipoAtendimento { get; set; }
    }
}

using APS.Cronicos.Dominio.EntidadeBase;

using System;

namespace APS.Cronicos.Dominio.Cronicos.Entidades
{
    public class TipoAtendimentoEntity : Entidade
    {
        public string TipoAtendimento { get; set; }
        public string Sigla { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}

using APS.Cronicos.Dominio.EntidadeBase;
using System;

namespace APS.Cronicos.Dominio.ContratoGestao.Entidades
{
    public class ServicoEntity : Entidade
    {
        public int IdSigla { get; set; }
        public string NmServico { get; set; }
        public bool FlStatus { get; set; }
        public DateTime Competencia { get; set; }
        public SiglaEntity Sigla { get; set; }
    }
}

using APS.Cronicos.Dominio.EntidadeBase;
using System;

namespace APS.Cronicos.Dominio.Seguranca.Entidades
{
    public class SistemaEntity: Entidade
    {
        public string NmSistema { get; set; }
        public string DsSistema { get; set; }
        public DateTime DtCadastro { get; set; }
        public bool FlAtivo { get; set; }
    }
}

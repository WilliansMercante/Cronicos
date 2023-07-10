using APS.Cronicos.Dominio.EntidadeBase;

using System;

namespace APS.Cronicos.Dominio.Cronicos.Entidades
{
    public class DiagnosticoEntity : Entidade
    {
        public string Diagnostico { get; set; }
        public DateTime DtCadastro { get; set; }
        public bool FlAtivo { get; set; }
    }
}

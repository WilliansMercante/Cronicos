using APS.Cronicos.Dominio.EntidadeBase;
using System;

namespace APS.Cronicos.Dominio.ContratoGestao.Entidades
{
    public class UnidadeEntity: Entidade
    {
        public int IdSupervisao { get; set; }
        public string Cnes { get; set; }
        public string NmUnidade { get; set; }
        public bool FlStatus { get; set; }
        public DateTime DtDesativacao { get; set; }
        public DateTime Competencia { get; set; }
        public SupervisaoEntity Supervisao { get; set; }
    }
}

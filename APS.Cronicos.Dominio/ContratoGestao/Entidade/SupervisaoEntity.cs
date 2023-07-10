using APS.Cronicos.Dominio.EntidadeBase;
using System;

namespace APS.Cronicos.Dominio.ContratoGestao.Entidades
{
    public class SupervisaoEntity : Entidade
    {
        public int IdContrato { get; set; }
        public string NmSupervisao { get; set; }
        public DateTime Competencia { get; set; }
        public ContratoEntity Contrato { get; set; }
    }
}

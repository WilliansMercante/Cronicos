using System;

namespace APS.Cronicos.ViewModels.ContratoGestao
{
    public class UnidadeViewModel
    {
        public int Id { get; set; }
        public int IdSupervisao { get; set; }
        public string Cnes { get; set; }
        public string NmUnidade { get; set; }
        public bool FlStatus { get; set; }
        public DateTime DtDesativacao { get; set; }
        public DateTime Competencia { get; set; }
        public SupervisaoViewModel Supervisao { get; set; }
    }
}

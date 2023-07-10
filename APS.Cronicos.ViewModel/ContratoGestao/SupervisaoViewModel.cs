using System;

namespace APS.Cronicos.ViewModels.ContratoGestao
{
    public class SupervisaoViewModel
    {
        public int Id { get; set; }
        public int IdContrato { get; set; }
        public string NmSupervisao { get; set; }
        public DateTime Competencia { get; set; }
        public ContratoViewModel Contrato { get; set; }
    }
}

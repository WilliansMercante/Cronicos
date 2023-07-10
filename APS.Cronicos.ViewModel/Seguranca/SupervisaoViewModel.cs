using System;

namespace APS.Cronicos.ViewModels.Seguranca
{
    public class SupervisaoViewModel
    {
        public int Id { get; set; }
        public int IdContrato { get; set; }
        public string NmSupervisao { get; set; }
        public DateTime DtCadastro { get; set; }
        public bool FlAtivo { get; set; }

        public ContratoViewModel Contrato { get; set; }
    }
}

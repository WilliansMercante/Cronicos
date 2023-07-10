using System;

namespace APS.Cronicos.ViewModels.ContratoGestao
{
    public class ServicoViewModel
    {
        public int Id { get; set; }
        public int IdSigla { get; set; }
        public string NmServico { get; set; }
        public bool FlStatus { get; set; }
        public DateTime Competencia { get; set; }
        public SiglaViewModel Sigla { get; set; }
    }
}

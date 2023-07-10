using System;

namespace APS.Cronicos.ViewModels.Seguranca
{
    public class ContratoViewModel
    {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string NmContrato { get; set; }
        public DateTime DtCadastro { get; set; }
        public bool FlAtivo { get; set; }
    }
}
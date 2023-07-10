using APS.Cronicos.ViewModels.Seguranca;

namespace APS.Cronicos.UI.Web.ViewModels
{
    public class PrimeiroAcessoViewModel
    {
        public int Id { get; set; }
        public string NmUsuario { get; set; }
        public string EmailPrincipal { get; set; }
        public string EmailSecundario { get; set; }
        public string Cpf { get; set; }
        public string Token { get; set; }
        public bool FlPrimeiroAcesso { get; set; }
        public int Cnes { get; set; }

        public UnidadeViewModel Unidade { get; set; }
        public GrupoViewModel Grupo { get; set; }
        public string Senha { get; set; }
        public string SenhaConfirmada { get; set; }
    }
}

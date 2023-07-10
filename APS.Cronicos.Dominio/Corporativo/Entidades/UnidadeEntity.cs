using APS.Cronicos.Dominio.EntidadeBase;

namespace APS.Cronicos.Dominio.Corporativo.Entidades
{
    public class UnidadeEntity : Entidade
    {
        public string NmUnidade { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}

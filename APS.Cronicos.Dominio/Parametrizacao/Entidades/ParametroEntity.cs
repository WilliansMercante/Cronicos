using APS.Cronicos.Dominio.EntidadeBase;

namespace APS.Cronicos.Dominio.Parametrizacao.Entidades
{
    public class ParametroEntity : Entidade
    {
        public string DsParametro { get; set; }
        public string Observacao { get; set; }
        public string? Valor { get; set; }
    }
}

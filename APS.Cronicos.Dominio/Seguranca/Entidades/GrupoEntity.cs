using APS.Cronicos.Dominio.EntidadeBase;

namespace APS.Cronicos.Dominio.Seguranca.Entidades
{
    public class GrupoEntity : Entidade
    {
        public string DsGrupo { get; set; }
        public int IdSistema { get; set; }
        public bool FlStatus { get; set; }

        public SistemaEntity Sistema { get; set; }
    }
}

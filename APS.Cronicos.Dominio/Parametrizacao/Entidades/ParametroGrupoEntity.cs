using APS.Cronicos.Dominio.EntidadeBase;

namespace APS.Cronicos.Dominio.Parametrizacao.Entidades
{
    public class ParametroGrupoEntity : Entidade
    {
        public int IdParametro { get; set; }
        public int IdGrupo { get; set; }

        public virtual ParametroEntity Parametro { get; set; }
    }
}

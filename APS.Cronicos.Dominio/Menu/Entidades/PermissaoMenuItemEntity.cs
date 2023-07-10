using APS.Cronicos.Dominio.EntidadeBase;

namespace APS.Cronicos.Dominio.Menu.Entidades
{
    public class PermissaoMenuItemEntity : Entidade
    {
        public int IdMenuItem { get; set; }
        public int IdGrupo { get; set; }

        public virtual MenuItemEntity MenuItem { get; set; }
    }
}

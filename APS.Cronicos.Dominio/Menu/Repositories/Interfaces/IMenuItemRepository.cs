using APS.Cronicos.Dominio.Interfaces;
using APS.Cronicos.Dominio.Menu.Entidades;
using System.Collections.Generic;

namespace APS.Cronicos.Dominio.Menu.Repositories.Interfaces
{
    public interface IMenuItemRepository : IRepositoryBase<MenuItemEntity>
    {
        IEnumerable<MenuItemEntity> ListarPorGrupo(int idGrupo);
    }
}

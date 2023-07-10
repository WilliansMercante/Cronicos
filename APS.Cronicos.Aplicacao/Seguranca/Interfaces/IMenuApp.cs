using APS.Cronicos.ViewModels.Seguranca;
using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.Seguranca.Interfaces
{
    public interface IMenuApp
    {
        IEnumerable<MenuViewModel> ListarPorGrupo(int idGrupo);
    }
}

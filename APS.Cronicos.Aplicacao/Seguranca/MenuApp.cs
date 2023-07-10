using APS.Cronicos.Aplicacao.Mappers;
using APS.Cronicos.Aplicacao.Seguranca.Interfaces;
using APS.Cronicos.Dominio.Menu.Entidades;
using APS.Cronicos.Dominio.Menu.Repositories.Interfaces;
using APS.Cronicos.ViewModels.Seguranca;
using AutoMapper;
using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.Seguranca
{
    public sealed class MenuApp : IMenuApp
    {
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuApp(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public IEnumerable<MenuViewModel> ListarPorGrupo(int idGrupo)
        {
            var lstItensMenuPrincipalEntity = _menuItemRepository.ListarPorGrupo(idGrupo);
            var lstItensMenuPrincipalVM = _mapper.Map<IEnumerable<MenuItemEntity>, IEnumerable<MenuViewModel>>(lstItensMenuPrincipalEntity);
            return lstItensMenuPrincipalVM;
        }
    }
}

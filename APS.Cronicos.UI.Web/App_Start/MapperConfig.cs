using APS.Cronicos.Dominio.Mensagem.Entidades;
using APS.Cronicos.Dominio.Menu.Entidades;
using APS.Cronicos.UI.Web.ViewModels;
using APS.Cronicos.ViewModels.Seguranca;
using AutoMapper;

namespace APS.Cronicos.UI.Web.App_Start
{
    public class MapperConfig
    {
        public static IMapper RegisterMappers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                Seguranca(cfg);
                Configuracoes(cfg);
            });

            return config.CreateMapper();
        }

        private static void Configuracoes(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<MenuItemEntity, MenuViewModel>();
            cfg.CreateMap<MensagemEntity, MensagemViewModel>();
            cfg.CreateMap<ProfileViewModel, UsuarioViewModel>().ReverseMap();
        }

        private static void Seguranca(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UsuarioViewModel, PrimeiroAcessoViewModel>().ReverseMap();
            cfg.CreateMap<UsuarioViewModel, ProfileViewModel>().ReverseMap();
            cfg.CreateMap<PrimeiroAcessoViewModel, UsuarioViewModel>().ReverseMap();
        }
    }
}

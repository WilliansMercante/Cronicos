using APS.Cronicos.Dominio.Cronicos.Entidades;
using APS.Cronicos.Dominio.Menu.Entidades;
using APS.Cronicos.Dominio.Seguranca.Entidades;
using APS.Cronicos.ViewModels.Cronicos;
using APS.Cronicos.ViewModels.Seguranca;

using AutoMapper;

using CorporativoDomain = APS.Cronicos.Dominio.Corporativo.Entidades;
using CorporativoViewModel = APS.Cronicos.ViewModels.Corporativo;

namespace APS.Cronicos.Aplicacao.Mappers
{
    public class MapperConfig
    {
        public static IMapper RegisterMappers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                Corporativo(cfg);
                Seguranca(cfg);
                ContratoGestao(cfg);
                Cronicos(cfg);
            });

            return config.CreateMapper();
        }

        private static void ContratoGestao(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Dominio.ContratoGestao.Entidades.ContratoEntity, ViewModels.ContratoGestao.ContratoViewModel>();
            cfg.CreateMap<Dominio.ContratoGestao.Entidades.SupervisaoEntity, ViewModels.ContratoGestao.SupervisaoViewModel>();
            cfg.CreateMap<Dominio.ContratoGestao.Entidades.UnidadeEntity, ViewModels.ContratoGestao.UnidadeViewModel>();
            cfg.CreateMap<Dominio.ContratoGestao.Entidades.SiglaEntity, ViewModels.ContratoGestao.SiglaViewModel>();
            cfg.CreateMap<Dominio.ContratoGestao.Entidades.ServicoEntity, ViewModels.ContratoGestao.ServicoViewModel>();
        }

        private static void Seguranca(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<MenuItemEntity, MenuViewModel>().ReverseMap();
            cfg.CreateMap<UsuarioEntity, UsuarioViewModel>().ReverseMap();
            cfg.CreateMap<GrupoEntity, GrupoViewModel>().ReverseMap();
            cfg.CreateMap<SistemaEntity, SistemaViewModel>().ReverseMap();
            cfg.CreateMap<UnidadeEntity, UnidadeViewModel>().ReverseMap();
        }

        private static void Corporativo(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CorporativoDomain.UnidadeEntity, CorporativoViewModel.UnidadeViewModel>().ReverseMap();
            cfg.CreateMap<CorporativoDomain.PacienteEntity, CorporativoViewModel.PacienteViewModel>().ReverseMap();
            cfg.CreateMap<CorporativoDomain.ProfissionalEntity, CorporativoViewModel.ProfissionalViewModel>().ReverseMap();
            cfg.CreateMap<CorporativoDomain.SexoEntity, CorporativoViewModel.SexoViewModel>().ReverseMap();
            cfg.CreateMap<CorporativoDomain.EquipeEntity, CorporativoViewModel.EquipeViewModel>().ReverseMap();
            cfg.CreateMap<CorporativoDomain.TipoEquipeEntity, CorporativoViewModel.TipoEquipeViewModel>().ReverseMap();
        }

        private static void Cronicos(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<AtendimentoEntity, AtendimentoViewModel>().ReverseMap();
            cfg.CreateMap<AvaliacaoRiscoEntity, AvaliacaoRiscoViewModel>().ReverseMap();
            cfg.CreateMap<EstratificacaoRiscoEntity, EstratificacaoRiscoViewModel>().ReverseMap();
            cfg.CreateMap<TipoAtendimentoEntity, TipoAtendimentoViewModel>().ReverseMap();
            cfg.CreateMap<TipoDiabetesEntity, TipoDiabetesViewModel>().ReverseMap();
            cfg.CreateMap<PacienteUnidadeEntity, PacienteUnidadeViewModel>().ReverseMap();
            cfg.CreateMap<DiagnosticoEntity, DiagnosticoViewModel>().ReverseMap();
        }
    }
}
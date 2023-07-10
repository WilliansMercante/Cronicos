using APS.Cronicos.Aplicacao.Corporativo;
using APS.Cronicos.Aplicacao.Corporativo.Interfaces;
using APS.Cronicos.Aplicacao.Cronicos;
using APS.Cronicos.Aplicacao.Cronicos.Interfaces;
using APS.Cronicos.Aplicacao.Seguranca;
using APS.Cronicos.Aplicacao.Seguranca.Interfaces;
using APS.Cronicos.Dominio.Configuracao.Repositories;
using APS.Cronicos.Dominio.Cronicos.Repositories;
using APS.Cronicos.Dominio.Interfaces;
using APS.Cronicos.Dominio.Mensagem.Repositories.Interfaces;
using APS.Cronicos.Dominio.Menu.Repositories.Interfaces;
using APS.Cronicos.Dominio.Parametrizacao.Repositories.Interfaces;
using APS.Cronicos.Dominio.Seguranca.Repositories.Interfaces;
using APS.Cronicos.Infra.Data.Contexts;
using APS.Cronicos.Infra.Data.Repositories.Configuracao;
using APS.Cronicos.Infra.Data.Repositories.Cronicos;
using APS.Cronicos.Infra.Data.Repositories.Mensagem;
using APS.Cronicos.Infra.Data.Repositories.Menu;
using APS.Cronicos.Infra.Data.Repositories.Parametro;
using APS.Cronicos.Infra.Data.Repositories.Seguranca;

using Microsoft.Extensions.DependencyInjection;

namespace APS.Cronicos.IoC.App_Start
{
    public static class InjectionDependencyCore
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            AddRepositories(services);
            AddServices(services);
            AddApplication(services);
        }

        private static void AddApplication(IServiceCollection services)
        {
            #region Corporativo

            services.AddScoped<IUnidadeApp, UnidadeApp>();
            services.AddScoped<IPacienteApp, PacienteApp>();
            services.AddScoped<IProfissionalApp, ProfissionalApp>();
            services.AddScoped<ISexoApp, SexoApp>();
            services.AddScoped<IEquipeApp, EquipeApp>();
            services.AddScoped<ITipoDiabetesApp, TipoDiabetesApp>();

            #endregion

            #region Contrato Gestão

            services.AddScoped<Aplicacao.ContratoGestao.Interfaces.ISupervisaoApp, Aplicacao.ContratoGestao.SupervisaoApp>();
            services.AddScoped<Aplicacao.ContratoGestao.Interfaces.IUnidadeApp, Aplicacao.ContratoGestao.UnidadeApp>();
            services.AddScoped<Aplicacao.ContratoGestao.Interfaces.IServicoApp, Aplicacao.ContratoGestao.ServicoApp>();

            #endregion

            #region Segurança

            services.AddScoped<IMenuApp, MenuApp>();
            services.AddScoped<IUsuarioApp, UsuarioApp>();

            #endregion

            #region Cronicos

            services.AddScoped<IAtendimentoApp, AtendimentoApp>();
            services.AddScoped<IAvaliacaoRiscoApp, AvaliacaoRiscoApp>();
            services.AddScoped<IEstratificacaoRiscoApp, EstratificacaoRiscoApp>();
            services.AddScoped<ITipoAtendimentoApp, TipoAtendimentoApp>();
            services.AddScoped<IPacienteUnidadeApp, PacienteUnidadeApp>();
            services.AddScoped<IDiagnosticoApp, DiagnosticoApp>();
            services.AddScoped<IRelatorioPacienteApp, RelatorioPacienteApp>();

            #endregion

        }

        private static void AddServices(IServiceCollection services)
        {
        }

        private static void AddRepositories(IServiceCollection services)
        {
            #region Configuracao

            services.AddScoped<IParametroRepository, ParametroRepository>();
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            services.AddScoped<IServicoIgnoradoRepository, ServicoIgnoradoRepository>();

            #endregion

            #region Mensagem

            services.AddScoped<IUnitOfWork<ConfiguracaoContext>, UnitOfWork<ConfiguracaoContext>>();
            services.AddScoped<IMensagemRepository, MensagemRepository>();
            services.AddScoped<IMensagemLidaRepository, MensagemLidaRepository>();

            #endregion

            #region Segurança

            services.AddScoped<IUnidadeRepository, UnidadeRepository>();
            services.AddScoped<IPrimeiroAcessoRepository, PrimeiroAcessoRepository>();
            services.AddScoped<ITrocarSenhaRepository, TrocarSenhaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ISistemaRepository, SistemaRepository>();

            #endregion

            #region Corporativo

            services.AddScoped<Dominio.Corporativo.Repositories.IUnidadeRepository, Infra.Data.Repositories.Corporativo.UnidadeRepository>();
            services.AddScoped<Dominio.Corporativo.Repositories.IPacienteRepository, Infra.Data.Repositories.Corporativo.PacienteRepository>();
            services.AddScoped<Dominio.Corporativo.Repositories.ISexoRepository, Infra.Data.Repositories.Corporativo.SexoRepository>();
            services.AddScoped<Dominio.Corporativo.Repositories.IProfissionalRepository, Infra.Data.Repositories.Corporativo.ProfissionalRepository>();
            services.AddScoped<Dominio.Corporativo.Repositories.IEquipeRepository, Infra.Data.Repositories.Corporativo.EquipeRepository>();

            #endregion

            #region Contrato Gestão

            services.AddScoped<Dominio.ContratoGestao.Repositories.Interfaces.ISupervisaoRepository, Infra.Data.Repositories.ContratoGestao.SupervisaoRepository>();
            services.AddScoped<Dominio.ContratoGestao.Repositories.Interfaces.IUnidadeRepository, Infra.Data.Repositories.ContratoGestao.UnidadeRepository>();
            services.AddScoped<Dominio.ContratoGestao.Repositories.Interfaces.IServicoRepository, Infra.Data.Repositories.ContratoGestao.ServicoRepository>();

            #endregion

            #region Cronicos

            services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
            services.AddScoped<IAvaliacaoRiscoRepository, AvaliacaoRiscoRepository>();
            services.AddScoped<IEstratificacaoRiscoRepository, EstratificacaoRiscoRepository>();
            services.AddScoped<ITipoAtendimentoRepository, TipoAtendimentoRepository>();
            services.AddScoped<ITipoDiabetesRepository, TipoDiabetesRepository>();
            services.AddScoped<IPacienteUnidadeRepository, PacienteUnidadeRepository>();
            services.AddScoped<IDiagnosticoRepository, DiagnosticoRepository>();

            #endregion

            services.AddScoped<IUnitOfWork<CronicosContext>, UnitOfWork<CronicosContext>>();
        }
    }
}

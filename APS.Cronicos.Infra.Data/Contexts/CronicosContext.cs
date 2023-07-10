using APS.Cronicos.Dominio.Configuracao.Entidades;
using APS.Cronicos.Dominio.Cronicos.Entidades;
using APS.Cronicos.Dominio.Interfaces;
using APS.Cronicos.Dominio.Log.Entidades;
using APS.Cronicos.Infra.Data.Mappings.Configuracao;
using APS.Cronicos.Infra.Data.Mappings.Cronicos;
using APS.Cronicos.Infra.Data.Mappings.Log;

using Microsoft.EntityFrameworkCore;

namespace APS.Cronicos.Infra.Data.Contexts
{
    public sealed class CronicosContext : DbContext, IUnitOfWork<CronicosContext>
    {
        public CronicosContext(DbContextOptions<CronicosContext> options) : base(options)
        {

        }

        #region Cronicos

        public DbSet<AtendimentoEntity> Atendimento { get; set; }
        public DbSet<AvaliacaoRiscoEntity> AvaliacaoRisco { get; set; }
        public DbSet<EstratificacaoRiscoEntity> EstratificacaoRisco { get; set; }
        public DbSet<TipoAtendimentoEntity> TipoAtendimento { get; set; }
        public DbSet<TipoDiabetesEntity> TipoDiabetes { get; set; }
        public DbSet<PacienteUnidadeEntity> PacienteUnidade { get; set; }
        public DbSet<DiagnosticoEntity> Diagnostico { get; set; }

        #endregion

        #region Configurações
        public DbSet<ServicoIgnoradoEntity> ServicoIgnorado { get; set; }

        #endregion

        #region Log
        public DbSet<LogEntity> Log { get; set; }

        #endregion

        #region Mapeamentos

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModuloLog(modelBuilder);
            ModuloConfiguracao(modelBuilder);
            ModuloCronicos(modelBuilder);
        }

        private static void ModuloConfiguracao(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ServicoIgnoradoMapping());
        }
        private static void ModuloLog(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LogMapping());
        }
        private static void ModuloCronicos(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtendimentoMapping());
            modelBuilder.ApplyConfiguration(new AvaliacaoRiscoMapping());
            modelBuilder.ApplyConfiguration(new EstratificacaoRiscoMapping());
            modelBuilder.ApplyConfiguration(new TipoAtendimentoMapping());
            modelBuilder.ApplyConfiguration(new TipoDiabetesMapping());
            modelBuilder.ApplyConfiguration(new PacienteUnidadeMapping());
            modelBuilder.ApplyConfiguration(new DiagnosticoMapping());
        }

        #endregion

        public void Commit()
        {
            SaveChanges();
        }
    }
}
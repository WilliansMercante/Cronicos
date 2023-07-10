using APS.Cronicos.Infra.Data.Mappings.Log;
using APS.Cronicos.Infra.Data.Mappings.Mensagem;
using APS.Cronicos.Infra.Data.Mappings.Menu;
using APS.Cronicos.Infra.Data.Mappings.Parametrizacao;
using APS.Cronicos.Dominio.Interfaces;
using APS.Cronicos.Dominio.Log.Entidades;
using APS.Cronicos.Dominio.Mensagem.Entidades;
using APS.Cronicos.Dominio.Menu.Entidades;
using APS.Cronicos.Dominio.Parametrizacao.Entidades;
using Microsoft.EntityFrameworkCore;

namespace APS.Cronicos.Infra.Data.Contexts
{
    public sealed class ConfiguracaoContext : DbContext, IUnitOfWork<ConfiguracaoContext>
    {
        public ConfiguracaoContext(DbContextOptions<ConfiguracaoContext> options) : base(options)
        {

        }

        public DbSet<MenuItemEntity> MenuItem { get; set; }
        public DbSet<PermissaoMenuItemEntity> PermissaoMenuItem { get; set; }
        public DbSet<ParametroEntity> Parametro { get; set; }
        public DbSet<ParametroGrupoEntity> ParametroGrupo { get; set; }
        public DbSet<LogEntity> Log { get; set; }
        public DbSet<MensagemEntity> Mensagem { get; set; }
        public DbSet<MensagemLidaEntity> MensagemLida { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MenuItemMapping());
            modelBuilder.ApplyConfiguration(new PermissaoMenuItemMapping());
            modelBuilder.ApplyConfiguration(new ParametroMapping());
            modelBuilder.ApplyConfiguration(new ParametroGrupoMapping());
            modelBuilder.ApplyConfiguration(new LogMapping());
            modelBuilder.ApplyConfiguration(new MensagemLidaMapping());

            base.OnModelCreating(modelBuilder);
        }

        public void Commit()
        {
            SaveChanges();
        }
    }
}

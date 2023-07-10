using APS.Cronicos.Dominio.Menu.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APS.Cronicos.Infra.Data.Mappings.Menu
{
    internal sealed class PermissaoMenuItemMapping : IEntityTypeConfiguration<PermissaoMenuItemEntity>
    {
        public void Configure(EntityTypeBuilder<PermissaoMenuItemEntity> builder)
        {
            builder.ToTable("TB_PERMISSAO_ITEM_MENU", "config");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_PERMISSAO_ITEM_MENU");
            builder.Property(p => p.IdMenuItem).HasColumnName("ID_MENU_ITEM");
            builder.Property(p => p.IdGrupo).HasColumnName("ID_GRUPO");

            builder.HasOne(p => p.MenuItem)
                .WithMany()
                .HasForeignKey(p => p.IdMenuItem);
        }
    }
}

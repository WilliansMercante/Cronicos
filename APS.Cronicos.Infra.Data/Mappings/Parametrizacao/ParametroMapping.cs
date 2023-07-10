using APS.Cronicos.Dominio.Parametrizacao.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APS.Cronicos.Infra.Data.Mappings.Parametrizacao
{
    internal sealed class ParametroMapping : IEntityTypeConfiguration<ParametroEntity>
    {
        public void Configure(EntityTypeBuilder<ParametroEntity> builder)
        {
            builder.ToTable("TB_PARAMETRO", "config");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_PARAMETRO");
            builder.Property(p => p.DsParametro).HasColumnName("DS_PARAMETRO");
            builder.Property(p => p.Observacao).HasColumnName("DS_OBSERVACAO");
        }
    }
}

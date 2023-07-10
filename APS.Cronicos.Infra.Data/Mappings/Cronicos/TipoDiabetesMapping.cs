using APS.Cronicos.Dominio.Cronicos.Entidades;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APS.Cronicos.Infra.Data.Mappings.Cronicos
{
    internal sealed class TipoDiabetesMapping : IEntityTypeConfiguration<TipoDiabetesEntity>
    {
        public void Configure(EntityTypeBuilder<TipoDiabetesEntity> builder)
        {
            builder.ToTable("TB_TIPO_DIABETES", "atendimento");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_TIPO_DIABETES");
            builder.Property(p => p.TipoDiabetes).HasColumnName("DS_TIPO_DIABETES");
            builder.Property(p => p.DtCadastro).HasColumnName("DT_CADASTRO");
        }
    }
}

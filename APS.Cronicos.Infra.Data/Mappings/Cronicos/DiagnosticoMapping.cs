using APS.Cronicos.Dominio.Cronicos.Entidades;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APS.Cronicos.Infra.Data.Mappings.Cronicos
{
    internal sealed class DiagnosticoMapping : IEntityTypeConfiguration<DiagnosticoEntity>
    {
        public void Configure(EntityTypeBuilder<DiagnosticoEntity> builder)
        {
            builder.ToTable("TB_DIAGNOSTICO", "unidade");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_DIAGNOSTICO");
            builder.Property(p => p.Diagnostico).HasColumnName("DS_DIAGNOSTICO");
            builder.Property(p => p.DtCadastro).HasColumnName("DT_CADASTRO");
            builder.Property(p => p.FlAtivo).HasColumnName("FL_ATIVO");
        }
    }
}

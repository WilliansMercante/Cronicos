using APS.Cronicos.Dominio.Cronicos.Entidades;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APS.Cronicos.Infra.Data.Mappings.Cronicos
{
    internal sealed class TipoAtendimentoMapping : IEntityTypeConfiguration<TipoAtendimentoEntity>
    {
        public void Configure(EntityTypeBuilder<TipoAtendimentoEntity> builder)
        {
            builder.ToTable("TB_TIPO_ATENDIMENTO", "atendimento");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_TIPO_ATENDIMENTO");
            builder.Property(p => p.TipoAtendimento).HasColumnName("DS_TIPO_ATENDIMENTO");
            builder.Property(p => p.Sigla).HasColumnName("SIGLA");
            builder.Property(p => p.DtCadastro).HasColumnName("DT_CADASTRO");
        }
    }
}

using APS.Cronicos.Dominio.Cronicos.Entidades;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APS.Cronicos.Infra.Data.Mappings.Cronicos
{
    internal sealed class EstratificacaoRiscoMapping : IEntityTypeConfiguration<EstratificacaoRiscoEntity>
    {
        public void Configure(EntityTypeBuilder<EstratificacaoRiscoEntity> builder)
        {
            builder.ToTable("TB_ESTRATIFICACAO_RISCO", "atendimento");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_ESTRATIFICACAO_RISCO");
            builder.Property(p => p.EstratificacaoRisco).HasColumnName("DS_ESTRATIFICACAO_RISCO");
            builder.Property(p => p.DtCadastro).HasColumnName("DT_CADASTRO");
            builder.Property(p => p.FlAtivo).HasColumnName("FL_ATIVO");
        }
    }
}

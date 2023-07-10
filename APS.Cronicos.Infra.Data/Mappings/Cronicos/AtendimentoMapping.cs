using APS.Cronicos.Dominio.Cronicos.Entidades;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APS.Cronicos.Infra.Data.Mappings.Cronicos
{
    internal sealed class AtendimentoMapping : IEntityTypeConfiguration<AtendimentoEntity>
    {
        public void Configure(EntityTypeBuilder<AtendimentoEntity> builder)
        {
            builder.ToTable("TB_ATENDIMENTO", "atendimento");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_ATENDIMENTO");
            builder.Property(p => p.IdTipoAtendimento).HasColumnName("ID_TIPO_ATENDIMENTO");
            builder.Property(p => p.IdUnidade).HasColumnName("ID_UNIDADE");
            builder.Property(p => p.CnsPaciente).HasColumnName("NR_CNS_PACIENTE");
            builder.Property(p => p.DtReferencia).HasColumnName("DT_REFERENCIA");
            builder.Property(p => p.DtCadastro).HasColumnName("DT_CADASTRO");

            builder.HasOne(p => p.TipoAtendimento).WithMany().HasForeignKey(p => p.IdTipoAtendimento);
        }
    }
}

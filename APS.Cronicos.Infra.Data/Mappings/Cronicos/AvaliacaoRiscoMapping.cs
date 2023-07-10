using APS.Cronicos.Dominio.Cronicos.Entidades;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APS.Cronicos.Infra.Data.Mappings.Cronicos
{
    internal sealed class AvaliacaoRiscoMapping : IEntityTypeConfiguration<AvaliacaoRiscoEntity>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoRiscoEntity> builder)
        {
            builder.ToTable("TB_AVALIACAO_RISCO", "atendimento");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_AVALIACAO_RISCO");
            builder.Property(p => p.IdEstratificacaoRisco).HasColumnName("ID_ESTRATIFICACAO_RISCO");
            builder.Property(p => p.IdUnidade).HasColumnName("ID_UNIDADE");
            builder.Property(p => p.CnsPaciente).HasColumnName("NR_CNS_PACIENTE");
            builder.Property(p => p.Peso).HasColumnName("PESO");
            builder.Property(p => p.Altura).HasColumnName("ALTURA");
            builder.Property(p => p.DtEstratificacao).HasColumnName("DT_ESTRATIFICACAO");
            builder.Property(p => p.Observacao).HasColumnName("DS_OBSERVACAO");
            builder.Property(p => p.DtCadastro).HasColumnName("DT_CADASTRO");
            builder.Property(p => p.IdTipoDiabetes).HasColumnName("ID_TIPO_DIABETES");
            builder.Property(p => p.FlAmg).HasColumnName("FL_AMG");
            builder.Property(p => p.FlInsulinoDependente).HasColumnName("FL_INSULINO_DEPENDENTE");
            builder.Property(p => p.DtAvaliacaoPes).HasColumnName("DT_ULTIMA_AVALIACAO_PES");
            builder.Property(p => p.DtUltimolaudo).HasColumnName("DT_ULTIMO_LAUDO");

            builder.HasOne(p => p.EstratificacaoRisco).WithMany().HasForeignKey(p => p.IdEstratificacaoRisco);
            builder.HasOne(p => p.TipoDiabetes).WithMany().HasForeignKey(p => p.IdTipoDiabetes);
        }
    }
}

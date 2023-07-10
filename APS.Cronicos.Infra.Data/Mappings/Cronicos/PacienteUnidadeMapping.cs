using APS.Cronicos.Dominio.Cronicos.Entidades;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APS.Cronicos.Infra.Data.Mappings.Cronicos
{
    internal sealed class PacienteUnidadeMapping : IEntityTypeConfiguration<PacienteUnidadeEntity>
    {
        public void Configure(EntityTypeBuilder<PacienteUnidadeEntity> builder)
        {
            builder.ToTable("TB_PACIENTE_UNIDADE", "unidade");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_PACIENTE_UNIDADE");
            builder.Property(p => p.IdEquipe).HasColumnName("ID_EQUIPE");
            builder.Property(p => p.NomeEquipe).HasColumnName("NM_EQUIPE");
            builder.Property(p => p.IdUnidade).HasColumnName("ID_UNIDADE");
            builder.Property(p => p.IdDiagnostico).HasColumnName("ID_DIAGNOSTICO");
            builder.Property(p => p.CnsPaciente).HasColumnName("NR_CNS_PACIENTE");
            builder.Property(p => p.CpfEnfermeiro).HasColumnName("NR_CPF_ENFERMEIRO");
            builder.Property(p => p.NomeEnfermeiro).HasColumnName("NM_ENFERMEIRO");
            builder.Property(p => p.CpfMedico).HasColumnName("NR_CPF_MEDICO");
            builder.Property(p => p.NomeMedico).HasColumnName("NM_MEDICO");
            builder.Property(p => p.Prontuario).HasColumnName("NR_PRONTUARIO");
            builder.Property(p => p.DtCadastro).HasColumnName("DT_CADASTRO");
            builder.Property(p => p.FlForaDeArea).HasColumnName("FL_FORA_AREA");
            builder.Ignore(p => p.ValidarUnidade);

            builder.HasOne(p => p.Diagnostico).WithMany().HasForeignKey(p => p.IdDiagnostico);
        }
    }
}

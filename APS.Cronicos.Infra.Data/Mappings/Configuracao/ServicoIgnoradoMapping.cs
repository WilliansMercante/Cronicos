using APS.Cronicos.Dominio.Configuracao.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APS.Cronicos.Infra.Data.Mappings.Configuracao
{
    internal sealed class ServicoIgnoradoMapping : IEntityTypeConfiguration<ServicoIgnoradoEntity>
    {
        public void Configure(EntityTypeBuilder<ServicoIgnoradoEntity> builder)
        {
            builder.ToTable("TB_SERVICO_IGNORADO", "config");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_SERVICO_IGNORADO");
            builder.Property(p => p.IdServico).HasColumnName("ID_SERVICO");
        }
    }
}

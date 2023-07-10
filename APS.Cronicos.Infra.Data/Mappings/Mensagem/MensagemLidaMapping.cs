using APS.Cronicos.Dominio.Mensagem.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APS.Cronicos.Infra.Data.Mappings.Mensagem
{
    internal sealed class MensagemLidaMapping : IEntityTypeConfiguration<MensagemLidaEntity>
    {
        public void Configure(EntityTypeBuilder<MensagemLidaEntity> builder)
        {
            builder.ToTable("TB_MENSAGEM_LIDA", "config");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_MENSAGEM_LIDA");
            builder.Property(p => p.IdMensagem).HasColumnName("ID_MENSAGEM");
            builder.Property(p => p.IdUsuario).HasColumnName("ID_USUARIO");

            builder.HasOne(p => p.Mensagem)
                .WithMany()
                .HasForeignKey(p => p.IdMensagem);
        }
    }
}

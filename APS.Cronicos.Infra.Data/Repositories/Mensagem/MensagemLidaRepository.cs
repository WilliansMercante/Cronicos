using APS.Cronicos.Dominio.Mensagem.Entidades;
using APS.Cronicos.Dominio.Mensagem.Repositories.Interfaces;
using APS.Cronicos.Infra.Data.Contexts;

namespace APS.Cronicos.Infra.Data.Repositories.Mensagem
{
    public sealed class MensagemLidaRepository : RepositoryBase<MensagemLidaEntity, ConfiguracaoContext>, IMensagemLidaRepository
    {
        public MensagemLidaRepository(ConfiguracaoContext context) : base(context)
        {
        }
    }
}

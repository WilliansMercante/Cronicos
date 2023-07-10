using APS.Cronicos.Dominio.Configuracao.Entidades;
using APS.Cronicos.Dominio.Configuracao.Repositories;
using APS.Cronicos.Infra.Data.Contexts;

namespace APS.Cronicos.Infra.Data.Repositories.Configuracao
{
    public sealed class ServicoIgnoradoRepository : RepositoryBase<ServicoIgnoradoEntity, CronicosContext>, IServicoIgnoradoRepository
    {
        public ServicoIgnoradoRepository(CronicosContext context) : base(context)
        {
        }
    }
}

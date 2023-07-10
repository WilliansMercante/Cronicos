using APS.Cronicos.Dominio.Cronicos.Entidades;
using APS.Cronicos.Dominio.Cronicos.Repositories;
using APS.Cronicos.Infra.Data.Contexts;

using System.Collections.Generic;
using System.Linq;

namespace APS.Cronicos.Infra.Data.Repositories.Cronicos
{
    public sealed class EstratificacaoRiscoRepository : RepositoryBase<EstratificacaoRiscoEntity, CronicosContext>, IEstratificacaoRiscoRepository
    {
        public EstratificacaoRiscoRepository(CronicosContext context) : base(context)
        {
        }

        public IEnumerable<EstratificacaoRiscoEntity> ListarAtivos()
        {
            return _context.EstratificacaoRisco.Where(p => p.FlAtivo);
        }
    }
}

using APS.Cronicos.Dominio.Cronicos.Entidades;
using APS.Cronicos.Dominio.Cronicos.Repositories;
using APS.Cronicos.Infra.Data.Contexts;

namespace APS.Cronicos.Infra.Data.Repositories.Cronicos
{
    public sealed class TipoDiabetesRepository : RepositoryBase<TipoDiabetesEntity, CronicosContext>, ITipoDiabetesRepository
    {
        public TipoDiabetesRepository(CronicosContext context) : base(context)
        {
        }
    }
}

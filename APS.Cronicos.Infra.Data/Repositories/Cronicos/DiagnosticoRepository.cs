using APS.Cronicos.Dominio.Cronicos.Entidades;
using APS.Cronicos.Dominio.Cronicos.Repositories;
using APS.Cronicos.Infra.Data.Contexts;

using System.Collections.Generic;
using System.Linq;

namespace APS.Cronicos.Infra.Data.Repositories.Cronicos
{
    public sealed class DiagnosticoRepository : RepositoryBase<DiagnosticoEntity, CronicosContext>, IDiagnosticoRepository
    {
        public DiagnosticoRepository(CronicosContext context) : base(context)
        {
        }

        public override IEnumerable<DiagnosticoEntity> Listar()
        {
            return _context.Diagnostico.Where(p => p.FlAtivo);
        }

    }
}

using APS.Cronicos.Dominio.Parametrizacao.Entidades;
using APS.Cronicos.Dominio.Parametrizacao.Repositories.Interfaces;
using APS.Cronicos.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APS.Cronicos.Infra.Data.Repositories.Parametro
{
    public sealed class ParametroRepository : RepositoryBase<ParametroEntity, ConfiguracaoContext>, IParametroRepository
    {
        public ParametroRepository(ConfiguracaoContext context) : base(context)
        {
        }

        public bool Permitido(int idGrupo, string item)
        {
            return _context.ParametroGrupo
                           .Include(p => p.Parametro)
                           .Where(p => p.IdGrupo.Equals(idGrupo) &&
                                       p.Parametro.DsParametro.Equals(item))
                           .FirstOrDefault() != null;
        }
        public ParametroEntity ConsultarPorNome(string nome)
        {
            return _context.Parametro
                           .FirstOrDefault(p => p.DsParametro.Equals(nome));
        }
    }
}

using APS.Cronicos.Dominio.Cronicos.Entidades;
using APS.Cronicos.Dominio.Cronicos.Repositories;
using APS.Cronicos.Infra.Data.Contexts;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

namespace APS.Cronicos.Infra.Data.Repositories.Cronicos
{
    public sealed class AtendimentoRepository : RepositoryBase<AtendimentoEntity, CronicosContext>, IAtendimentoRepository
    {
        public AtendimentoRepository(CronicosContext context) : base(context)
        {
        }

        public IEnumerable<AtendimentoEntity> ListarPorCnsUnidade(string cns, int idUnidade)
        {
            return _context.Atendimento
                                       .Include(p => p.TipoAtendimento)
                                       .Where(p => p.CnsPaciente.Equals(cns) &&
                                       p.IdUnidade.Equals(idUnidade));
        }

        public IEnumerable<AtendimentoEntity> ListarPorUnidade(int idUnidade)
        {
            return _context.Atendimento.Where(p => p.IdUnidade.Equals(idUnidade));
        }

        public override AtendimentoEntity ConsultarPorId(int id)
        {
            return _context.Atendimento
                                       .Include(p => p.TipoAtendimento)
                                       .FirstOrDefault(p => p.Id.Equals(id));
        }

        public override void Atualizar(AtendimentoEntity obj)
        {
            base.Atualizar(obj);
            _context.Entry(obj).Property(p => p.DtCadastro).IsModified = false;
        }
    }
}

using APS.Cronicos.Dominio.Cronicos.Entidades;
using APS.Cronicos.Dominio.Cronicos.Repositories;
using APS.Cronicos.Infra.Data.Contexts;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

namespace APS.Cronicos.Infra.Data.Repositories.Cronicos
{
    public sealed class AvaliacaoRiscoRepository : RepositoryBase<AvaliacaoRiscoEntity, CronicosContext>, IAvaliacaoRiscoRepository
    {
        public AvaliacaoRiscoRepository(CronicosContext context) : base(context)
        {
        }

        public override AvaliacaoRiscoEntity ConsultarPorId(int id)
        {
            return _context.AvaliacaoRisco
                .Include(p => p.EstratificacaoRisco)
                .Include(p => p.TipoDiabetes)
                .FirstOrDefault(p => p.Id.Equals(id));                
        }

        public IEnumerable<AvaliacaoRiscoEntity> ListarPorData(DateTime dtInicio, DateTime dtFim)
        {
            return _context.AvaliacaoRisco.Where(p => p.DtCadastro >= dtInicio && p.DtCadastro <= dtFim);
        }

        public AvaliacaoRiscoEntity ConsultarPorCnsUnidade(string cns, int idUnidade)
        {
            return _context.AvaliacaoRisco
                                          .Include(p => p.EstratificacaoRisco)
                                          .FirstOrDefault(p => p.CnsPaciente.Equals(cns) && 
                                          p.IdUnidade.Equals(idUnidade));
        }

        public IEnumerable<AvaliacaoRiscoEntity> ListarPorCnsUnidade(string cns, int idUnidade)
        {
            return _context.AvaliacaoRisco
                                          .Include(p => p.EstratificacaoRisco)
                                          .Include(p => p.TipoDiabetes)
                                          .Where(p => p.CnsPaciente.Equals(cns) && 
                                          p.IdUnidade.Equals(idUnidade))
                                          .ToList();
        }

        public override void Atualizar(AvaliacaoRiscoEntity obj)
        {
            base.Atualizar(obj);
            _context.Entry(obj).Property(p => p.DtCadastro).IsModified = false;
        }
    }
}

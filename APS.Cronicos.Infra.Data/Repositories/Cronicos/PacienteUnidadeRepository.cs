using APS.Cronicos.Dominio.Cronicos.Entidades;
using APS.Cronicos.Dominio.Cronicos.Repositories;
using APS.Cronicos.Dominio.ValueObjects;
using APS.Cronicos.Infra.Data.Contexts;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

namespace APS.Cronicos.Infra.Data.Repositories.Cronicos
{
    public sealed class PacienteUnidadeRepository : RepositoryBase<PacienteUnidadeEntity, CronicosContext>, IPacienteUnidadeRepository
    {
        public PacienteUnidadeRepository(CronicosContext context) : base(context)
        {
        }

        public PacienteUnidadeEntity ConsultarPorCns(string cns)
        {
            return _context.PacienteUnidade
                                           .Include(p => p.Diagnostico)
                                           .FirstOrDefault(p => p.CnsPaciente.Equals(cns));
        }

        public PacienteUnidadeEntity ConsultarPorCnsUnidade(string cns, int idUnidade)
        {
            return _context.PacienteUnidade
                                           .Include(p => p.Diagnostico)
                                           .FirstOrDefault(p => p.CnsPaciente.Equals(cns) &&
                                           p.IdUnidade.Equals(idUnidade)
                                           );
        }

        public override void Atualizar(PacienteUnidadeEntity obj)
        {
            base.Atualizar(obj);
            _context.Entry(obj).Property(p => p.DtCadastro).IsModified = false;
        }

        public bool PossuiDiabetes(string cns)
        {
            var oPacienteUnidade = _context.PacienteUnidade.FirstOrDefault(p => p.CnsPaciente.Equals(cns));

            if (oPacienteUnidade.IdDiagnostico.Equals((int)DiagnosticoVO.DM) || oPacienteUnidade.IdDiagnostico.Equals((int)DiagnosticoVO.HAS_DM))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<PacienteUnidadeEntity> ListarPorCnes(int cnes)
        {
            return _context.PacienteUnidade.Where(p => p.IdUnidade.Equals(cnes));
        }

        public IEnumerable<PacienteUnidadeEntity> ListarPorFiltro
        (
            int idUnidade, 
            bool flForaDeArea, 
            string prontuario,              
            string cpfEnfermeiro, 
            string cpfMedico,
            int? idEquipe,
            int? idDiagnostico
        )
        {
            return _context.PacienteUnidade
                                           .Include(p => p.Diagnostico)
                                           .Where(p => p.IdUnidade.Equals(idUnidade) &&
                                                 (idEquipe == null || idEquipe.Equals(0) || p.IdEquipe.Equals(idEquipe)) &&
                                                 (idDiagnostico == null || idDiagnostico.Equals(0) || p.IdDiagnostico.Equals(idDiagnostico)) &&
                                                 (cpfMedico == null || cpfMedico ==string.Empty || p.CpfMedico.Equals(cpfMedico)) &&
                                                 (cpfEnfermeiro == null || cpfEnfermeiro == string.Empty || p.CpfEnfermeiro.Equals(cpfEnfermeiro)) &&
                                                 (prontuario == null || prontuario == string.Empty || p.Prontuario.Equals(prontuario)) &&
                                                 (flForaDeArea == false || p.FlForaDeArea.Equals(flForaDeArea)))
                                           .ToList();
        }
    }
}

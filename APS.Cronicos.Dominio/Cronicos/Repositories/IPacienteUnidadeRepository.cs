using APS.Cronicos.Dominio.Cronicos.Entidades;

using System.Collections.Generic;

namespace APS.Cronicos.Dominio.Cronicos.Repositories
{
    public interface IPacienteUnidadeRepository
    {
        void Incluir(PacienteUnidadeEntity obj);
        void Atualizar(PacienteUnidadeEntity obj);
        PacienteUnidadeEntity ConsultarPorId(int id);
        PacienteUnidadeEntity ConsultarPorCns(string cns);
        PacienteUnidadeEntity ConsultarPorCnsUnidade(string cns, int idUnidade);
        void Excluir(int id);
        bool PossuiDiabetes(string cns);
        IEnumerable<PacienteUnidadeEntity> Listar();
        IEnumerable<PacienteUnidadeEntity> ListarPorCnes(int cnes);
        IEnumerable<PacienteUnidadeEntity> ListarPorFiltro
        (
            int idUnidade,
            bool flForaDeArea,
            string prontuario,
            string cpfEnfermeiro,
            string cpfMedico,
            int? idEquipe = null,
            int? idDiagnostico = null
        );
    }
}

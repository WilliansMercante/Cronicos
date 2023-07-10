using APS.Cronicos.ViewModels.Cronicos;

using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.Cronicos.Interfaces
{
    public interface IPacienteUnidadeApp
    {
        int Incluir(PacienteUnidadeViewModel obj);
        void Atualizar(PacienteUnidadeViewModel obj);
        PacienteUnidadeViewModel ConsultarPorId(int id);
        PacienteUnidadeViewModel ConsultarPorCns(string cns);
        PacienteUnidadeViewModel ConsultarPorCnsUnidade(string cns, int idUnidade);
        void Excluir(int id);
        bool PossuiDiabetes(string cns);
        IEnumerable<PacienteUnidadeViewModel> Listar();
        IEnumerable<PacienteUnidadeViewModel> ListarPorCnes(int cnes);
        IEnumerable<PacienteUnidadeViewModel> ListarPorFiltro
        (
            int idUnidade, 
            bool flForaDeArea, 
            string prontuario, 
            string cpfEnfermeiro, 
            string cpfMedico, 
            int? idEquipe, 
            int? idDiagnostico
        );
    }
}

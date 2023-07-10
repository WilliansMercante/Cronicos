using APS.Cronicos.ViewModels.Cronicos;

using System;
using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.Cronicos.Interfaces
{
    public interface IAtendimentoApp
    {
        void Incluir(AtendimentoViewModel obj);
        void Atualizar(AtendimentoViewModel obj);
        AtendimentoViewModel ConsultarPorId(int id);
        IEnumerable<AtendimentoViewModel> ListarPorCnsUnidade(string cns, int idUnidade);
        void Excluir(int id);
        IEnumerable<AtendimentoViewModel> Listar();
        IEnumerable<AtendimentoViewModel> ListarPorUnidade(int idUnidade);
        IEnumerable<AtendimentoViewModel> RptAtendimento
        (
            int IdUnidadeSelecionada,
            bool flPacientesSemAtendimento,
            string cnsPaciente,
            int? idTipoAtendimento,
            DateTime? dtInicioAtendimento,
            DateTime? dtFimAtendimento
        );
    }
}

using APS.Cronicos.ViewModels.Cronicos;

using System;
using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.Cronicos.Interfaces
{
    public interface IAvaliacaoRiscoApp
    {
        void Incluir(AvaliacaoRiscoViewModel obj);
        void Atualizar(AvaliacaoRiscoViewModel obj);
        AvaliacaoRiscoViewModel ConsultarPorId(int id);
        AvaliacaoRiscoViewModel ConsultarPorCnsUnidade(string cns,int idUnidade);
        void Excluir(int id);
        IEnumerable<AvaliacaoRiscoViewModel> Listar();
        IEnumerable<AvaliacaoRiscoViewModel> ListarPorData(DateTime dtInicial, DateTime dtFinal);
        IEnumerable<AvaliacaoRiscoViewModel> ListarPorCnsUnidade(string cns, int idUnidade);
    }
}

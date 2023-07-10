using APS.Cronicos.ViewModels.ContratoGestao;
using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.ContratoGestao.Interfaces
{
    public interface IUnidadeApp
    {
        IEnumerable<UnidadeViewModel> ListarUnidades(bool flListarTodasUnidades, List<int> lstCnesUnidades);
        UnidadeViewModel ObterPorCnes(string cnes);
        UnidadeViewModel ObterUnidade(int idUnidade);
        IEnumerable<UnidadeViewModel> ListarPorSupervisao(int idSupervisao);
    }
}
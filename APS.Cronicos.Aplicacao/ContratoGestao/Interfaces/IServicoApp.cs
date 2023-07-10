using APS.Cronicos.ViewModels.ContratoGestao;
using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.ContratoGestao.Interfaces
{
    public interface IServicoApp
    {
        IEnumerable<ServicoViewModel> Listar(int idUnidade);
        ServicoViewModel Obter(int idUnidade, int idServico);
    }
}
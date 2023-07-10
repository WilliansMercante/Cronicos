using APS.Cronicos.ViewModels.Corporativo;

using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.Corporativo.Interfaces
{
    public interface IUnidadeApp
    {
        IEnumerable<UnidadeViewModel> Listar();
        public UnidadeViewModel ObterUnidade(int idUnidade);
    }
}

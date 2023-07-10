using APS.Cronicos.ViewModels.Corporativo;

using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.Corporativo.Interfaces
{
    public interface ISexoApp
    {
        IEnumerable<SexoViewModel> Listar();
    }
}

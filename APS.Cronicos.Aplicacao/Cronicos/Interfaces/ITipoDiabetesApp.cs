using APS.Cronicos.ViewModels.Cronicos;

using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.Cronicos.Interfaces
{
    public interface ITipoDiabetesApp
    {
        IEnumerable<TipoDiabetesViewModel> Listar();
    }
}

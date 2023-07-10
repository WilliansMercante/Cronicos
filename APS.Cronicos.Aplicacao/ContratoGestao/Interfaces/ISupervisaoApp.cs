using APS.Cronicos.ViewModels.ContratoGestao;
using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.ContratoGestao.Interfaces
{
    public interface ISupervisaoApp
    {
        public IEnumerable<SupervisaoViewModel> Listar();
        SupervisaoViewModel ConsultarPorId(int idSupervisao);
    }
}

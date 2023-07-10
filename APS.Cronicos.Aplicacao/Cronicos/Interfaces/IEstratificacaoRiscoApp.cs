using APS.Cronicos.ViewModels.Cronicos;

using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.Cronicos.Interfaces
{
    public interface IEstratificacaoRiscoApp
    {
        void Incluir(EstratificacaoRiscoViewModel obj);
        void Atualizar(EstratificacaoRiscoViewModel obj);
        EstratificacaoRiscoViewModel ConsultarPorId(int id);
        void Excluir(int id);
        IEnumerable<EstratificacaoRiscoViewModel> Listar();
        IEnumerable<EstratificacaoRiscoViewModel> ListarAtivos();
    }
}

using APS.Cronicos.ViewModels.Cronicos;

using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.Cronicos.Interfaces
{
    public interface ITipoAtendimentoApp
    {
        void Incluir(TipoAtendimentoViewModel obj);
        void Atualizar(TipoAtendimentoViewModel obj);
        TipoAtendimentoViewModel ConsultarPorId(int id);
        void Excluir(int id);
        IEnumerable<TipoAtendimentoViewModel> Listar();
    }
}

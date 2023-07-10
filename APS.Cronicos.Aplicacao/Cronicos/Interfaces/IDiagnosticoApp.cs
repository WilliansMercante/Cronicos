using APS.Cronicos.ViewModels.Cronicos;

using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.Cronicos.Interfaces
{
    public interface IDiagnosticoApp
    {
        void Incluir(DiagnosticoViewModel obj);
        void Atualizar(DiagnosticoViewModel obj);
        DiagnosticoViewModel ConsultarPorId(int id);
        void Excluir(int id);
        IEnumerable<DiagnosticoViewModel> Listar();
    }
}

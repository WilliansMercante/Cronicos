using APS.Cronicos.ViewModels.Corporativo;

using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.Corporativo.Interfaces
{
    public interface IProfissionalApp
    {
        ProfissionalViewModel ConsultarPorCPF(string cpf);
        IEnumerable<ProfissionalViewModel> ListarPorCargo(int idUnidade, string idCargo);
        IEnumerable<ProfissionalViewModel> ListarMedicosPorUnidade(int idUnidade);
        IEnumerable<ProfissionalViewModel> ListarEnfermeirosPorUnidade(int idUnidade);
        IEnumerable<ProfissionalViewModel> ListarProfissionaisPorUnidade(int idUnidade);
        IEnumerable<ProfissionalViewModel> ListarMedicosPorEquipeUnidade(int idEquipe,int idUnidade);
        IEnumerable<ProfissionalViewModel> ListarEnfermeirosPorEquipeUnidade(int idEquipe,int idUnidade);
    }
}

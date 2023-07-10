using APS.Cronicos.Dominio.Corporativo.Entidades;

using System.Collections.Generic;

namespace APS.Cronicos.Dominio.Corporativo.Repositories
{
    public interface IProfissionalRepository
    {
        ProfissionalEntity ConsultarPorCPF(string cpf);
        IEnumerable<ProfissionalEntity> ListarPorCargo(int idUnidade, string idCargo);
        IEnumerable<ProfissionalEntity> ListarMedicosPorUnidade(int idUnidade);
        IEnumerable<ProfissionalEntity> ListarEnfermeirosPorUnidade(int idUnidade);
        IEnumerable<ProfissionalEntity> ListarProfissionaisPorUnidade(int idUnidade);
        IEnumerable<ProfissionalEntity> ListarMedicosPorEquipeUnidade(int idEquipe, int idUnidade);
        IEnumerable<ProfissionalEntity> ListarEnfermeirosPorEquipeUnidade(int idEquipe, int idUnidade);
    }
}

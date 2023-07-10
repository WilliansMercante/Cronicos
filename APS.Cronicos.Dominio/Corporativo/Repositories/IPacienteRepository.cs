using APS.Cronicos.Dominio.Corporativo.Entidades;

namespace APS.Cronicos.Dominio.Corporativo.Repositories
{
    public interface IPacienteRepository
    {
        int Incluir(PacienteEntity paciente, string token);
        void Atualizar(PacienteEntity paciente, string token);
        PacienteEntity ConsultarPorCNS(string cns, string token);

    }
}

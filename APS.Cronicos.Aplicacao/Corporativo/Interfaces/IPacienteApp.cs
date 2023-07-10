using APS.Cronicos.ViewModels.Corporativo;

namespace APS.Cronicos.Aplicacao.Corporativo.Interfaces
{
    public interface IPacienteApp
    {
        void Atualizar(PacienteViewModel paciente);
        int Incluir(PacienteViewModel paciente);
        PacienteViewModel ConsultarPorCNS(string cns);
    }
}

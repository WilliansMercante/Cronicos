using APS.Cronicos.Dominio.Seguranca.Entidades;

namespace APS.Cronicos.Dominio.Seguranca.Repositories.Interfaces
{
    public interface ISistemaRepository
    {
        void Verificar();
        SistemaEntity ObterSistema();
    }
}

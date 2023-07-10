using APS.Cronicos.Dominio.Interfaces;
using APS.Cronicos.Dominio.Parametrizacao.Entidades;

namespace APS.Cronicos.Dominio.Parametrizacao.Repositories.Interfaces
{
    public interface IParametroRepository : IRepositoryBase<ParametroEntity>
    {
        bool Permitido(int idGrupo, string item);
        ParametroEntity ConsultarPorNome(string nome);
    }
}

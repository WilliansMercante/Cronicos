using APS.Cronicos.Dominio.Seguranca.Entidades;
using System.Collections.Generic;

namespace APS.Cronicos.Dominio.Seguranca.Repositories.Interfaces
{
    public interface IUnidadeRepository
    {
        IEnumerable<UnidadeEntity> ListarUnidadesPermissao(int idUsuario, int idSistema, string token);
        IEnumerable<int> ListarCnesUnidadesPermissao(int idUsuario, int idSistema, string token);
    }
}

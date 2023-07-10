using APS.Cronicos.Dominio.Corporativo.Entidades;

using System.Collections.Generic;

namespace APS.Cronicos.Dominio.Corporativo.Repositories
{
    public interface ISexoRepository
    {
        IEnumerable<SexoEntity> Listar();
    }
}

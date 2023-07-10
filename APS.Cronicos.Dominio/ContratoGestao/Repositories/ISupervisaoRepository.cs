using APS.Cronicos.Dominio.ContratoGestao.Entidades;
using System;
using System.Collections.Generic;

namespace APS.Cronicos.Dominio.ContratoGestao.Repositories.Interfaces
{
    public interface ISupervisaoRepository
    {
        IEnumerable<SupervisaoEntity> Listar(DateTime competencia);
        SupervisaoEntity ConsultarPorId(DateTime competencia, int idSupervisao);
    }
}

using APS.Cronicos.Dominio.ContratoGestao.Entidades;
using System;
using System.Collections.Generic;

namespace APS.Cronicos.Dominio.ContratoGestao.Repositories.Interfaces
{
    public interface IUnidadeRepository
    {
        IEnumerable<UnidadeEntity> ListarUnidades(DateTime competencia, bool flListarTodasUnidades, List<int> lstCnesUnidades);
        UnidadeEntity ObterPorCnes(string cnes);
        UnidadeEntity ObterUnidade(DateTime competencia, int idUnidade);
        IEnumerable<UnidadeEntity> ListarPorSupervisao(DateTime competencia, int idSupervisao);
    }
}

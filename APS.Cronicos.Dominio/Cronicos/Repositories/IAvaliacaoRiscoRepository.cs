using APS.Cronicos.Dominio.Cronicos.Entidades;

using System;
using System.Collections.Generic;

namespace APS.Cronicos.Dominio.Cronicos.Repositories
{
    public interface IAvaliacaoRiscoRepository
    {
        void Incluir(AvaliacaoRiscoEntity obj);
        void Atualizar(AvaliacaoRiscoEntity obj);
        AvaliacaoRiscoEntity ConsultarPorId(int id);
        AvaliacaoRiscoEntity ConsultarPorCnsUnidade(string cns, int idUnidade);
        void Excluir(int id);
        IEnumerable<AvaliacaoRiscoEntity> Listar();
        IEnumerable<AvaliacaoRiscoEntity> ListarPorData(DateTime dtInicio, DateTime dtFim);
        IEnumerable<AvaliacaoRiscoEntity> ListarPorCnsUnidade(string cns, int idUnidade);
    }
}

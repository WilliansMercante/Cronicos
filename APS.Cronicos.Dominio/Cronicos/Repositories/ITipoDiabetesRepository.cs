using APS.Cronicos.Dominio.Cronicos.Entidades;

using System.Collections.Generic;

namespace APS.Cronicos.Dominio.Cronicos.Repositories
{
    public interface ITipoDiabetesRepository
    {
        void Incluir(TipoDiabetesEntity obj);
        void Atualizar(TipoDiabetesEntity obj);
        TipoDiabetesEntity ConsultarPorId(int id);
        void Excluir(int id);
        IEnumerable<TipoDiabetesEntity> Listar();
    }
}

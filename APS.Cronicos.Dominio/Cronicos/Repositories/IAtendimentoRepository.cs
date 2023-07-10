using APS.Cronicos.Dominio.Cronicos.Entidades;

using System.Collections.Generic;

namespace APS.Cronicos.Dominio.Cronicos.Repositories
{
    public interface IAtendimentoRepository
    {
        void Incluir(AtendimentoEntity obj);
        void Atualizar(AtendimentoEntity obj);
        AtendimentoEntity ConsultarPorId(int id);
        void Excluir(int id);
        IEnumerable<AtendimentoEntity> Listar();
        IEnumerable<AtendimentoEntity> ListarPorCnsUnidade(string cns, int idUnidade);
        IEnumerable<AtendimentoEntity> ListarPorUnidade(int idUnidade);

    }
}

using APS.Cronicos.Dominio.Cronicos.Entidades;

using System.Collections.Generic;

namespace APS.Cronicos.Dominio.Cronicos.Repositories
{
    public interface ITipoAtendimentoRepository
    {
        void Incluir(TipoAtendimentoEntity obj);
        void Atualizar(TipoAtendimentoEntity obj);
        TipoAtendimentoEntity ConsultarPorId(int id);
        void Excluir(int id);
        IEnumerable<TipoAtendimentoEntity> Listar();
    }
}

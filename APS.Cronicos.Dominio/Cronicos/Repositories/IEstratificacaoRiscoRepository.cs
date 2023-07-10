using APS.Cronicos.Dominio.Cronicos.Entidades;

using System.Collections.Generic;

namespace APS.Cronicos.Dominio.Cronicos.Repositories
{
    public interface IEstratificacaoRiscoRepository
    {
        void Incluir(EstratificacaoRiscoEntity obj);
        void Atualizar(EstratificacaoRiscoEntity obj);
        EstratificacaoRiscoEntity ConsultarPorId(int id);
        void Excluir(int id);
        IEnumerable<EstratificacaoRiscoEntity> Listar();
        IEnumerable<EstratificacaoRiscoEntity> ListarAtivos();
    }
}

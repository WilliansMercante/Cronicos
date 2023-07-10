using APS.Cronicos.Dominio.Cronicos.Entidades;

using System.Collections.Generic;

namespace APS.Cronicos.Dominio.Cronicos.Repositories
{
    public interface IDiagnosticoRepository
    {
        void Incluir(DiagnosticoEntity obj);
        void Atualizar(DiagnosticoEntity obj);
        DiagnosticoEntity ConsultarPorId(int id);
        void Excluir(int id);
        IEnumerable<DiagnosticoEntity> Listar();
    }
}

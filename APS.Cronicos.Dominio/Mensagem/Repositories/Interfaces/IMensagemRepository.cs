using APS.Cronicos.Dominio.Interfaces;
using APS.Cronicos.Dominio.Mensagem.Entidades;

namespace APS.Cronicos.Dominio.Mensagem.Repositories.Interfaces
{
    public interface IMensagemRepository : IRepositoryBase<MensagemEntity>
    {
        bool TemMensagem(int idUsuario, int idGrupo);
        MensagemEntity ObterMensagem(int idUsuario, int idGrupo);
    }
}

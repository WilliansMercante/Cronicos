using APS.Cronicos.Dominio.Mensagem.Entidades;
using APS.Cronicos.Dominio.Mensagem.Repositories.Interfaces;
using APS.Cronicos.Infra.Data.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APS.Cronicos.Infra.Data.Repositories.Mensagem
{
    public sealed class MensagemRepository : RepositoryBase<MensagemEntity, ConfiguracaoContext>, IMensagemRepository
    {
        public MensagemRepository(ConfiguracaoContext context) : base(context)
        {
        }

        public bool TemMensagem(int idUsuario, int idGrupo)
        {
            var lstMensagens = _context.Mensagem
                                       .FromSqlRaw("EXECUTE config.STP_OBTER_MENSAGEM @ID_GRUPO, @ID_USUARIO",
                                            new SqlParameter("@ID_GRUPO", idGrupo),
                                            new SqlParameter("@ID_USUARIO", idUsuario))
                                       .ToList();

            return lstMensagens.Count > 0;
        }

        public MensagemEntity ObterMensagem(int idUsuario, int idGrupo)
        {
            var lstMensagens = _context.Mensagem
                           .FromSqlRaw("EXECUTE config.STP_OBTER_MENSAGEM @ID_GRUPO, @ID_USUARIO",
                                    new SqlParameter("@ID_GRUPO", idGrupo),
                                    new SqlParameter("@ID_USUARIO", idUsuario)
                            ).ToList();

            return lstMensagens.Count > 0 ? lstMensagens[0] : null;
        }
    }
}
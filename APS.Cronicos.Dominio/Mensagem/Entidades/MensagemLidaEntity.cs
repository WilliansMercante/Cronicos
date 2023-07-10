using APS.Cronicos.Dominio.EntidadeBase;

namespace APS.Cronicos.Dominio.Mensagem.Entidades
{
    public class MensagemLidaEntity : Entidade
    {
        public int IdMensagem { get; internal set; }
        public int IdUsuario { get; internal set; }

        public MensagemEntity Mensagem { get; set; }

        public MensagemLidaEntity(int idMensagem, int idUsuario)
        {
            IdMensagem = idMensagem;
            IdUsuario = idUsuario;
        }
    }
}

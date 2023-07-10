using APS.Cronicos.Dominio.EntidadeBase;

namespace APS.Cronicos.Dominio.Mensagem.Entidades
{
    public class StpMensagemEntity : Entidade
    {
        public string Mensagem { get; set; }
        public int? IdGrupo { get; set; }
    }
}

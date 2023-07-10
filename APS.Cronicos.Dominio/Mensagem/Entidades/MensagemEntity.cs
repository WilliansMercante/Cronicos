using APS.Cronicos.Dominio.EntidadeBase;

namespace APS.Cronicos.Dominio.Mensagem.Entidades
{
    public class MensagemEntity : Entidade
    {
        public string Mensagem { get; set; }
        public int? IdGrupo { get; set; }
    }
}

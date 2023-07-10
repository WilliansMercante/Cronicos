using System.Collections.Generic;

namespace APS.Cronicos.Dominio.Seguranca.Entidades
{
    public class RetornoEntity
    {
        public List<string> Objetos { get; set; } = new List<string>();
        public string Mensagem { get; set; }
        public bool FlSucesso { get; set; }
    }
}

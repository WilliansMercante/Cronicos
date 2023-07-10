
using System.Collections.Generic;

namespace APS.Cronicos.Dominio.Corporativo.Entidades
{
    public class RetornoCorporativoEntity
    {
        public List<string> Objetos { get; set; } = new List<string>();
        public string Mensagem { get; set; }
        public bool FlSucesso { get; set; }
    }
}

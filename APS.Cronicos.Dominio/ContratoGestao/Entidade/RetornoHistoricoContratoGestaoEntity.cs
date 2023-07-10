using System.Collections.Generic;

namespace APS.Cronicos.Dominio.ContratoGestao.Entidades
{
    public class RetornoHistoricoContratoGestaoEntity
    {
        public List<object> Objetos { get; set; } = new List<object>();
        public string Mensagem { get; set; }
        public bool FlSucesso { get; set; }
    }
}

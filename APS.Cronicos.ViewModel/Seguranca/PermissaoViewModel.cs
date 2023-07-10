using System;

namespace APS.Cronicos.ViewModels.Seguranca
{
    public class PermissaoViewModel
    {
        public int Id { get; set; }
        public int IdGrupo { get; set; }
        public int IdUnidade { get; set; }
        public bool FlAtivo { get; set; }
        public DateTime DtCadastro { get; set; }

        public GrupoViewModel Grupo { get; set; }
        public UnidadeViewModel Unidade { get; set; }
    }
}

namespace APS.Cronicos.ViewModels.Seguranca
{
    public class GrupoViewModel
    {
        public int Id { get; set; }
        public string DsGrupo { get; set; }
        public int IdSistema { get; set; }
        public bool FlStatus { get; set; }

        public SistemaViewModel Sistema { get; set; }
    }
}

namespace APS.Cronicos.ViewModels.Corporativo
{
    public class EquipeViewModel
    {
        public long Id { get; set; }
        public int IdTipoEquipe { get; set; }
        public int IdUnidade { get; set; }
        public string NmEquipe { get; set; }

        public TipoEquipeViewModel TipoEquipe { get; set; }
    }
}

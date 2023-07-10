namespace APS.Cronicos.Dominio.Corporativo.Entidades
{
    public class EquipeEntity
    {
        public long Id { get; set; }
        public int IdTipoEquipe { get; set; }
        public int IdUnidade { get; set; }
        public string NmEquipe { get; set; }

        public TipoEquipeEntity TipoEquipe { get; set; }
    }
}

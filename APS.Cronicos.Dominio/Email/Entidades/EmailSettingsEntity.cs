namespace APS.Cronicos.Dominio.Email.Entidades
{
    public class EmailSettingsEntity
    {
        public string PrimaryDomain { get; set; }
        public int PrimaryPort { get; set; }
        public string UsernameEmail { get; set; }
        public string UsernamePassword { get; set; }
        public string FromEmail { get; set; }
        public bool EnabledSsl { get; set; }
        public bool DefaultCredentials { get; set; }
    }
}

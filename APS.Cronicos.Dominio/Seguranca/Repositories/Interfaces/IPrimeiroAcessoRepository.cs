namespace APS.Cronicos.Dominio.Seguranca.Repositories.Interfaces
{
    public interface IPrimeiroAcessoRepository
    {
        string TrocarSenha(string token, int idUsuario, string emailPrincipal, string emailSecundario, string senha, string senhaConfirmada, int idSistema);
    }
}

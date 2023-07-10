namespace APS.Cronicos.Dominio.Seguranca.Repositories.Interfaces
{
    public interface ITrocarSenhaRepository
    {
        string TrocarSenha(string cpf, string link, int idSistema);
        string NovaSenha(string cpf, string hash, string senha, string confirmacao, int idSistema);
    }
}

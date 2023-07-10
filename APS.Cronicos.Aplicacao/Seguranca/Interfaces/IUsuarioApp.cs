using APS.Cronicos.ViewModels.Seguranca;

namespace APS.Cronicos.Aplicacao.Seguranca.Interfaces
{
    public interface IUsuarioApp
    {
        UsuarioViewModel Autenticar(string cpf, string senha);
    }
}

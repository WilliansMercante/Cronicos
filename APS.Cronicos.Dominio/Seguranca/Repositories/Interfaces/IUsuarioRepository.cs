using APS.Cronicos.Dominio.Seguranca.Entidades;
using System.Threading.Tasks;

namespace APS.Cronicos.Dominio.Seguranca.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioEntity Autenticar(string cpf, string senha, int idSistema);
        GrupoEntity ObterGrupo(int idUsuario, int idSistema, string token);
        Task<RetornoEntity> AtualizarEmail(int idUsuario, string emailPrincipal, string emailSecundario, string token);
    }
}

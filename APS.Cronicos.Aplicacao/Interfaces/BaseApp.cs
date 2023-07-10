using APS.Cronicos.Dominio.Helpers;
using APS.Cronicos.ViewModels.Seguranca;

using Newtonsoft.Json;

using System.Linq;

namespace APS.Cronicos.Aplicacao.Interfaces
{
    public abstract class BaseApp
    {
        public static UsuarioViewModel Usuario
        {
            get
            {
                var usuario = AppHttpContextHelper.Current.User.Claims.Where(p => p.Type.Equals("Usuario")).FirstOrDefault().Value;
                var oUsuario = JsonConvert.DeserializeObject<UsuarioViewModel>(usuario);
                return oUsuario;
            }
        }
    }
}

using APS.Cronicos.UI.Web.Extensions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APS.Cronicos.UI.Web.Filters
{
    public class AuthenticationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated || context.HttpContext.Session.Get<int>("IdUnidadeSelecionada").Equals(0))
            {
                string nmController = (string)context.RouteData.Values["Controller"];

                var flRedirecionarLogin = RedirecionarLogin(nmController);

                if (flRedirecionarLogin)
                    context.Result = new RedirectToActionResult("Index", "Autenticar", new { area = string.Empty });
            }
        }

        private bool RedirecionarLogin(string controllerName)
        {
            switch (controllerName)
            {
                case "Autenticar":
                case "PrimeiroAcesso":
                case "TrocarSenha":

                    return false;

                default:

                    return true;
            }
        }
    }
}

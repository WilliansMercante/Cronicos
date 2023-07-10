using APS.Cronicos.Aplicacao.Corporativo.Interfaces;
using APS.Cronicos.Aplicacao.Seguranca.Interfaces;
using APS.Cronicos.UI.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace APS.Cronicos.UI.Web.Controllers
{
    public class AutenticarController : BaseController
    {
        private readonly IUsuarioApp _usuarioApp;
        private readonly IMenuApp _menuApp;
        private readonly IUnidadeApp _unidadeApp;

        public AutenticarController(
            IUsuarioApp usuarioApp,
            IMenuApp menuApp,
            IUnidadeApp unidadeApp
        )
        {
            _usuarioApp = usuarioApp;
            _menuApp = menuApp;
            _unidadeApp = unidadeApp;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel login)
        {
            try
            {
                var oUsuarioVM = _usuarioApp.Autenticar(login.Cpf, login.Senha);
                IdUnidadeSelecionada = oUsuarioVM.Unidade.Id;

                var lstItensMenuPrincipalVM = _menuApp.ListarPorGrupo(oUsuarioVM.Grupo.Id);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, oUsuarioVM.Cpf),
                    new Claim(ClaimTypes.Email, oUsuarioVM.EmailPrincipal ?? string.Empty),
                    new Claim("Usuario", JsonConvert.SerializeObject(oUsuarioVM)),
                    new Claim("ItensMenuPrincipal", JsonConvert.SerializeObject(lstItensMenuPrincipalVM))
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = login.FlRelembrar,
                    IssuedUtc = DateTime.Now,
                    ExpiresUtc = DateTime.Now.AddHours(24),
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);


                if (oUsuarioVM.FlPrimeiroAcesso)
                    return RedirectToAction("Index", "PrimeiroAcesso", new { area = "Login" });
                else
                {
                    return RedirectToAction("Index", "Home", new { area = string.Empty });
                }
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
                return View(login);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Autenticar", new { area = "Login" });
        }

        [HttpPost]
        public JsonResult ListarUnidades()
        {
            try
            {
                var lstUnidadesVM = _unidadeApp.Listar();
                return Json(new { FlSucesso = true, Unidades = lstUnidadesVM });
            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }
    }
}
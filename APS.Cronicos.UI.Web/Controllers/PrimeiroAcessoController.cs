using APS.Cronicos.Dominio.Helpers;
using APS.Cronicos.Dominio.Seguranca.Repositories.Interfaces;
using APS.Cronicos.UI.Web.ViewModels;
using APS.Cronicos.ViewModels.Seguranca;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace APS.Cronicos.UI.Web.Controllers
{
    public class PrimeiroAcessoController : BaseController
    {
        private readonly IPrimeiroAcessoRepository _primeiroAcessoRepository;
        public PrimeiroAcessoController(
            IConfiguration configuration,
            IPrimeiroAcessoRepository primeiroAcessoRepository
        ) : base(configuration)
        {
            _primeiroAcessoRepository = primeiroAcessoRepository;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            PrimeiroAcessoViewModel oPrimeiroAcessoVM = null;

            try
            {
                oPrimeiroAcessoVM = _mapper.Map<UsuarioViewModel, PrimeiroAcessoViewModel>(Usuario);
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }

            return View(oPrimeiroAcessoVM);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Index(PrimeiroAcessoViewModel primeiroAcesso)
        {
            try
            {
                string senhaCriptografada = SHA256Helper.Encrypt(primeiroAcesso.Senha, ChavePublica);
                string senhaConfirmadaCriptografada = SHA256Helper.Encrypt(primeiroAcesso.SenhaConfirmada, ChavePublica);

                _primeiroAcessoRepository.TrocarSenha(primeiroAcesso.Token, primeiroAcesso.Id, primeiroAcesso.EmailPrincipal, primeiroAcesso.EmailSecundario, senhaCriptografada, senhaConfirmadaCriptografada, IdSistema);

                ExibirMensagem("Troca de senha realizada com sucesso!", TipoMensagem.Sucesso);

                return RedirectToAction("Index", "Autenticar", new { area = "Logout" });
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
                return View(primeiroAcesso);

            }
        }
    }
}

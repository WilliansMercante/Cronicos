using APS.Cronicos.Dominio.Seguranca.Repositories.Interfaces;
using APS.Cronicos.UI.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace APS.Cronicos.UI.Web.Controllers
{
    [Route("[controller]")]
    public class TrocarSenhaController : BaseController
    {
        private readonly ITrocarSenhaRepository _trocarSenhaRepository;

        public TrocarSenhaController(IConfiguration configuration, ITrocarSenhaRepository trocarSenhaRepository) : base(configuration)
        {
            _trocarSenhaRepository = trocarSenhaRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(TrocarSenhaViewModel trocarSenha)
        {
            try
            {
                string link = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/TrocarSenha/NovaSenha";

                string mensagem = _trocarSenhaRepository.TrocarSenha(trocarSenha.Cpf, link, IdSistema);

                ExibirMensagem(mensagem, TipoMensagem.Informacao);
                return RedirectToAction("Index", "Autenticar", new { area = "Login" });
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
                return View(trocarSenha);
            }
        }

        [Route("NovaSenha/{cpf}/{hash}")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult NovaSenha(string cpf, string hash)
        {
            return View(new NovaSenhaViewModel
            {
                Cpf = cpf,
                Token = hash
            });
        }

        [Route("SalvarSenha")]
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SalvarSenha(NovaSenhaViewModel senha)
        {
            try
            {
                string mensagem = _trocarSenhaRepository.NovaSenha(senha.Cpf, senha.Token, senha.NovaSenha, senha.NovaSenhaConfirmada, IdSistema);

                ExibirMensagem(mensagem, TipoMensagem.Sucesso);
                return RedirectToAction("Index", "Autenticar", new { area = "Login" });
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
                return RedirectToAction("NovaSenha", new { cpf = senha.Cpf, hash = senha.Token });
            }
        }
    }
}
using APS.Cronicos.Dominio.Helpers;
using APS.Cronicos.Dominio.Seguranca.Repositories.Interfaces;
using APS.Cronicos.UI.Web.ViewModels;
using APS.Cronicos.ViewModels.Seguranca;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace APS.Cronicos.UI.Web.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public ProfileController(IConfiguration configuration, IUsuarioRepository usuarioRepository) : base(configuration)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public PartialViewResult DadosCadastrais()
        {
            var _profileViewModel = new ProfileViewModel();

            try
            {
                _profileViewModel = _mapper.Map<UsuarioViewModel, ProfileViewModel>(Usuario);
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }

            return PartialView("_ProfilePartial", _profileViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult DadosCadastrais(ProfileViewModel profile)
        {
            try
            {
                ExcecaoDominioHelper.Validar(string.IsNullOrEmpty(profile.EmailPrincipal), "E-mail principal é obrigatório");
                ExcecaoDominioHelper.Validar(profile.EmailPrincipal.Contains("yahoo"), "Não é permitido inserir e-mail yahoo");
                ExcecaoDominioHelper.Validar(profile.EmailSecundario != null && profile.EmailSecundario.Contains("yahoo"), "Não é permitido inserir e-mail yahoo");

                var oRetorno = _usuarioRepository.AtualizarEmail(profile.Id, profile.EmailPrincipal, profile.EmailSecundario, Usuario.Token);

                ExibirMensagem(oRetorno.Result.Mensagem, TipoMensagem.Sucesso);
                ExibirMensagem("Para que as informações tenham efeito, saia do sistema e faça o login novamente.", TipoMensagem.Informacao);
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }

            return RedirectToAction("Index", "Home", new { areas = "" });
        }
    }
}

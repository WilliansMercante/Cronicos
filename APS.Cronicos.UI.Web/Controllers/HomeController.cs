using APS.Cronicos.Aplicacao.ContratoGestao.Interfaces;
using APS.Cronicos.Dominio.Interfaces;
using APS.Cronicos.Dominio.Mensagem.Entidades;
using APS.Cronicos.Dominio.Mensagem.Repositories.Interfaces;
using APS.Cronicos.Dominio.Parametrizacao.Repositories.Interfaces;
using APS.Cronicos.Dominio.Seguranca.Repositories.Interfaces;
using APS.Cronicos.Dominio.Seguranca.ValueObject;
using APS.Cronicos.Infra.Data.Contexts;
using APS.Cronicos.UI.Web.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;

namespace APS.Cronicos.UI.Web.Controllers
{
    [Authorize]
    [Route("Home")]
    public class HomeController : BaseController
    {
        private readonly IParametroRepository _parametroRepository;
        private readonly IMensagemRepository _mensagemRepository;
        private readonly IMensagemLidaRepository _mensagemLidaRepository;
        private readonly IUnitOfWork<ConfiguracaoContext> _unitOfWork;
        private readonly IUnidadeApp _unidadeApp;
        private readonly IUnidadeRepository _unidadeRepository;

        public HomeController
        (
            IMensagemRepository mensagemRepository,
            IMensagemLidaRepository mensagemLidaRepository,
            IUnitOfWork<ConfiguracaoContext> unitOfWork,
            IUnidadeApp unidadeApp,
            IUnidadeRepository unidadeRepository,
            IParametroRepository parametroRepository
        )
        {
            _mensagemRepository = mensagemRepository;
            _mensagemLidaRepository = mensagemLidaRepository;
            _unitOfWork = unitOfWork;
            _unidadeApp = unidadeApp;
            _parametroRepository = parametroRepository;
            _unidadeRepository = unidadeRepository;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            HomeViewModel oHomeVM = new HomeViewModel();
            return View(oHomeVM);
        }

        [HttpGet]
        [Route("Mensagem")]
        public PartialViewResult Mensagem()
        {
            try
            {
                var oMensagemEntity = _mensagemRepository.ObterMensagem(Usuario.Id, Usuario.Grupo.Id);
                var oMensagemVM = _mapper.Map<MensagemEntity, MensagemViewModel>(oMensagemEntity);

                return PartialView("_MensagemPartial", oMensagemVM);
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
                return PartialView("_Erro");
            }
        }

        [HttpPost]
        [Route("Mensagem")]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult Mensagem(MensagemViewModel mensagemVM)
        {
            try
            {
                _mensagemLidaRepository.Incluir(new MensagemLidaEntity(mensagemVM.Id, Usuario.Id));
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("ListarUnidades")]
        public JsonResult ListarUnidades()
        {
            try
            {
                bool flListarTodasUnidades = _parametroRepository.Permitido(Usuario.Grupo.Id, "GLOBAL.LISTAR_TODAS_UNIDADES");
                var lstCnesUnidades = _unidadeRepository.ListarCnesUnidadesPermissao(Usuario.Id, Usuario.Grupo.IdSistema, Usuario.Token).ToList();
                var lstUnidadesVM = _unidadeApp.ListarUnidades(flListarTodasUnidades, lstCnesUnidades);

                return Json(new { FlSucesso = true, Unidades = lstUnidadesVM, IdUnidadeSelecionada });
            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }

        [HttpPost]
        [Route("SelecionarUnidade/{idUnidade}")]
        public void SelecionarUnidade(int idUnidade)
        {
            IdUnidadeSelecionada = idUnidade;
            ExibirMensagem("Seleção realizada com sucesso!", TipoMensagem.Sucesso);
        }
    }
}
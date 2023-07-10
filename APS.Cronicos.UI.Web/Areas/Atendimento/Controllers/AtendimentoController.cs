using APS.Cronicos.Aplicacao.Cronicos.Interfaces;
using APS.Cronicos.UI.Web.Areas.Atendimento.ViewModels;
using APS.Cronicos.UI.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System;

namespace APS.Cronicos.UI.Web.Areas.Atendimento.Controllers
{
    [Area("Atendimento")]
    [Route("Atendimento/[controller]")]
    public class AtendimentoController : BaseController
    {
        private readonly IAtendimentoApp _atendimentoApp;
        private readonly ITipoAtendimentoApp _tipoAtendimentoApp;

        public AtendimentoController
        (
            IAtendimentoApp atendimentoApp,
            ITipoAtendimentoApp tipoAtendimentoApp
        )
        {
            _atendimentoApp = atendimentoApp;
            _tipoAtendimentoApp = tipoAtendimentoApp;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("ConsultarPorCNS/{cns}")]
        public JsonResult ConsultarPorCNS(string cns)
        {
            try
            {
                var lstAtendimentoVM = _atendimentoApp.ListarPorCnsUnidade(cns, IdUnidadeSelecionada);
                return Json(new { FlSucesso = true, LstAtendimento = lstAtendimentoVM });
            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }

        [Route("Cadastro")]
        [HttpGet]
        public PartialViewResult Cadastro()
        {
            try
            {
                var oCadastro = new CadastroViewModel()
                {
                    TiposAtendimento = new SelectList(_tipoAtendimentoApp.Listar(), "Id", "TipoAtendimento")
                };
                return PartialView("_cadastro", oCadastro);
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
                return PartialView("_Erro");
            }
        }

        [Route("Editar/{idAtendimento}")]
        [HttpGet]
        public PartialViewResult Editar(int idAtendimento)
        {
            try
            {
                var oCadastro = new CadastroViewModel()
                {
                    Atendimento = _atendimentoApp.ConsultarPorId(idAtendimento),
                    TiposAtendimento = new SelectList(_tipoAtendimentoApp.Listar(), "Id", "TipoAtendimento")
                };
                return PartialView("_cadastro", oCadastro);
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
                return PartialView("_Erro");
            }
        }

        [Route("Cadastro")]
        [HttpPost]
        public JsonResult Cadastro(CadastroViewModel cadastro)
        {
            try
            {
                cadastro.Atendimento.IdUnidade = IdUnidadeSelecionada;

                if (cadastro.Atendimento.Id.Equals(0))
                {
                    _atendimentoApp.Incluir(cadastro.Atendimento);
                }
                else
                {
                    _atendimentoApp.Atualizar(cadastro.Atendimento);
                }

                var lstAtendimentoVM = _atendimentoApp.ListarPorCnsUnidade(cadastro.Atendimento.CnsPaciente, IdUnidadeSelecionada);
                return Json(new { FlSucesso = true, LstAtendimento = lstAtendimentoVM });
            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }

        [Route("Excluir/{idAtendimento}")]
        [HttpPost]
        public JsonResult Excluir(int idAtendimento)
        {
            try
            {
                var oAtendimentoVM = _atendimentoApp.ConsultarPorId(idAtendimento);
                _atendimentoApp.Excluir(idAtendimento);
                var lstAtendimentoVM = _atendimentoApp.ListarPorCnsUnidade(oAtendimentoVM.CnsPaciente, IdUnidadeSelecionada);
                return Json(new { FlSucesso = true, Mensagem = "Atendimento Excluido com Sucesso!", LstAtendimento = lstAtendimentoVM });
            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }
    }
}

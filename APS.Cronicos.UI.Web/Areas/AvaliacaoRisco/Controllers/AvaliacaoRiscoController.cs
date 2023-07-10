using APS.Cronicos.Aplicacao.Cronicos.Interfaces;
using APS.Cronicos.UI.Web.Areas.AvaliacaoRisco.ViewModels;
using APS.Cronicos.UI.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System;

namespace APS.Cronicos.UI.Web.Areas.AvaliacaoRisco.Controllers
{
    [Area("AvaliacaoRisco")]
    [Route("AvaliacaoRisco/[controller]")]
    public class AvaliacaoRiscoController : BaseController
    {
        private readonly IAvaliacaoRiscoApp _avaliacaoRiscoApp;
        private readonly IEstratificacaoRiscoApp _estratificacaoRiscoApp;
        private readonly ITipoDiabetesApp _tipoDiabetesApp;
        private readonly IPacienteUnidadeApp _pacienteUnidadeApp;

        public AvaliacaoRiscoController
       (
           IAvaliacaoRiscoApp avaliacaoRiscoApp,
           IEstratificacaoRiscoApp estratificacaoRiscoApp,
           ITipoDiabetesApp tipoDiabetesApp,
           IPacienteUnidadeApp pacienteUnidadeApp
       )
        {
            _avaliacaoRiscoApp = avaliacaoRiscoApp;
            _estratificacaoRiscoApp = estratificacaoRiscoApp;
            _tipoDiabetesApp = tipoDiabetesApp;
            _pacienteUnidadeApp = pacienteUnidadeApp;
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
                var lstAvaliacaoRiscoVM = _avaliacaoRiscoApp.ListarPorCnsUnidade(cns, IdUnidadeSelecionada);
                return Json(new { FlSucesso = true, LstAvaliacaoRisco = lstAvaliacaoRiscoVM, Mensagem = "Avaliação Incluida com Sucesso!"});               
            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }

        [Route("Cadastro/{cns}")]
        [HttpGet]
        public PartialViewResult Cadastro(string cns)
        {
            try
            {
                var oCadastro = new CadastroViewModel()
                {
                    flDiabetes = _pacienteUnidadeApp.PossuiDiabetes(cns),
                    EstratificacoesRisco = new SelectList(_estratificacaoRiscoApp.ListarAtivos(), "Id", "EstratificacaoRisco"),
                    TiposDiabetes = new SelectList(_tipoDiabetesApp.Listar(), "Id", "TipoDiabetes")
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
                    EstratificacoesRisco = new SelectList(_estratificacaoRiscoApp.ListarAtivos(), "Id", "EstratificacaoRisco"),
                    TiposDiabetes = new SelectList(_tipoDiabetesApp.Listar(), "Id", "TipoDiabetes") ,
                    AvaliacaoRisco = _avaliacaoRiscoApp.ConsultarPorId(idAtendimento)
                };

                oCadastro.flDiabetes = _pacienteUnidadeApp.PossuiDiabetes(oCadastro.AvaliacaoRisco.CnsPaciente);
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
                cadastro.AvaliacaoRisco.IdUnidade = IdUnidadeSelecionada;

                if (cadastro.AvaliacaoRisco.Id.Equals(0))
                {
                    _avaliacaoRiscoApp.Incluir(cadastro.AvaliacaoRisco);
                }
                else
                {
                    _avaliacaoRiscoApp.Atualizar(cadastro.AvaliacaoRisco);
                }

                var lstAvaliacaoRiscoVM = _avaliacaoRiscoApp.ListarPorCnsUnidade(cadastro.AvaliacaoRisco.CnsPaciente, IdUnidadeSelecionada);
                return Json(new { FlSucesso = true, LstAvaliacaoRisco = lstAvaliacaoRiscoVM });
            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }

        [Route("Excluir/{idAvaliacao}")]
        [HttpPost]
        public JsonResult Excluir(int idAvaliacao)
        {
            try
            {
                var oAvaliacaoRiscoVM = _avaliacaoRiscoApp.ConsultarPorId(idAvaliacao);
                _avaliacaoRiscoApp.Excluir(idAvaliacao);
                var lstAvaliacaoRiscoVM = _avaliacaoRiscoApp.ListarPorCnsUnidade(oAvaliacaoRiscoVM.CnsPaciente, IdUnidadeSelecionada);
                return Json(new { FlSucesso = true, Mensagem = "Atendimento Excluido com Sucesso!", LstAvaliacaoRisco = lstAvaliacaoRiscoVM });
            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }
    }
}

using APS.Cronicos.Aplicacao.Cronicos;
using APS.Cronicos.Aplicacao.Cronicos.Interfaces;
using APS.Cronicos.UI.Web.Areas.Atendimento.ViewModels.RelatorioAtendimento;
using APS.Cronicos.UI.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Rotativa.AspNetCore;

using System;

namespace APS.Cronicos.UI.Web.Areas.Atendimento.Controllers
{
    [Area("Atendimento")]
    [Route("Atendimento/[controller]")]
    public class RelatorioAtendimentoController : BaseController
    {
        private readonly IAtendimentoApp _atendimentoApp;
        private readonly ITipoAtendimentoApp _tipoAtendimentoApp;

        public RelatorioAtendimentoController
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
            IndexViewModel indexVM = new IndexViewModel();
            try
            {
                indexVM.TiposAtendimento = new SelectList(_tipoAtendimentoApp.Listar(), "Id", "TipoAtendimento");
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);

            }
            return View(indexVM);
        }


        [HttpGet]
        [Route("RptAtendimento")]
        public IActionResult RptAtendimento
        (
            bool flPacientesSemAtendimento,
            string cnsPaciente,
            int? idTipoAtendimento,
            DateTime? dtInicioAtendimento,
            DateTime? dtFimAtendimento
        )
        {
            try
            {
                var oRptAtendimentoVM = _atendimentoApp.RptAtendimento
                (
                    IdUnidadeSelecionada,
                    flPacientesSemAtendimento,
                    cnsPaciente,
                    idTipoAtendimento,
                    dtInicioAtendimento,
                    dtFimAtendimento
                );

                //oRptAtendimentoVM.IdUnidade = IdUnidadeSelecionada;
                //oRptAtendimentoVM.NomeUnidade = _unidadeApp.ObterUnidade(IdUnidadeSelecionada).NmUnidade;

                return new ViewAsPdf("RptAtendimento") { FileName = "Relatório de Pacientes - CNES " + IdUnidadeSelecionada + " - " + DateTime.Now + ".pdf", PageOrientation = 0 };
            }catch
            {
                return new ViewAsPdf();
            }     


        }
    }
}

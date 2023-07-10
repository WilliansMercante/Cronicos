using APS.Cronicos.Aplicacao.Corporativo.Interfaces;
using APS.Cronicos.Aplicacao.Cronicos.Interfaces;
using APS.Cronicos.UI.Web.Areas.Paciente.ViewModels.Paciente;
using APS.Cronicos.UI.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System;

namespace APS.Cronicos.UI.Web.Areas.Paciente.Controllers
{
    [Area("Paciente")]
    [Route("Paciente/[controller]")]
    public class PacienteController : BaseController
    {
        private readonly IPacienteApp _pacienteApp;
        private readonly IPacienteUnidadeApp _pacienteUnidadeApp;
        private readonly ISexoApp _sexoApp;
        private readonly IProfissionalApp _profissionalApp;
        private readonly IEquipeApp _equipeApp;
        private readonly IDiagnosticoApp _diagnosticoApp;

        public PacienteController
        (
            IPacienteApp pacienteApp,
            ISexoApp sexoApp,
            IProfissionalApp profissionalApp,
            IEquipeApp equipeApp,
            IPacienteUnidadeApp pacienteUnidadeApp,
            IDiagnosticoApp diagnosticoApp
        )
        {
            _pacienteApp = pacienteApp;
            _sexoApp = sexoApp;
            _profissionalApp = profissionalApp;
            _equipeApp = equipeApp;
            _pacienteUnidadeApp = pacienteUnidadeApp;
            _diagnosticoApp = diagnosticoApp;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            IndexViewModel indexVM = new IndexViewModel();

            try
            {
                indexVM.Paciente = new DadosPacienteViewModel
                {
                    ListarSexo = new SelectList(_sexoApp.Listar(), "Id", "Sexo"),
                    Equipes = new SelectList(_equipeApp.ListarPorUnidade(IdUnidadeSelecionada), "Id", "NmEquipe"),
                    Diagnosticos = new SelectList(_diagnosticoApp.Listar(), "Id", "Diagnostico")
                };

                indexVM.Paciente.PacienteUnidade.IdUnidade = IdUnidadeSelecionada;
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }

            return View(indexVM);
        }

        [Route("ConsultarPorCNS/{cns}")]
        [HttpPost]
        public JsonResult ConsultarPorCNS(string cns)
        {
            try
            {
                var mensagem = string.Empty;
                var oPacienteVM = _pacienteApp.ConsultarPorCNS(cns);
                var oPacienteUnidadeVM = _pacienteUnidadeApp.ConsultarPorCnsUnidade(cns, IdUnidadeSelecionada);

                if (oPacienteVM == null)
                {
                    mensagem = "Paciente não localizado, por favor preencha o cadastro";
                }
                else
                {
                    mensagem = "Paciente localizado!";
                }

                var dadosPaciente = new { paciente = oPacienteVM, pacienteUnidade = oPacienteUnidadeVM };

                return Json(new { FlSucesso = true, mensagem, dadosPaciente });
            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }

        [Route("ConsultarProfissionaisPorEquipe/{idEquipe}")]
        [HttpPost]
        public JsonResult ConsultarProfissionaisPorEquipe(int idEquipe)
        {
            try
            {
                var lstMedicoVM = _profissionalApp.ListarMedicosPorEquipeUnidade(idEquipe, IdUnidadeSelecionada);
                var lstEnfermeiroVM = _profissionalApp.ListarEnfermeirosPorEquipeUnidade(idEquipe, IdUnidadeSelecionada);

                return Json(new { FlSucesso = true, Medicos = lstMedicoVM, Enfermeiros = lstEnfermeiroVM });
            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }

        [Route("Cadastro")]
        [HttpPost]
        public JsonResult Cadastro(DadosPacienteViewModel dadosPacienteVM)
        {
            int idPaciente;
            int idPacienteUnidade;

            try
            {
                dadosPacienteVM.PacienteUnidade.CnsPaciente = dadosPacienteVM.Paciente.Cns;
                dadosPacienteVM.PacienteUnidade.IdUnidade = IdUnidadeSelecionada;

                if (dadosPacienteVM.Paciente.Id.Equals(0))
                {
                    idPaciente = _pacienteApp.Incluir(dadosPacienteVM.Paciente);
                }
                else
                {
                    idPaciente = dadosPacienteVM.Paciente.Id;
                    _pacienteApp.Atualizar(dadosPacienteVM.Paciente);                    
                }

                if (dadosPacienteVM.PacienteUnidade.Id.Equals(0))
                {
                    idPacienteUnidade = _pacienteUnidadeApp.Incluir(dadosPacienteVM.PacienteUnidade);
                }
                else
                {
                    idPacienteUnidade = dadosPacienteVM.PacienteUnidade.Id;
                    _pacienteUnidadeApp.Atualizar(dadosPacienteVM.PacienteUnidade);
                }

                return Json(new { FlSucesso = true, Mensagem = "Dados inseridos com sucesso!", IdPaciente = idPaciente, IdPacienteUnidade = idPacienteUnidade });

            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }
    }
}

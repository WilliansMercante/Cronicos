using APS.Cronicos.Aplicacao.Corporativo.Interfaces;
using APS.Cronicos.Aplicacao.Cronicos.Interfaces;
using APS.Cronicos.UI.Web.Areas.Paciente.ViewModels.RelatorioPaciente;
using APS.Cronicos.UI.Web.Controllers;
using APS.Cronicos.ViewModels.Corporativo;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Rotativa.AspNetCore;

using System;
using System.Linq;

namespace APS.Cronicos.UI.Web.Areas.Paciente.Controllers
{
    [Area("Paciente")]
    [Route("Paciente/[controller]")]
    public class RelatorioPacienteController : BaseController
    {
        private readonly IPacienteApp _pacienteApp;
        private readonly IPacienteUnidadeApp _pacienteUnidadeApp;
        private readonly ISexoApp _sexoApp;
        private readonly IProfissionalApp _profissionalApp;
        private readonly IEquipeApp _equipeApp;
        private readonly IDiagnosticoApp _diagnosticoApp;
        private readonly IRelatorioPacienteApp _relatorioPacienteApp;
        private readonly IUnidadeApp _unidadeApp;

        public RelatorioPacienteController
        (
            IPacienteApp pacienteApp,
            ISexoApp sexoApp,
            IProfissionalApp profissionalApp,
            IEquipeApp equipeApp,
            IPacienteUnidadeApp pacienteUnidadeApp,
            IDiagnosticoApp diagnosticoApp,
            IRelatorioPacienteApp relatorioPacienteApp,
            IUnidadeApp unidadeApp
        )
        {
            _pacienteApp = pacienteApp;
            _sexoApp = sexoApp;
            _profissionalApp = profissionalApp;
            _equipeApp = equipeApp;
            _pacienteUnidadeApp = pacienteUnidadeApp;
            _diagnosticoApp = diagnosticoApp;
            _relatorioPacienteApp = relatorioPacienteApp;
            _unidadeApp = unidadeApp;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            IndexViewModel indexVM = new IndexViewModel();

            try
            {
                var lstPacienteUnidadeVM = _pacienteUnidadeApp.ListarPorCnes(IdUnidadeSelecionada);

                indexVM.ListarSexo = new SelectList(_sexoApp.Listar(), "Id", "Sexo");

                indexVM.Equipes = lstPacienteUnidadeVM
                                                      .Where(p => p.IdEquipe.HasValue)
                                                      .GroupBy(P => P.IdEquipe)
                                                      .Select(p => new SelectListItem
                                                      {
                                                          Text = p.First().NomeEquipe,
                                                          Value = p.Key.ToString()
                                                      })
                                                      .ToList();


                indexVM.Diagnosticos = new SelectList(_diagnosticoApp.Listar(), "Id", "Diagnostico");

                indexVM.Enfermeiros = lstPacienteUnidadeVM
                                                          .Where(p => !string.IsNullOrWhiteSpace(p.CpfEnfermeiro))
                                                          .GroupBy(p => p.CpfEnfermeiro)
                                                          .Select(p => new SelectListItem
                                                          {
                                                              Text = p.First().NomeEnfermeiro,
                                                              Value = p.Key
                                                          })
                                                          .ToList();
                indexVM.Medicos = lstPacienteUnidadeVM
                                                      .Where(p => !string.IsNullOrWhiteSpace(p.CpfMedico))
                                                      .GroupBy(p => p.CpfMedico)
                                                      .Select(p => new SelectListItem
                                                      {

                                                          Text = p.First().NomeMedico,
                                                          Value = p.Key
                                                      })
                                                      .ToList();

                indexVM.PacienteUnidade.IdUnidade = IdUnidadeSelecionada;
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }

            return View(indexVM);
        }

        [HttpGet]
        [Route("RptPaciente")]
        public IActionResult RptPaciente
        (
            bool flForaDeArea,
            string prontuario,
            int? idEquipe,
            string cpfEnfermeiro,
            string cpfMedico,
            int? idDiagnostico
        )
        {
            try
            {
                var oRptPacienteVM = _relatorioPacienteApp.RptPaciente
                (
                    IdUnidadeSelecionada,
                    flForaDeArea,
                    prontuario,
                    cpfEnfermeiro,
                    cpfMedico,
                    idEquipe,
                    idDiagnostico
                );

                oRptPacienteVM.IdUnidade = IdUnidadeSelecionada;
                oRptPacienteVM.NomeUnidade = _unidadeApp.ObterUnidade(IdUnidadeSelecionada).NmUnidade;

                return new ViewAsPdf("RptPaciente", oRptPacienteVM) { FileName = "Relatório de Pacientes - CNES " + IdUnidadeSelecionada + " - " + DateTime.Now + ".pdf" , PageOrientation = 0};
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

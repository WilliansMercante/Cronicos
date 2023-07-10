using APS.Cronicos.Aplicacao.Cronicos.Interfaces;
using APS.Cronicos.Aplicacao.Mappers;
using APS.Cronicos.Dominio.Cronicos.Entidades;
using APS.Cronicos.Dominio.Cronicos.Repositories;
using APS.Cronicos.Dominio.Helpers;
using APS.Cronicos.Dominio.Interfaces;
using APS.Cronicos.Infra.Data.Contexts;
using APS.Cronicos.ViewModels.Cronicos;

using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;

namespace APS.Cronicos.Aplicacao.Cronicos
{
    public sealed class PacienteUnidadeApp : IPacienteUnidadeApp
    {
        private readonly IPacienteUnidadeRepository _pacienteUnidadeRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly IUnitOfWork<CronicosContext> _unitOfWork;
        public PacienteUnidadeApp
        (
            IPacienteUnidadeRepository pacienteUnidadeRepository,
            IUnitOfWork<CronicosContext> unitOfWork
        )
        {
            _pacienteUnidadeRepository = pacienteUnidadeRepository;
            _unitOfWork = unitOfWork;
        }

        public void Atualizar(PacienteUnidadeViewModel obj)
        {
            var oPacienteUnidadeEntity = _mapper.Map<PacienteUnidadeEntity>(obj);
            ExcecaoDominioHelper.Validar(!oPacienteUnidadeEntity.ValidarUnidade, "Unidade Inválida");
            _pacienteUnidadeRepository.Atualizar(oPacienteUnidadeEntity);
            _unitOfWork.Commit();
        }

        public PacienteUnidadeViewModel ConsultarPorId(int id)
        {
            var oPacienteUnidadeEntity = _pacienteUnidadeRepository.ConsultarPorId(id);
            return _mapper.Map<PacienteUnidadeViewModel>(oPacienteUnidadeEntity);
        }

        public PacienteUnidadeViewModel ConsultarPorCns(string cns)
        {
            var oPacienteUnidadeEntity = _pacienteUnidadeRepository.ConsultarPorCns(cns);
            return _mapper.Map<PacienteUnidadeViewModel>(oPacienteUnidadeEntity);
        }

        public void Excluir(int id)
        {
            _pacienteUnidadeRepository.Excluir(id);
            _unitOfWork.Commit();
        }

        public int Incluir(PacienteUnidadeViewModel obj)
        {            
            obj.DtCadastro = DateTime.Now; 
            var oPacienteUnidadeEntity = _mapper.Map<PacienteUnidadeEntity>(obj);
            ExcecaoDominioHelper.Validar(!oPacienteUnidadeEntity.ValidarUnidade, "Unidade Inválida");
            _pacienteUnidadeRepository.Incluir(oPacienteUnidadeEntity);
            _unitOfWork.Commit();
            return oPacienteUnidadeEntity.Id;
        }

        public IEnumerable<PacienteUnidadeViewModel> Listar()
        {
            var lstPacienteUnidadeEntity = _pacienteUnidadeRepository.Listar();
            return _mapper.Map<IEnumerable<PacienteUnidadeViewModel>>(lstPacienteUnidadeEntity);
        }

        public PacienteUnidadeViewModel ConsultarPorCnsUnidade(string cns, int idUnidade)
        {
            var oPacienteUnidadeEntity = _pacienteUnidadeRepository.ConsultarPorCnsUnidade(cns, idUnidade);
            return _mapper.Map<PacienteUnidadeViewModel>(oPacienteUnidadeEntity);
        }

        public bool PossuiDiabetes(string cns)
        {
            return _pacienteUnidadeRepository.PossuiDiabetes(cns);
        }

        public IEnumerable<PacienteUnidadeViewModel> ListarPorCnes(int cnes)
        {
            var lstPacienteUnidadeEntity = _pacienteUnidadeRepository.ListarPorCnes(cnes);
            return _mapper.Map<IEnumerable<PacienteUnidadeViewModel>>(lstPacienteUnidadeEntity);
        }
   
        public IEnumerable<PacienteUnidadeViewModel> ListarPorFiltro
        (
            int idUnidade,
            bool flForaDeArea,
            string prontuario,
            string cpfEnfermeiro,
            string cpfMedico,
            int? idEquipe,
            int? idDiagnostico
        )
        {
            var lstPacienteUnidadeEntity = _pacienteUnidadeRepository.ListarPorFiltro(idUnidade,
            flForaDeArea,
            prontuario,
            cpfEnfermeiro,
            cpfMedico,
            idEquipe,
            idDiagnostico).ToList();
            return _mapper.Map<IEnumerable<PacienteUnidadeViewModel>>(lstPacienteUnidadeEntity);
        }
    }
}

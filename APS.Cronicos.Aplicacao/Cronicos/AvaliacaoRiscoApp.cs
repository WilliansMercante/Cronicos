using APS.Cronicos.Aplicacao.Cronicos.Interfaces;
using APS.Cronicos.Aplicacao.Mappers;
using APS.Cronicos.Dominio.Cronicos.Entidades;
using APS.Cronicos.Dominio.Cronicos.Repositories;
using APS.Cronicos.Dominio.Interfaces;
using APS.Cronicos.Infra.Data.Contexts;
using APS.Cronicos.ViewModels.Cronicos;

using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;

namespace APS.Cronicos.Aplicacao.Cronicos
{
    public sealed class AvaliacaoRiscoApp : IAvaliacaoRiscoApp
    {
        private readonly IAvaliacaoRiscoRepository _avaliacaoRiscoRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly IUnitOfWork<CronicosContext> _unitOfWork;
        public AvaliacaoRiscoApp
        (
            IAvaliacaoRiscoRepository avaliacaoRiscoRepository,
            IUnitOfWork<CronicosContext> unitOfWork
        )
        {
            _avaliacaoRiscoRepository = avaliacaoRiscoRepository;
            _unitOfWork = unitOfWork;
        }

        public void Atualizar(AvaliacaoRiscoViewModel obj)
        {
            var oAvaliacaoRiscoEntity = _mapper.Map<AvaliacaoRiscoEntity>(obj);
            _avaliacaoRiscoRepository.Atualizar(oAvaliacaoRiscoEntity);
            _unitOfWork.Commit();
        }

        public AvaliacaoRiscoViewModel ConsultarPorCnsUnidade(string cns, int idUnidade)
        {
            var oAvaliacaoRiscoEntity = _avaliacaoRiscoRepository.ConsultarPorCnsUnidade(cns,idUnidade);
            return _mapper.Map<AvaliacaoRiscoViewModel>(oAvaliacaoRiscoEntity);
        }

        public AvaliacaoRiscoViewModel ConsultarPorId(int id)
        {
            var oAvaliacaoRiscoEntity = _avaliacaoRiscoRepository.ConsultarPorId(id);
            return _mapper.Map<AvaliacaoRiscoViewModel>(oAvaliacaoRiscoEntity);
        }

        public void Excluir(int id)
        {
            _avaliacaoRiscoRepository.Excluir(id);
            _unitOfWork.Commit();
        }

        public void Incluir(AvaliacaoRiscoViewModel obj)
        {
            var oAvaliacaoRiscoEntity = _mapper.Map<AvaliacaoRiscoEntity>(obj);
            oAvaliacaoRiscoEntity.DtCadastro = DateTime.Now;
            _avaliacaoRiscoRepository.Incluir(oAvaliacaoRiscoEntity);
            _unitOfWork.Commit();
        }

        public IEnumerable<AvaliacaoRiscoViewModel> Listar()
        {
            var lstAvaliacaoRiscoEntity = _avaliacaoRiscoRepository.Listar();
            return _mapper.Map<IEnumerable<AvaliacaoRiscoViewModel>>(lstAvaliacaoRiscoEntity);
        }

        public IEnumerable<AvaliacaoRiscoViewModel> ListarPorData(DateTime dtInicio, DateTime dtFim)
        {
            var lstAvaliacaoRiscoEntity = _avaliacaoRiscoRepository.ListarPorData(dtInicio, dtFim);
            return _mapper.Map<IEnumerable<AvaliacaoRiscoViewModel>>(lstAvaliacaoRiscoEntity);
        }

        public IEnumerable<AvaliacaoRiscoViewModel> ListarPorCnsUnidade(string cns, int idUnidade)
        {
            var lstAvaliacaoRiscoEntity = _avaliacaoRiscoRepository.ListarPorCnsUnidade(cns, idUnidade);
            return _mapper.Map<IEnumerable<AvaliacaoRiscoViewModel>>(lstAvaliacaoRiscoEntity);
        }

    }
}

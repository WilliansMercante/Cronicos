using APS.Cronicos.Aplicacao.Cronicos.Interfaces;
using APS.Cronicos.Aplicacao.Mappers;
using APS.Cronicos.Dominio.Cronicos.Entidades;
using APS.Cronicos.Dominio.Cronicos.Repositories;
using APS.Cronicos.Dominio.Interfaces;
using APS.Cronicos.Infra.Data.Contexts;
using APS.Cronicos.ViewModels.Cronicos;

using AutoMapper;

using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.Cronicos
{
    public sealed class EstratificacaoRiscoApp : IEstratificacaoRiscoApp
    {
        private readonly IEstratificacaoRiscoRepository _estratificacaoRiscoRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly IUnitOfWork<CronicosContext> _unitOfWork;

        public EstratificacaoRiscoApp
        (
            IEstratificacaoRiscoRepository estratificacaoRiscoRepository,
            IUnitOfWork<CronicosContext> unitOfWork
        )
        {
            _estratificacaoRiscoRepository = estratificacaoRiscoRepository;
            _unitOfWork = unitOfWork;
        }

        public void Atualizar(EstratificacaoRiscoViewModel obj)
        {
            var oEstratificacaoRiscoEntity = _mapper.Map<EstratificacaoRiscoEntity>(obj);
            _estratificacaoRiscoRepository.Atualizar(oEstratificacaoRiscoEntity);
            _unitOfWork.Commit();
        }

        public EstratificacaoRiscoViewModel ConsultarPorId(int id)
        {
            var oEstratificacaoRiscoEntity = _estratificacaoRiscoRepository.ConsultarPorId(id);
            return _mapper.Map<EstratificacaoRiscoViewModel>(oEstratificacaoRiscoEntity);
        }

        public void Excluir(int id)
        {
            _estratificacaoRiscoRepository.Excluir(id);
            _unitOfWork.Commit();
        }

        public void Incluir(EstratificacaoRiscoViewModel obj)
        {
            var oEstratificacaoRiscoEntity = _mapper.Map<EstratificacaoRiscoEntity>(obj);
            _estratificacaoRiscoRepository.Incluir(oEstratificacaoRiscoEntity);
            _unitOfWork.Commit();

        }

        public IEnumerable<EstratificacaoRiscoViewModel> Listar()
        {
            var lstEstratificacaoRiscoEntity = _estratificacaoRiscoRepository.Listar();
            return _mapper.Map<IEnumerable<EstratificacaoRiscoViewModel>>(lstEstratificacaoRiscoEntity);
        }

        public IEnumerable<EstratificacaoRiscoViewModel> ListarAtivos()
        {
            var lstEstratificacaoRiscoEntity = _estratificacaoRiscoRepository.ListarAtivos();
            return _mapper.Map<IEnumerable<EstratificacaoRiscoViewModel>>(lstEstratificacaoRiscoEntity);
        }
    }
}

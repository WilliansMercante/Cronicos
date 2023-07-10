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
    public sealed class TipoAtendimentoApp : ITipoAtendimentoApp
    {
        private readonly ITipoAtendimentoRepository _tipoAtendimentoRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly IUnitOfWork<CronicosContext> _unitOfWork;

        public TipoAtendimentoApp
        (
            ITipoAtendimentoRepository tipoAtendimentoRepository,
            IUnitOfWork<CronicosContext> unitOfWork
        )
        {
            _tipoAtendimentoRepository = tipoAtendimentoRepository;
            _unitOfWork = unitOfWork;
        }

        public void Atualizar(TipoAtendimentoViewModel obj)
        {
            var oEstratificacaoRiscoEntity = _mapper.Map<TipoAtendimentoEntity>(obj);
            _tipoAtendimentoRepository.Atualizar(oEstratificacaoRiscoEntity);
            _unitOfWork.Commit();
        }

        public TipoAtendimentoViewModel ConsultarPorId(int id)
        {
            var oTipoAtendimentoEntity = _tipoAtendimentoRepository.ConsultarPorId(id);
            return _mapper.Map<TipoAtendimentoViewModel>(oTipoAtendimentoEntity);
        }

        public void Excluir(int id)
        {
            _tipoAtendimentoRepository.Excluir(id);
            _unitOfWork.Commit();
        }

        public void Incluir(TipoAtendimentoViewModel obj)
        {
            var oEstratificacaoRiscoEntity = _mapper.Map<TipoAtendimentoEntity>(obj);
            _tipoAtendimentoRepository.Incluir(oEstratificacaoRiscoEntity);
            _unitOfWork.Commit();
        }

        public IEnumerable<TipoAtendimentoViewModel> Listar()
        {
            var lstTipoAtendimentoEntity = _tipoAtendimentoRepository.Listar();
            return _mapper.Map<IEnumerable<TipoAtendimentoViewModel>>(lstTipoAtendimentoEntity);
        }
    }
}

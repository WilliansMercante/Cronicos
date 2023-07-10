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
    public sealed class DiagnosticoApp : IDiagnosticoApp
    {
        private readonly IDiagnosticoRepository _diagnosticoRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly IUnitOfWork<CronicosContext> _unitOfWork;
        public DiagnosticoApp
        (
            IDiagnosticoRepository diagnosticoRepository,
            IUnitOfWork<CronicosContext> unitOfWork
        )
        {
            _diagnosticoRepository = diagnosticoRepository;
            _unitOfWork = unitOfWork;
        }

        public void Atualizar(DiagnosticoViewModel obj)
        {
            var oDiagnosticoEntity = _mapper.Map<DiagnosticoEntity>(obj);
            _diagnosticoRepository.Atualizar(oDiagnosticoEntity);
            _unitOfWork.Commit();
        }

        public DiagnosticoViewModel ConsultarPorId(int id)
        {
            var oDiagnosticoEntity = _diagnosticoRepository.ConsultarPorId(id);
            return _mapper.Map<DiagnosticoViewModel>(oDiagnosticoEntity);
        }

        public void Excluir(int id)
        {
            _diagnosticoRepository.Excluir(id);
            _unitOfWork.Commit();
        }

        public void Incluir(DiagnosticoViewModel obj)
        {
            var oDiagnosticoEntity = _mapper.Map<DiagnosticoEntity>(obj);
            _diagnosticoRepository.Incluir(oDiagnosticoEntity);
            _unitOfWork.Commit();

        }

        public IEnumerable<DiagnosticoViewModel> Listar()
        {
            var lstDiagnosticoEntity = _diagnosticoRepository.Listar();
            return _mapper.Map<IEnumerable<DiagnosticoViewModel>>(lstDiagnosticoEntity);
        }
    }

}

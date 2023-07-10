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

namespace APS.Cronicos.Aplicacao.Cronicos
{
    public sealed class AtendimentoApp : IAtendimentoApp
    {
        private readonly IAtendimentoRepository _atendimentoRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly IUnitOfWork<CronicosContext> _unitOfWork;
        public AtendimentoApp
        (
            IAtendimentoRepository atendimentoRepository,
            IUnitOfWork<CronicosContext> unitOfWork
        )
        {
            _atendimentoRepository = atendimentoRepository;
            _unitOfWork = unitOfWork;
        }

        public void Atualizar(AtendimentoViewModel obj)
        {
            var oAtendimentoEntity = _mapper.Map<AtendimentoEntity>(obj);
            ExcecaoDominioHelper.Validar(obj.IdUnidade.Equals(0), "Unidade Inválida");
            _atendimentoRepository.Atualizar(oAtendimentoEntity);
            _unitOfWork.Commit();
        }

        public AtendimentoViewModel ConsultarPorId(int id)
        {
            var oAtendimentoEntity = _atendimentoRepository.ConsultarPorId(id);
            return _mapper.Map<AtendimentoViewModel>(oAtendimentoEntity);
        }

        public IEnumerable<AtendimentoViewModel> ListarPorCnsUnidade(string cns, int idUnidade) {

            var lstAtendimentoEntity = _atendimentoRepository.ListarPorCnsUnidade(cns, idUnidade);
            return _mapper.Map<IEnumerable<AtendimentoViewModel>>(lstAtendimentoEntity);

        }

        public void Excluir(int id)
        {
            _atendimentoRepository.Excluir(id);
            _unitOfWork.Commit();
        }

        public void Incluir(AtendimentoViewModel obj)
        {
            var oAtendimentoEntity = _mapper.Map<AtendimentoEntity>(obj);
            oAtendimentoEntity.DtCadastro = DateTime.Now;
            ExcecaoDominioHelper.Validar(obj.IdUnidade.Equals(0), "Unidade Inválida");
            _atendimentoRepository.Incluir(oAtendimentoEntity);
            _unitOfWork.Commit();
        }

        public IEnumerable<AtendimentoViewModel> Listar()
        {
            var lstAtendimentoEntity = _atendimentoRepository.Listar();
            return _mapper.Map<IEnumerable<AtendimentoViewModel>>(lstAtendimentoEntity);
        }

        public IEnumerable<AtendimentoViewModel> ListarPorUnidade(int idUnidade)
        {
            var lstAtendimentoEntity = _atendimentoRepository.ListarPorUnidade(idUnidade);
            return _mapper.Map<IEnumerable<AtendimentoViewModel>>(lstAtendimentoEntity);
        }

        public IEnumerable<AtendimentoViewModel> RptAtendimento
        (
            int IdUnidadeSelecionada, 
            bool flPacientesSemAtendimento, 
            string cnsPaciente, 
            int? idTipoAtendimento,
            DateTime? dtInicioAtendimento, 
            DateTime? dtFimAtendimento
        )
        {
            throw new NotImplementedException();
        }
    }
}

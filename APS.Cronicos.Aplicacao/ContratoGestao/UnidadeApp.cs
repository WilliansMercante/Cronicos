using APS.Cronicos.Aplicacao.ContratoGestao.Interfaces;
using APS.Cronicos.Aplicacao.Mappers;
using APS.Cronicos.Dominio.ContratoGestao.Repositories.Interfaces;
using APS.Cronicos.ViewModels.ContratoGestao;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.ContratoGestao
{
    public sealed class UnidadeApp : IUnidadeApp
    {
        private readonly DateTime _competencia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        private readonly IUnidadeRepository _unidadeRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();

        public UnidadeApp(IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }

        public IEnumerable<UnidadeViewModel> ListarPorSupervisao(int idSupervisao)
        {
            var lstUnidadesEntity = _unidadeRepository.ListarPorSupervisao(_competencia, idSupervisao);
            var lstUnidadesVM = _mapper.Map<IEnumerable<UnidadeViewModel>>(lstUnidadesEntity);
            return lstUnidadesVM;
        }

        public IEnumerable<UnidadeViewModel> ListarUnidades(bool flListarTodasUnidades, List<int> lstCnesUnidades)
        {
            var lstUnidadesEntity = _unidadeRepository.ListarUnidades(_competencia, flListarTodasUnidades, lstCnesUnidades);
            var lstUnidadesVM = _mapper.Map<IEnumerable<UnidadeViewModel>>(lstUnidadesEntity);
            return lstUnidadesVM;
        }

        public UnidadeViewModel ObterPorCnes(string cnes)
        {
            var oUnidadeEntity = _unidadeRepository.ObterPorCnes(cnes);
            var oUnidadeVM = _mapper.Map<UnidadeViewModel>(oUnidadeEntity);
            return oUnidadeVM;
        }

        public UnidadeViewModel ObterUnidade(int idUnidade)
        {
            var oUnidadeEntity = _unidadeRepository.ObterUnidade(_competencia, idUnidade);
            var oUnidadeVM = _mapper.Map<UnidadeViewModel>(oUnidadeEntity);
            return oUnidadeVM;
        }
    }
}

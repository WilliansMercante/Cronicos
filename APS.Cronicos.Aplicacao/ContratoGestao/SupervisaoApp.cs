using APS.Cronicos.Aplicacao.ContratoGestao.Interfaces;
using APS.Cronicos.Aplicacao.Mappers;
using APS.Cronicos.Dominio.ContratoGestao.Repositories.Interfaces;
using APS.Cronicos.ViewModels.ContratoGestao;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.ContratoGestao
{
    public sealed class SupervisaoApp : ISupervisaoApp
    {
        private readonly DateTime _competencia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); 
        private readonly ISupervisaoRepository _supervisaoRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();

        public SupervisaoApp(ISupervisaoRepository supervisaoRepository)
        {
            _supervisaoRepository = supervisaoRepository;
        }

        public IEnumerable<SupervisaoViewModel> Listar()
        {
            var lstSupervisoesEntity = _supervisaoRepository.Listar(_competencia);
            var lstSupervisoesVM = _mapper.Map<IEnumerable<SupervisaoViewModel>>(lstSupervisoesEntity);
            return lstSupervisoesVM;
        }

        public SupervisaoViewModel ConsultarPorId(int idSupervisao)
        {
            var oSupervisaoEntity = _supervisaoRepository.ConsultarPorId(_competencia, idSupervisao);
            var oSupervisaoVM = _mapper.Map<SupervisaoViewModel>(oSupervisaoEntity);
            return oSupervisaoVM;
        }
    }
}

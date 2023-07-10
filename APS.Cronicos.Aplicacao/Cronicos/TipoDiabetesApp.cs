using APS.Cronicos.Aplicacao.Cronicos.Interfaces;
using APS.Cronicos.Aplicacao.Mappers;
using APS.Cronicos.Dominio.Cronicos.Repositories;
using APS.Cronicos.ViewModels.Cronicos;

using AutoMapper;

using System;
using System.Collections.Generic;
using System.Text;

namespace APS.Cronicos.Aplicacao.Cronicos
{
    public sealed class TipoDiabetesApp : ITipoDiabetesApp
    {
        private readonly ITipoDiabetesRepository _tipoDiabetesRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();

        public TipoDiabetesApp
        (
            ITipoDiabetesRepository tipoDiabetesRepository
        )
        {
            _tipoDiabetesRepository = tipoDiabetesRepository;
        }

        public IEnumerable<TipoDiabetesViewModel> Listar()
        {
            var lstTipoDiabetesEntity = _tipoDiabetesRepository.Listar();
            return _mapper.Map<IEnumerable<TipoDiabetesViewModel>>(lstTipoDiabetesEntity);
        }
    }
}

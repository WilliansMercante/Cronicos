using APS.Cronicos.Aplicacao.Corporativo.Interfaces;
using APS.Cronicos.Aplicacao.Mappers;
using APS.Cronicos.Dominio.Corporativo.Repositories;
using APS.Cronicos.ViewModels.Corporativo;

using AutoMapper;

using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.Corporativo
{
    public sealed class EquipeApp : IEquipeApp
    {
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly IEquipeRepository _equipeRepository;

        public EquipeApp(IEquipeRepository equipeRepository)
        {
            _equipeRepository = equipeRepository;
        }

        public IEnumerable<EquipeViewModel> ListarPorUnidade(int idUnidade)
        {
            var lstEquipeEntity = _equipeRepository.ListarPorUnidade(idUnidade);
            return _mapper.Map<IEnumerable<EquipeViewModel>>(lstEquipeEntity);
        }
    }
}

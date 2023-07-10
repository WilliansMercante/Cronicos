using APS.Cronicos.Aplicacao.Corporativo.Interfaces;
using APS.Cronicos.Aplicacao.Mappers;
using APS.Cronicos.Dominio.Corporativo.Repositories;
using APS.Cronicos.ViewModels.Corporativo;

using AutoMapper;

using System.Collections.Generic;
using System.Linq;

namespace APS.Cronicos.Aplicacao.Corporativo
{
    public sealed class SexoApp : ISexoApp
    {
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly ISexoRepository _sexoRepository;

        public SexoApp(ISexoRepository sexoRepository)
        {
            _sexoRepository = sexoRepository;
        }

        public IEnumerable<SexoViewModel> Listar()
        {
            var lstSexoEntity = _sexoRepository.Listar();
            return _mapper.Map<IEnumerable<SexoViewModel>>(lstSexoEntity).ToList();
        }
    }
}

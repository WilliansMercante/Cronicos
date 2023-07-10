using APS.Cronicos.Aplicacao.Corporativo.Interfaces;
using APS.Cronicos.Aplicacao.Mappers;
using APS.Cronicos.Dominio.Corporativo.Entidades;
using APS.Cronicos.Dominio.Corporativo.Repositories;
using APS.Cronicos.ViewModels.Corporativo;
using AutoMapper;
using System.Collections.Generic;

namespace APS.Cronicos.Aplicacao.Corporativo
{
    public sealed class UnidadeApp : IUnidadeApp
    {
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly IUnidadeRepository _unidadeRepository;

        public UnidadeApp(IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }

        public IEnumerable<UnidadeViewModel> Listar()
        {
            var lstUnidadesEntity = _unidadeRepository.Listar();
            var lstUnidadesVM = _mapper.Map<IEnumerable<UnidadeEntity>, IEnumerable<UnidadeViewModel>>(lstUnidadesEntity);
            return lstUnidadesVM;
        }
        public UnidadeViewModel ObterUnidade(int idUnidade)
        {
            var oUnidadeEntity = _unidadeRepository.ObterUnidade(idUnidade);
            var oUnidadeVM = _mapper.Map<UnidadeEntity, UnidadeViewModel>(oUnidadeEntity);
            return oUnidadeVM;
        }
    }
}

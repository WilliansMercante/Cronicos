using APS.Cronicos.Aplicacao.ContratoGestao.Interfaces;
using APS.Cronicos.Aplicacao.Mappers;
using APS.Cronicos.Dominio.Configuracao.Repositories;
using APS.Cronicos.Dominio.ContratoGestao.Repositories.Interfaces;
using APS.Cronicos.ViewModels.ContratoGestao;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APS.Cronicos.Aplicacao.ContratoGestao
{
    public sealed class ServicoApp : IServicoApp
    {
        private readonly DateTime _competencia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        private readonly IServicoRepository _servicoRepository;
        private readonly IServicoIgnoradoRepository _servicoIgnoradoRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();

        public ServicoApp
        (
            IServicoRepository servicoRepository,
             IServicoIgnoradoRepository servicoIgnoradoRepository
        )
        {
            _servicoRepository = servicoRepository;
            _servicoIgnoradoRepository = servicoIgnoradoRepository;
        }

        public IEnumerable<ServicoViewModel> Listar(int idUnidade)
        {
            var lstServicosEntity = _servicoRepository.Listar(_competencia, idUnidade);
            var lstServicosVM = _mapper.Map<List<ServicoViewModel>>(lstServicosEntity);

            RetirarServicosIgnorados(ref lstServicosVM);

            return lstServicosVM;
        }

        public ServicoViewModel Obter(int idUnidade, int idServico)
        {
            var oServicoEntity = _servicoRepository.Obter(_competencia, idUnidade, idServico);
            var oServicoVM = _mapper.Map<ServicoViewModel>(oServicoEntity);

            return oServicoVM;
        }

        private void RetirarServicosIgnorados(ref List<ServicoViewModel> lstServicosVM)
        {
            if (lstServicosVM.Count() > 0)
            {
                var lstServicosIgnorados = _servicoIgnoradoRepository.Listar().Select(p => p.IdServico);
                lstServicosVM = lstServicosVM.Where(p => !lstServicosIgnorados.Contains(p.Id)).ToList();
            }
        }
    }
}

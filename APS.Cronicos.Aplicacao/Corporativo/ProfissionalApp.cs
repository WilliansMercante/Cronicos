using APS.Cronicos.Aplicacao.Corporativo.Interfaces;
using APS.Cronicos.Aplicacao.Mappers;
using APS.Cronicos.Dominio.Corporativo.Repositories;
using APS.Cronicos.Dominio.Parametrizacao.Repositories.Interfaces;
using APS.Cronicos.ViewModels.Corporativo;

using AutoMapper;

using System.Collections.Generic;
using System.Linq;

namespace APS.Cronicos.Aplicacao.Corporativo
{
    public sealed class ProfissionalApp : IProfissionalApp
    {
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly IProfissionalRepository _profissionalRepository;

        public ProfissionalApp(IProfissionalRepository profissionalRepository, IParametroRepository parametroRepository)
        {
            _profissionalRepository = profissionalRepository;
        }
        public ProfissionalViewModel ConsultarPorCPF(string cpf)
        {
            var oMedicoEntity = _profissionalRepository.ConsultarPorCPF(cpf);
            return _mapper.Map<ProfissionalViewModel>(oMedicoEntity);
        }

        public IEnumerable<ProfissionalViewModel> ListarPorCargo(int idUnidade, string idCargo)
        {
            var lstProfissionais = _profissionalRepository.ListarPorCargo(idUnidade, idCargo);
            return _mapper.Map<IEnumerable<ProfissionalViewModel>>(lstProfissionais);
        }
      
        public IEnumerable<ProfissionalViewModel> ListarMedicosPorUnidade(int idUnidade)
        {
            var lstMedicos = _profissionalRepository.ListarMedicosPorUnidade(idUnidade);
            return _mapper.Map<IEnumerable<ProfissionalViewModel>>(lstMedicos);
        }

        public IEnumerable<ProfissionalViewModel> ListarEnfermeirosPorUnidade(int idUnidade)
        {
            var lstEnfermeiros = _profissionalRepository.ListarEnfermeirosPorUnidade(idUnidade);
            return _mapper.Map<IEnumerable<ProfissionalViewModel>>(lstEnfermeiros);
        }

        public IEnumerable<ProfissionalViewModel> ListarProfissionaisPorUnidade(int idUnidade)
        {
            var lstProfissionais = _profissionalRepository.ListarProfissionaisPorUnidade(idUnidade);
            return _mapper.Map<IEnumerable<ProfissionalViewModel>>(lstProfissionais);
        }

        public IEnumerable<ProfissionalViewModel> ListarMedicosPorEquipeUnidade(int idEquipe, int idUnidade)
        {
            var lstMedicos = _profissionalRepository.ListarMedicosPorEquipeUnidade(idEquipe, idUnidade);
            return _mapper.Map<IEnumerable<ProfissionalViewModel>>(lstMedicos);
        }

        public IEnumerable<ProfissionalViewModel> ListarEnfermeirosPorEquipeUnidade(int idEquipe, int idUnidade)
        {
            var lstEnfermeiros = _profissionalRepository.ListarEnfermeirosPorEquipeUnidade(idEquipe, idUnidade);
            return _mapper.Map<IEnumerable<ProfissionalViewModel>>(lstEnfermeiros);
        }
    }
}

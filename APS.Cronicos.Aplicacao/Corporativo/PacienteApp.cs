using APS.Cronicos.Aplicacao.Corporativo.Interfaces;
using APS.Cronicos.Aplicacao.Interfaces;
using APS.Cronicos.Aplicacao.Mappers;
using APS.Cronicos.Dominio.Corporativo.Entidades;
using APS.Cronicos.Dominio.Corporativo.Repositories;
using APS.Cronicos.ViewModels.Corporativo;

using AutoMapper;

namespace APS.Cronicos.Aplicacao.Corporativo
{
    public sealed class PacienteApp : BaseApp, IPacienteApp
    {
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteApp(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public void Atualizar(PacienteViewModel paciente)
        {
            var oPacienteEntity = _mapper.Map<PacienteEntity>(paciente);
            _pacienteRepository.Atualizar(oPacienteEntity, Usuario.Token);
        }

        public int Incluir(PacienteViewModel paciente)
        {
            var oPacienteEntity = _mapper.Map<PacienteEntity>(paciente);
            return _pacienteRepository.Incluir(oPacienteEntity, Usuario.Token);
        }

        public PacienteViewModel ConsultarPorCNS(string cns)
        {
            var oPacienteEntity = _pacienteRepository.ConsultarPorCNS(cns, Usuario.Token);
            return _mapper.Map<PacienteViewModel>(oPacienteEntity);
        }
    }
}

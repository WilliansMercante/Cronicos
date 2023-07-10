using APS.Cronicos.Aplicacao.Mappers;
using APS.Cronicos.Aplicacao.Seguranca.Interfaces;
using APS.Cronicos.Dominio.Seguranca.Entidades;
using APS.Cronicos.Dominio.Seguranca.Repositories.Interfaces;
using APS.Cronicos.ViewModels.Seguranca;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;

namespace APS.Cronicos.Aplicacao.Seguranca
{
    public class UsuarioApp : IUsuarioApp
    {
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly int idSistema;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioApp(IConfiguration configuration, IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            idSistema = Convert.ToInt32(configuration.GetSection("AppSettings:IdSistema").Value);
        }

        public UsuarioViewModel Autenticar(string cpf, string senha)
        {
            var oUsuarioEntity = _usuarioRepository.Autenticar(cpf, senha, idSistema);
            var oUsuarioVM = _mapper.Map<UsuarioEntity, UsuarioViewModel>(oUsuarioEntity);

            var oGrupoEntity = _usuarioRepository.ObterGrupo(oUsuarioVM.Id, idSistema, oUsuarioVM.Token);
            oUsuarioVM.Grupo = _mapper.Map<GrupoEntity, GrupoViewModel>(oGrupoEntity);

            return oUsuarioVM;
        }
    }
}

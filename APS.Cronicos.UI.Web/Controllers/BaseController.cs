﻿using APS.Cronicos.Dominio.Helpers;
using APS.Cronicos.UI.Web.App_Start;
using APS.Cronicos.UI.Web.Extensions;
using APS.Cronicos.ViewModels.Seguranca;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace APS.Cronicos.UI.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IConfiguration _configuration;
        protected IDataProtectionProvider _protectionProvider;
        protected readonly IMapper _mapper = MapperConfig.RegisterMappers();

        public BaseController()
        {
        }

        public BaseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BaseController(IConfiguration configuration, IDataProtectionProvider protectionProvider)
        {
            _configuration = configuration;
            _protectionProvider = protectionProvider;
        }

        public enum TipoMensagem
        {
            Sucesso,
            Erro,
            Alerta,
            Informacao
        }

        public void ExibirMensagem(string mensagem, TipoMensagem tipoMensagem)
        {
            if (!string.IsNullOrEmpty(mensagem))
            {
                switch (tipoMensagem)
                {
                    case TipoMensagem.Sucesso:

                        TempData.Remove("Sucesso");
                        TempData.Add("Sucesso", mensagem);
                        break;

                    case TipoMensagem.Erro:

                        TempData.Remove("Erro");
                        TempData.Add("Erro", mensagem);
                        break;

                    case TipoMensagem.Alerta:

                        TempData.Remove("Alerta");
                        TempData.Add("Alerta", mensagem);
                        break;

                    case TipoMensagem.Informacao:

                        TempData.Remove("Informacao");
                        TempData.Add("Informacao", mensagem);
                        break;
                }
            }
        }

        public UsuarioViewModel Usuario
        {
            get
            {
                var usuario = AppHttpContextHelper.Current.User.Claims.Where(p => p.Type.Equals("Usuario")).FirstOrDefault().Value;
                var oUsuario = JsonConvert.DeserializeObject<UsuarioViewModel>(usuario);
                return oUsuario;
            }
        }

        public string ChavePublica
        {
            get
            {
                return _configuration.GetSection("AppSettings:ChavePublica").Value;
            }
        }

        public string UrlApiSegurancaLogin
        {
            get
            {
                return _configuration.GetSection("WebApis:Seguranca.Login").Value;
            }
        }

        public int IdSistema
        {
            get
            {
                return Convert.ToInt32(_configuration.GetSection("AppSettings:IdSistema").Value);
            }
        }

        public int IdUnidadeSelecionada
        {
            get { return HttpContext.Session.Get<int>("IdUnidadeSelecionada"); }
            set { HttpContext.Session.Set("IdUnidadeSelecionada", value); }
        }       
    }
}
using APS.Cronicos.Dominio.Proxy.Entidades;
using APS.Cronicos.Dominio.Seguranca.Entidades;
using APS.Cronicos.Dominio.Seguranca.Repositories.Interfaces;
using APS.Cronicos.Infra.Data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace APS.Cronicos.Infra.Data.Repositories.Seguranca
{
    public sealed class SistemaRepository : ProxyExtension, ISistemaRepository
    {
        private readonly string _hostWebApi;
        private readonly int _idSistema;

        public SistemaRepository(IConfiguration configuration, IOptions<ProxyEntity> proxy) : base(proxy)
        {
            _hostWebApi = configuration.GetSection("WebApis:Seguranca.Login").Value;
            _idSistema = Convert.ToInt32(configuration.GetSection("AppSettings:IdSistema").Value);
        }
        public SistemaEntity ObterSistema()
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"api/Sistema/ObterSistema/{_idSistema}", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };

                var oRetorno = servico.Execute<RetornoEntity>(pedido);

                if (!oRetorno.Data.FlSucesso)
                    throw new Exception(oRetorno.Data.Mensagem);

                return JsonConvert.DeserializeObject<SistemaEntity>(oRetorno.Data.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }

        public void Verificar()
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"api/Sistema/ObterSistema/{_idSistema}", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };

                var oRetorno = servico.Execute<RetornoEntity>(pedido);

                if (!oRetorno.Data.FlSucesso)
                    throw new Exception(oRetorno.Data.Mensagem);
            }
            catch
            {
                throw;
            }
        }
    }
}
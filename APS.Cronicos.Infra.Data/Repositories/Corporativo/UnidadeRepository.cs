using APS.Cronicos.Dominio.Corporativo.Repositories;
using APS.Cronicos.Dominio.Proxy.Entidades;
using APS.Cronicos.Dominio.Seguranca.Entidades;
using APS.Cronicos.Infra.Data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using UnidadeEntity = APS.Cronicos.Dominio.Corporativo.Entidades.UnidadeEntity;

namespace APS.Cronicos.Infra.Data.Repositories.Corporativo
{
    public sealed class UnidadeRepository : ProxyExtension, IUnidadeRepository
    {
        private readonly string _hostWebApi;
        public UnidadeRepository(IConfiguration configuration, IOptions<ProxyEntity> proxy) : base(proxy)
        {
            _hostWebApi = configuration.GetSection("WebApis:Corporativo").Value;
        }
        public IEnumerable<UnidadeEntity> Listar()
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Unidade/ListarUnidades", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<List<UnidadeEntity>>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }

        public UnidadeEntity ObterUnidade(int idUnidade)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Unidade/ObterUnidade/{idUnidade}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<UnidadeEntity>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }
    }
}
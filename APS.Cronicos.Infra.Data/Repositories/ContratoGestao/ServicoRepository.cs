using APS.Cronicos.Dominio.ContratoGestao.Entidades;
using APS.Cronicos.Dominio.ContratoGestao.Repositories.Interfaces;
using APS.Cronicos.Dominio.Proxy.Entidades;
using APS.Cronicos.Infra.Data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APS.Cronicos.Infra.Data.Repositories.ContratoGestao
{
    public sealed class ServicoRepository : ProxyExtension, IServicoRepository
    {
        private readonly string _hostWebApi;
        public ServicoRepository(IConfiguration configuration, IOptions<ProxyEntity> proxy) : base(proxy)
        {
            _hostWebApi = configuration.GetSection("WebApis:HistoricoContratoGestao").Value;
        }

        public IEnumerable<ServicoEntity> Listar(DateTime competencia, int idUnidade)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Servico/ListarPorUnidade/{competencia:yyyy-MM-dd}/{idUnidade}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoHistoricoContratoGestaoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<List<ServicoEntity>>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }

        public ServicoEntity Obter(DateTime competencia, int idUnidade, int idServico)
        {
            var lstServicosEntity = Listar(competencia, idUnidade).ToList();
            return lstServicosEntity.FirstOrDefault(p => p.Id.Equals(idServico));
        }
    }
}

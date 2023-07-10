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
    public sealed class UnidadeRepository : ProxyExtension, IUnidadeRepository
    {
        private readonly string _hostWebApi;
        public UnidadeRepository(IConfiguration configuration, IOptions<ProxyEntity> proxy) : base(proxy)
        {
            _hostWebApi = configuration.GetSection("WebApis:HistoricoContratoGestao").Value;
        }

        public IEnumerable<UnidadeEntity> ListarUnidades(DateTime competencia, bool flListarTodasUnidades, List<int> lstCnesUnidades)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"api/Unidade/Listar/{competencia:yyyy-MM-dd}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoHistoricoContratoGestaoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                var lstUnidades = JsonConvert.DeserializeObject<List<UnidadeEntity>>(oRetornoApi.Objetos[0].ToString());

                if (!flListarTodasUnidades)
                    lstUnidades = lstUnidades.Where(p => lstCnesUnidades.Contains(Convert.ToInt32(p.Cnes))).ToList();

                return lstUnidades;
            }
            catch
            {
                throw;
            }
        }

        public UnidadeEntity ObterPorCnes(string cnes)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"api/Unidade/ObterPorCnes/{cnes}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoHistoricoContratoGestaoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<UnidadeEntity>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }

        public UnidadeEntity ObterUnidade(DateTime competencia, int idUnidade)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"api/Unidade/ObterUnidade/{competencia:yyyy-MM-dd}/{idUnidade}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoHistoricoContratoGestaoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<UnidadeEntity>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<UnidadeEntity> ListarPorSupervisao(DateTime competencia, int idSupervisao)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"api/Unidade/ListarPorSupervisao/{competencia:yyyy-MM-dd}/{idSupervisao}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoHistoricoContratoGestaoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<List<UnidadeEntity>>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }
    }
}

using APS.Cronicos.Dominio.ContratoGestao.Entidades;
using APS.Cronicos.Dominio.Corporativo.Entidades;
using APS.Cronicos.Dominio.Corporativo.Repositories;
using APS.Cronicos.Dominio.Proxy.Entidades;
using APS.Cronicos.Infra.Data.Extensions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using Newtonsoft.Json;

using RestSharp;

using System;

namespace APS.Cronicos.Infra.Data.Repositories.Corporativo
{
    public sealed class PacienteRepository : ProxyExtension, IPacienteRepository
    {
        private readonly string _hostWebApi;
        public PacienteRepository(IConfiguration configuration, IOptions<ProxyEntity> proxy) : base(proxy)
        {
            _hostWebApi = configuration.GetSection("WebApis:Corporativo").Value;
        }

        public void Atualizar(PacienteEntity paciente, string token)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Paciente/Atualizar", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                pedido.AddHeader("Authorization", string.Concat("bearer ", token));

                pedido.AddJsonBody(paciente);

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoCorporativoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

            }
            catch
            {
                throw;
            }
        }

        public int Incluir(PacienteEntity paciente, string token)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Paciente/Incluir", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                pedido.AddHeader("Authorization", string.Concat("bearer ", token));

                pedido.AddJsonBody(paciente);

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoCorporativoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return Convert.ToInt32(oRetornoApi.Objetos[0]);

            }
            catch
            {
                throw;
            }
        }

        public PacienteEntity ConsultarPorCNS(string cns, string token)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Paciente/ConsultarPorCNS/{cns}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                pedido.AddHeader("Authorization", string.Concat("bearer ", token));

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoCorporativoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<PacienteEntity>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }
    }
}

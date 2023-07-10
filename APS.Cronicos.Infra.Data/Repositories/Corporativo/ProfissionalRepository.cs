using APS.Cronicos.Dominio.Corporativo.Entidades;
using APS.Cronicos.Dominio.Corporativo.Repositories;
using APS.Cronicos.Dominio.Proxy.Entidades;
using APS.Cronicos.Infra.Data.Extensions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using Newtonsoft.Json;

using RestSharp;

using System;
using System.Collections.Generic;

namespace APS.Cronicos.Infra.Data.Repositories.Corporativo
{
    public sealed class ProfissionalRepository : ProxyExtension, IProfissionalRepository
    {
        private readonly string _hostWebApi;
        public ProfissionalRepository(IConfiguration configuration, IOptions<ProxyEntity> proxy) : base(proxy)
        {
            _hostWebApi = configuration.GetSection("WebApis:Corporativo").Value;
        }

        public ProfissionalEntity ConsultarPorCPF(string cpf)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Profissional/ConsultarPorCPF/{cpf}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoCorporativoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<ProfissionalEntity>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<ProfissionalEntity> ListarPorCargo(int idUnidade, string idCargo)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Profissional/ListarPorCargo/{idUnidade}/{idCargo}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoCorporativoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<List<ProfissionalEntity>>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ProfissionalEntity> Listar(int idUnidade, string[]? idsCargos = null)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Profissional/Listar/{idUnidade}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                pedido.AddJsonBody(new { idsCargos });

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoCorporativoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<List<ProfissionalEntity>>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<ProfissionalEntity> ListarMedicosPorUnidade(int idUnidade)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Profissional/ListarMedicosPorUnidade/{idUnidade}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoCorporativoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<List<ProfissionalEntity>>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ProfissionalEntity> ListarEnfermeirosPorUnidade(int idUnidade)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Profissional/ListarEnfermeirosPorUnidade/{idUnidade}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoCorporativoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<List<ProfissionalEntity>>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ProfissionalEntity> ListarProfissionaisPorUnidade(int idUnidade)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Profissional/Listar/{idUnidade}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoCorporativoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<List<ProfissionalEntity>>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ProfissionalEntity> ListarMedicosPorEquipeUnidade(int idEquipe, int idUnidade)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Profissional/ListarMedicosPorEquipe/{idUnidade}/{idEquipe}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoCorporativoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<List<ProfissionalEntity>>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ProfissionalEntity> ListarEnfermeirosPorEquipeUnidade(int idEquipe, int idUnidade)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Profissional/ListarEnfermeirosPorEquipe/{idUnidade}/{idEquipe}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoCorporativoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<List<ProfissionalEntity>>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }
    }
}

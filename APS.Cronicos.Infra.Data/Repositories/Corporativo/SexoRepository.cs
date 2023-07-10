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
    public sealed class SexoRepository : ProxyExtension, ISexoRepository
    {
        private readonly string _hostWebApi;
        public SexoRepository(IConfiguration configuration, IOptions<ProxyEntity> proxy) : base(proxy)
        {
            _hostWebApi = configuration.GetSection("WebApis:Corporativo").Value;
        }
        public IEnumerable<SexoEntity> Listar()
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Sexo/Listar", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoCorporativoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<IEnumerable<SexoEntity>>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }
    }
}

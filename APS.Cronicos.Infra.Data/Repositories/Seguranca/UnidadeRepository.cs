using APS.Cronicos.Dominio.Proxy.Entidades;
using APS.Cronicos.Dominio.Seguranca.Entidades;
using APS.Cronicos.Dominio.Seguranca.Repositories.Interfaces;
using APS.Cronicos.Infra.Data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APS.Cronicos.Infra.Data.Repositories.Seguranca
{
    public sealed class UnidadeRepository : ProxyExtension, IUnidadeRepository
    {
        private readonly string _hostWebApi;

        public UnidadeRepository(IConfiguration configuration, IOptions<ProxyEntity> proxy) : base(proxy)
        {
            _hostWebApi = configuration.GetSection("WebApis:Seguranca.Login").Value;
        }

        public IEnumerable<UnidadeEntity> ListarUnidadesPermissao(int idUsuario, int idSistema, string token)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Permissao/ListarUnidades/{idUsuario}/{idSistema}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                pedido.AddHeader("Authorization", string.Concat("Bearer ", token));

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<IEnumerable<UnidadeEntity>>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<int> ListarCnesUnidadesPermissao(int idUsuario, int idSistema, string token)
        {
            try
            {
                var lstCnesUnidades = ListarUnidadesPermissao(idUsuario, idSistema, token);
                return lstCnesUnidades.Select(p => p.Id).Distinct();
            }
            catch
            {
                throw;
            }
        }
    }
}
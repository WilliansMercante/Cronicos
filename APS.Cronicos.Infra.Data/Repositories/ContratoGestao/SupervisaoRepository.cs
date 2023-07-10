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
    public sealed class SupervisaoRepository : ProxyExtension, ISupervisaoRepository
    {
        private readonly string _hostWebApi;
        public SupervisaoRepository(IConfiguration configuration, IOptions<ProxyEntity> proxy) : base(proxy)
        {
            _hostWebApi = configuration.GetSection("WebApis:HistoricoContratoGestao").Value;
        }

        public IEnumerable<SupervisaoEntity> Listar(DateTime competencia)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"api/Supervisao/Listar/{competencia:yyyy-MM-dd}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoHistoricoContratoGestaoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<List<SupervisaoEntity>>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }

        public SupervisaoEntity ConsultarPorId(DateTime competencia, int idSupervisao)
        {
            try
            {
                var lstSupervisoesEntity = Listar(competencia);
                var oSupervisaEntity = lstSupervisoesEntity.FirstOrDefault(p => p.Id.Equals(idSupervisao));
                return oSupervisaEntity;
            }
            catch
            {
                throw;
            }
        }
    }
}

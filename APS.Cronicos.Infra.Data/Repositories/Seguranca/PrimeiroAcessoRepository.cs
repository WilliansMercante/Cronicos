using APS.Cronicos.Dominio.Proxy.Entidades;
using APS.Cronicos.Dominio.Seguranca.Entidades;
using APS.Cronicos.Dominio.Seguranca.Repositories.Interfaces;
using APS.Cronicos.Infra.Data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RestSharp;
using System;

namespace APS.Cronicos.Infra.Data.Repositories.Seguranca
{
    public sealed class PrimeiroAcessoRepository : ProxyExtension, IPrimeiroAcessoRepository
    {
        private readonly string _hostWebApi;

        public PrimeiroAcessoRepository(IConfiguration configuration, IOptions<ProxyEntity> proxy) : base(proxy)
        {
            _hostWebApi = configuration.GetSection("WebApis:Seguranca.Login").Value;
        }

        public string TrocarSenha(string token, int idUsuario, string emailPrincipal, string emailSecundario, string senha, string senhaConfirmada, int idSistema)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"api/Usuario/PrimeiroAcesso", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };

                pedido.AddHeader("Authorization", string.Concat("bearer ", token));

                pedido.AddParameter("idUsuario", idUsuario, ParameterType.QueryString);
                pedido.AddParameter("emailPrincipal", emailPrincipal, ParameterType.QueryString);
                pedido.AddParameter("emailSecundario", emailSecundario, ParameterType.QueryString);
                pedido.AddParameter("senha", senha, ParameterType.QueryString);
                pedido.AddParameter("senhaConfirmada", senhaConfirmada, ParameterType.QueryString);
                pedido.AddParameter("idSistema", idSistema, ParameterType.QueryString);

                var oRetorno = servico.Execute<RetornoEntity>(pedido);

                if (!oRetorno.Data.FlSucesso)
                    throw new ApplicationException(oRetorno.Data.Mensagem);

                return oRetorno.Data != null ? oRetorno.Data.Mensagem : oRetorno.ErrorMessage;
            }
            catch
            {
                throw;
            }
        }
    }
}

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
    public sealed class TrocarSenhaRepository : ProxyExtension, ITrocarSenhaRepository
    {
        private readonly string _hostWebApi;
        private readonly string _chavePublica;

        public TrocarSenhaRepository(IConfiguration configuration, IOptions<ProxyEntity> proxy) : base(proxy)
        {
            _hostWebApi = configuration.GetSection("WebApis:Seguranca.Login").Value;
            _chavePublica = configuration.GetSection("AppSettings:ChavePublica").Value;
        }
        public string TrocarSenha(string cpf, string link, int idSistema)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"api/TrocarSenha/EnviarEmail/{idSistema}/{cpf}", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };

                pedido.AddJsonBody(link);

                var oRetorno = servico.Execute<RetornoEntity>(pedido);

                if (!oRetorno.Data.FlSucesso)
                    throw new Exception(oRetorno.Data.Mensagem);

                return oRetorno.Data.Mensagem;
            }
            catch
            {
                throw;
            }
        }
        public string NovaSenha(string cpf, string hash, string senha, string confirmacao, int idSistema)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"api/TrocarSenha/NovaSenha", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };

                pedido.AddParameter("cpf", cpf, ParameterType.QueryString);
                pedido.AddParameter("hash", hash, ParameterType.QueryString);
                pedido.AddParameter("senha", senha, ParameterType.QueryString);
                pedido.AddParameter("confirmacao", confirmacao, ParameterType.QueryString);
                pedido.AddParameter("idSistema", idSistema, ParameterType.QueryString);

                var oRetorno = servico.Execute<RetornoEntity>(pedido);

                if (!oRetorno.Data.FlSucesso)
                    throw new Exception(oRetorno.Data.Mensagem);

                return oRetorno.Data.Mensagem;
            }
            catch
            {
                throw;
            }
        }
    }
}

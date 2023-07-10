using APS.Cronicos.Dominio.Proxy.Entidades;
using APS.Cronicos.Dominio.Seguranca.Entidades;
using APS.Cronicos.Dominio.Seguranca.Repositories.Interfaces;
using APS.Cronicos.Infra.Data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace APS.Cronicos.Infra.Data.Repositories.Seguranca
{
    public sealed class UsuarioRepository : ProxyExtension, IUsuarioRepository
    {
        private readonly string _hostWebApi;

        public UsuarioRepository(IConfiguration configuration, IOptions<ProxyEntity> proxy) : base(proxy)
        {
            _hostWebApi = configuration.GetSection("WebApis:Seguranca.Login").Value;
        }
        public UsuarioEntity Autenticar(string cpf, string senha, int idSistema)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Usuario/Autenticar", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                pedido.AddParameter("cpf", cpf);
                pedido.AddParameter("senha", senha);
                pedido.AddParameter("idSistema", idSistema);

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoEntity>(servico.Execute(pedido).Content);

                if (oRetornoApi == null)
                    throw new ApplicationException("Não foi possível comunicação");

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<UsuarioEntity>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }

        public GrupoEntity ObterGrupo(int idUsuario, int idSistema, string token)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Usuario/ObterGrupo/{idUsuario}/{idSistema}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                pedido.AddHeader("Authorization", string.Concat("Bearer ", token));

                var oRetornoApi = JsonConvert.DeserializeObject<RetornoEntity>(servico.Execute(pedido).Content);

                if (!oRetornoApi.FlSucesso)
                    throw new Exception(oRetornoApi.Mensagem);

                return JsonConvert.DeserializeObject<GrupoEntity>(oRetornoApi.Objetos[0].ToString());
            }
            catch
            {
                throw;
            }
        }

        public async Task<RetornoEntity> AtualizarEmail(int idUsuario, string emailPrincipal, string emailSecundario, string token)
        {
            try
            {
                var servico = new RestClient(_hostWebApi);

                VerificarProxy(servico);

                var pedido = new RestRequest($"/api/Usuario/AtualizarEmails/{idUsuario}/{emailPrincipal}/{emailSecundario}", Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    Timeout = -1
                };

                pedido.AddHeader("Authorization", string.Concat("Bearer ", token));

                var response = await servico.ExecuteAsync(pedido);
                var oRetornoApi = JsonConvert.DeserializeObject<RetornoEntity>(response.Content);

                if (!oRetornoApi.FlSucesso)
                    throw new ApplicationException(oRetornoApi.Mensagem);

                return oRetornoApi;
            }
            catch
            {
                throw;
            }
        }
    }
}
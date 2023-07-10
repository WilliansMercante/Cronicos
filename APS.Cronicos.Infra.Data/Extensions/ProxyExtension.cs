using APS.Cronicos.Dominio.Proxy.Entidades;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Net;

namespace APS.Cronicos.Infra.Data.Extensions
{
    public class ProxyExtension
    {
        private readonly ProxyEntity _proxy;

        public ProxyExtension(IOptions<ProxyEntity> proxy)
        {
            _proxy = proxy.Value;
        }

        public void VerificarProxy(RestClient srvCliente)
        {
            if (_proxy.Habilitado)
            {
                srvCliente.Proxy = new WebProxy(_proxy.Host, _proxy.Porta);

                if (_proxy.UseDefaultCredentials)
                    srvCliente.Proxy.Credentials = CredentialCache.DefaultCredentials;
                else
                    srvCliente.Proxy.Credentials = new NetworkCredential(_proxy.Usuario, _proxy.Senha, _proxy.Dominio);
            }
        }
    }
}
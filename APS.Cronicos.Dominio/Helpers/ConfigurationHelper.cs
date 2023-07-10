using Microsoft.Extensions.Configuration;
using System;

namespace APS.Cronicos.Dominio.Helpers
{
    public static class ConfigurationHelper
    {
        static IServiceProvider services = null;

        /// <summary>
        /// Provides static access to the framework's services provider
        /// </summary>
        public static IServiceProvider Services
        {
            get { return services; }
            set
            {
                if (services != null)
                    throw new Exception("Não é possível definir uma vez que um valor já foi definido.");

                services = value;
            }
        }

        /// <summary>
        /// Provides static access to the current HttpContext
        /// </summary>
        public static IConfiguration Configuration
        {
            get
            {
                IConfiguration configuration = services.GetService(typeof(IConfiguration)) as IConfiguration;
                return configuration;
            }
        }

    }
}

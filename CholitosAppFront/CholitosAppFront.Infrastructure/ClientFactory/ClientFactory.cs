using CholitosAppFront.Core.Configuration;
using CholitosAppFront.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CholitosAppFront.Infrastructure.ClientFactory
{
    public class ClientFactory : IClientFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IProperties _properties;

        public ClientFactory(IServiceProvider serviceProvider, IProperties properties) { 
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _properties = properties ?? throw new ArgumentNullException(nameof(properties));
        }

        public HttpClient GetExternalServices(EServices eServices) {

            HttpClient client = new HttpClient();

            switch (eServices) {
                case EServices.GimnasioService:
                    client.BaseAddress = new Uri(_properties.UrlGimnasioService);
                    break;
            }

            return client;
        }
    }
}

using CholitosAppFront.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CholitosAppFront.Infrastructure.ClientFactory
{
    public interface IClientFactory
    {
        HttpClient GetExternalServices(EServices eServices);
    }
}

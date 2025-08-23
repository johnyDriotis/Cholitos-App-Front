using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CholitosAppFront.Core.Services.Interfaces
{
    public interface IGimnasioService
    {
        Task<string> ConsumePostMethod(string controller, string action, object request = null);
    }
}

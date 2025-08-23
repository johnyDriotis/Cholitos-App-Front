using System.Net;

namespace CholitosAppFront.Core.Response
{
    public class ResponseStatus
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Descripcion { get; set; }
    }
}

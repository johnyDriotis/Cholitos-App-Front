
namespace CholitosAppFront.Core.Response
{
    public class GenericResponse<T>
    {
        public ResponseStatus HttpResponseStatus { get; set; }
        public T Item { get; set; }
    }
}

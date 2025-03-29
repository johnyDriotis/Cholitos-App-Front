using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CholitosAppFront.Core.Response
{
    public class GenericResponse<T>
    {
        public bool GeneroError { get; set; }
        public T Item { get; set; }
        public string ErrorGenerado { get; set; }
    }
}

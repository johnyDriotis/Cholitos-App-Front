using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CholitosAppFront.Core.DTOs
{
    public class MembershipDto
    {
        public int IdCliente { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Tipo { get; set; }
    }
}

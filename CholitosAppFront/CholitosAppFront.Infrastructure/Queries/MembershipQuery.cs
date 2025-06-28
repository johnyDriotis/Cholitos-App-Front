using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CholitosAppFront.Infrastructure.Queries
{
    public class MembershipQuery
    {
        public static string AddMembership()
        {
            return @"INSERT INTO Membresia(
						IdCliente, FechaPago, FechaInicio, FechaFin, Tipo)
					VALUES(
						@IdCliente, @FechaPago, @FechaInicio, @FechaFin, @Tipo
					)";
        }
    }
}

namespace CholitosAppFront.Infrastructure.Queries
{
    public class ClientQuery
    {
        public static string GetAllClients() {
            return @"SELECT 
						CodigoCliente	[Codigo_Cliente],
						CodigoGimnasio	[Codigo_Gimnasio],
						PrimerNombre	[Primer_Nombre],
						SegundoNombre	[Segundo_Nombre],
						PrimerApellido	[Primer_Apellido],
						SegundoApellido	[Segundo_Apellido],
						ApellidoCasada	[Apellido_Casada]
					FROM 
						Cliente";
        }

		public static string AgregarCliente() {
			return @"INSERT INTO Cliente(
						CodigoGimnasio, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, 
						ApellidoCasada)
					VALUES(
						@CodigoGimnasio, @PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido,
						@ApellidoCasada
					))";
		}

        public static string ModificarCliente()
        {
			return @"UPDATE 
						Cliente
					SET
						CodigoGimnasio = @CodigoGimnasio,
						PrimerNombre = @PrimerNombre,
						SegundoNombre = @SegundoNombre,
						PrimerApellido = @PrimerApellido,
						SegundoApellido = @SegundoApellido,
						ApellidoCasada = @ApellidoCasada
					WHERE
						CodigoCliente = @CodigoCliente";
        }

        public static string EliminarCliente()
        {
            return @"DELETE FROM 
						Cliente 
					WHERE 
						CodigoCliente = @CodigoCliente";
        }
    }
}

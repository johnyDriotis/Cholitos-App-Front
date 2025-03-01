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
    }
}

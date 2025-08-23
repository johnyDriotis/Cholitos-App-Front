namespace CholitosAppFront.Core.Configuration
{
    public interface IProperties
    {
        // Propiedades solo de lectura
        string Server { get; }
        string Database { get; }
        string UserName { get; }
        string Password { get; }
        string IntegratedSecurity { get; }
        string UrlGimnasioService { get; }

        // Propiedades de lectura y escritura.
        string ConnectionString { get; set; }

    }
}

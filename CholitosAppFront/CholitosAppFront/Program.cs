using CholitosAppFront.Configuration;
using CholitosAppFront.Core.Configuration;
using CholitosAppFront.Core.Services.Interfaces;
using CholitosAppFront.Core.UseCases;
using CholitosAppFront.Core.UseCases.Interfaces;
using CholitosAppFront.Infrastructure.ClientFactory;
using CholitosAppFront.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

#region Inyeccion de servicios generales para la aplicacion
// Add services to container
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();
#endregion

#region Inicializacion de configuraciones
// Get configuration of appsettings.json
IConfiguration configuration = builder.Configuration;
Properties properties = new Properties(configuration);
#endregion

#region Inyeccion de dependencias.
// Other services
builder.Services.AddScoped<IProperties, Properties>();
builder.Services.AddScoped<IClientFactory, ClientFactory>();
builder.Services.AddHttpContextAccessor();

// Service to HttpClient to rest request and response
builder.Services.AddHttpClient();

// Services
builder.Services.AddScoped<IGimnasioService, GimnasioService>();

// UseCases
builder.Services.AddScoped<IClientUseCase, ClientUseCase>();
#endregion

#region Middlewares
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
#endregion

using CholitosAppFront.Configuration;
using CholitosAppFront.Core.Interfaces;
using CholitosAppFront.Core.UseCases;
using CholitosAppFront.Core.UseCases.Interfaces;
using CholitosAppFront.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

#region Contenedor de servicios e inyeccion de dependencias.

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

// Get configuration of appsettings.json
IConfiguration configuration = builder.Configuration;

Properties properties = new Properties(configuration);

// Other services
builder.Services.AddScoped<IProperties, Properties>();
builder.Services.AddAutoMapper(typeof(MapProfile));

// Repository services
builder.Services.AddScoped<IConnectionManagerRepository, ConnectionManagerRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();

// UseCases services
builder.Services.AddScoped<IClientUseCase, ClientUseCase>();
builder.Services.AddScoped<IMembershipUseCase, MembershipUseCase>();

#endregion

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

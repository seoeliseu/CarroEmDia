using CarroEmDia.Startup;
using CarroEmDia.Api.Endpoints;
using CarroEmDia.Api.Middlewares;
using CarroEmDia.Application.Shared.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

builder.Services.Configure<ApiKeySettings>(
    builder.Configuration.GetSection("ApiKeySettings")
);

app.UseMiddleware<AuthenticationMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "API running...");

app.MapUserEndpoints();
app.MapVehicleEndpoints();

app.Run();

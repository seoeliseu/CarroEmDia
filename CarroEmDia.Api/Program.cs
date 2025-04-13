using CarroEmDia.Startup;
using CarroEmDia.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "API running...");

app.MapUserEndpoints();
app.MapVehicleEndpoints();

app.Run();

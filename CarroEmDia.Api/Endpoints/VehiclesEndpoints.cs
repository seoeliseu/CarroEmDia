using CarroEmDia.Application.Dispatcher;
using CarroEmDia.Application.Commands.Vehicle;

namespace CarroEmDia.Api.Endpoints
{
    public static class VehiclesEndpoints
    {
        public static void MapVehicleEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/vehicles", async (CreateVehicleCommand command, IDispatcher dispatcher) =>
            {
                var vehicleId = await dispatcher.DispatchAsync(command);
                return Results.Created($"/vehicles/{vehicleId}", new { Id = vehicleId });
            });
        }
    }
}

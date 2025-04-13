using CarroEmDia.Api.Authorization;
using CarroEmDia.Application.Commands.User;
using CarroEmDia.Application.Dispatcher;

namespace CarroEmDia.Api.Endpoints
{
    public static class UsersEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            MapCommandEndpoints(app);
            MapQueryEndpoints(app);
        }

        private static void MapCommandEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/users", async (CreateUserCommand command, IDispatcher dispatcher) =>
            {
                var userId = await dispatcher.DispatchAsync(command);
                return Results.Created($"/users/{userId}", new { Id = userId });
            }).WithMetadata(new AllowApiKeyAttribute());

            app.MapPut("/users/{id}/password", async (int id, UpdateUserPasswordCommand command, IDispatcher dispatcher) =>
            {
                if (id != command.UserId)
                    return Results.BadRequest("ID na URL e no corpo não coincidem.");

                await dispatcher.DispatchAsync(command);

                return Results.NoContent();
            });

            app.MapPost("/users/auth", async (AuthenticateUserCommand command, IDispatcher dispatcher) =>
            {
                try
                {
                    var token = await dispatcher.DispatchAsync(command);
                    return Results.Ok(new { Token = token });
                }
                catch (UnauthorizedAccessException)
                {
                    return Results.Unauthorized();
                }
            }).WithMetadata(new AllowApiKeyAttribute());
        }

        private static void MapQueryEndpoints(this IEndpointRouteBuilder app)
        {
            //app.MapGet("/users", async (IUserRepository userRepository) =>
            //{
            //    var users = await userRepository.GetAllAsync();
            //    return Results.Ok(users);
            //});
        }
    }
}

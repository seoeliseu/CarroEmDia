using Microsoft.Extensions.Options;
using CarroEmDia.Api.Authorization;
using CarroEmDia.Application.Shared.Configuration;

namespace CarroEmDia.Api.Middlewares
{
    public class AuthenticationMiddleware(RequestDelegate next, IOptions<ApiKeySettings> options)
    {
        private readonly RequestDelegate _next = next;
        private readonly string _apiKey = options.Value.PublicKey;

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();

            if (context.Request.Path.StartsWithSegments("/healthy"))
            {
                await _next(context);
                return;
            }

            var allowApiKey = endpoint?.Metadata.GetMetadata<AllowApiKeyAttribute>() != null;

            if (allowApiKey)
            {
                if (!context.Request.Headers.TryGetValue("X-Api-Key", out var key))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Header X-Api-Key está ausente.");
                    return;
                }

                if (key == _apiKey)
                {
                    await _next(context);
                    return;
                }

                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Token público inválido.");
                return;
            }
            else if (!context.User.Identity?.IsAuthenticated ?? true)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Usuário não autenticado.");
                return;
            }

            await _next(context);
        }
    }
}

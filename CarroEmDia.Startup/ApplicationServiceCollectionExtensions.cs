using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CarroEmDia.Startup
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddValidatorsFromAssemblyContaining<CriarUsuarioCommandValidator>();

            return services;
        }
    }
}

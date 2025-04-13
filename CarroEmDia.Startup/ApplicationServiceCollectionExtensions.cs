using CarroEmDia.Application.Dispatcher;
using CarroEmDia.Application.Shared.CQRS;
using Microsoft.Extensions.DependencyInjection;


namespace CarroEmDia.Startup
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IDispatcher, Dispatcher>();

            services.Scan(scan => scan
                            .FromAssemblyOf<Dispatcher>()
                            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
                            .AsImplementedInterfaces()
                            .WithScopedLifetime()
                            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                            .AsImplementedInterfaces()
                            .WithScopedLifetime());

            return services;
        }
    }
}

using CarroEmDia.Application.Dispatcher;
using CarroEmDia.Application.Shared.CQRS;
using Microsoft.Extensions.DependencyInjection;


namespace CarroEmDia.Startup
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IDispatcher, Dispatcher>();

            services.Scan(scan => scan
                            .FromAssemblyOf<Dispatcher>()
                            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
                            .AsImplementedInterfaces()
                            .WithTransientLifetime()
                            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                            .AsImplementedInterfaces()
                            .WithTransientLifetime());

            return services;
        }
    }
}

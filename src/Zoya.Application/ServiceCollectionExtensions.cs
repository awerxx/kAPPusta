using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Avvr.Kappusta.Zoya.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration
            => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
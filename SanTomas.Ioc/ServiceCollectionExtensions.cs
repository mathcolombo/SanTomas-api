using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace SanTomas.Ioc;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.RegisterServices(assembly);
        return services;
    }

    public static IServiceCollection RegisterServices(this IServiceCollection services, Assembly assembly)
    {
        var serviceTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any());

        foreach (var serviceType in serviceTypes)
        {
            var interfaces = serviceType.GetInterfaces();
            foreach (var interfaceType in interfaces)
            {
                services.AddScoped(interfaceType, serviceType);
            }
        }

        return services;
    }
}
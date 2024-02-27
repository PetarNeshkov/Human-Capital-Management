using HumanCapitalManagement.Common.Data.DependencyInjectionInterfaces;
using HumanCapitalManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace HumanCapitalManagement.Web.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDbContext<HumanCapitalManagementDbContext>(options => options
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        var serviceInterfaceType = typeof(ITransientService);
        var scopedInterfaceType = typeof(IScopedService);
        var singletonInterfaceType = typeof(ISingletonService);

        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Where(t =>
                    serviceInterfaceType.IsAssignableFrom(t) ||
                    scopedInterfaceType.IsAssignableFrom(t) ||
                    singletonInterfaceType.IsAssignableFrom(t)
                )
                .Select(t => new
                {
                    Service = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                }))
            .ToList();

        foreach (var type in types)
        {
            if (serviceInterfaceType.IsAssignableFrom(type.Service))
            {
                services.AddTransient(type.Service, type.Implementation);
            }
            else if (scopedInterfaceType.IsAssignableFrom(type.Service))
            {
                services.AddScoped(type.Service, type.Implementation);
            }
            else if (singletonInterfaceType.IsAssignableFrom(type.Service))
            {
                services.AddSingleton(type.Service, type.Implementation);
            }
        };

        return services;
    }
}
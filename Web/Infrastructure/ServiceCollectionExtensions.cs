using System.Reflection;
using HumanCapitalManagement.Business.BusinessServices;
using HumanCapitalManagement.Business.DependencyInjectionInterfaces;
using HumanCapitalManagement.Data;
using HumanCapitalManagement.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        var transientInterfaceType = typeof(IService);
        var scopedInterfaceType = typeof(IScopedService);
        var singletonInterfaceType = typeof(ISingletonService);
        
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Where(t =>
                    transientInterfaceType.IsAssignableFrom(t) ||
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
            if (transientInterfaceType.IsAssignableFrom(type.Service))
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
    
    public static IServiceCollection AddAntiForgeryHeader(this IServiceCollection services)
        => services
            .AddAntiforgery(options => options
                .HeaderName = "X-CSRF-TOKEN");
    
    public static IServiceCollection AddControllersWithAutoAntiForgeryTokenAttribute(this IServiceCollection services)
    {    
        services
            .AddControllersWithViews(options => options
                .Filters.Add<AutoValidateAntiforgeryTokenAttribute>());

        return services;
    }
    
    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services
            .AddDefaultIdentity<User>(options => options.SetIdentityOptions())
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<HumanCapitalManagementDbContext>();

        return services;
    }
    
    
}
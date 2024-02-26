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
}
using HumanCapitalManagement.Data;
using HumanCapitalManagement.Data.Seeding;
using Microsoft.EntityFrameworkCore;

namespace HumanCapitalManagement.Web.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetRequiredService<HumanCapitalManagementDbContext>();

            data.Database.Migrate();

            SeedData(app);

            return app;
        }

        private static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            using var scopedService= app.ApplicationServices.CreateScope();

            using var dbContext=scopedService.ServiceProvider.GetRequiredService<HumanCapitalManagementDbContext>();

            new HumanCapitalManagementDbContextSeeder()
                .SeedAsync(dbContext,scopedService.ServiceProvider)
                .GetAwaiter()
                .GetResult();

            return app;
        }
    }
}

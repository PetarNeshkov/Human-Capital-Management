namespace HumanCapitalManagement.Data.Seeding;

public class HumanCapitalManagementDbContextSeeder : ISeeder
{
    public async Task SeedAsync(HumanCapitalManagementDbContext dbContext, IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(dbContext);

        ArgumentNullException.ThrowIfNull(serviceProvider);

        var seeders = new List<ISeeder>()
        {
            new DepartmentSeeder(),
            new EmployeeSeeder(),
            new AdministratorSeeder(),
        };

        foreach (var seeder in seeders)
        {
            await seeder.SeedAsync(dbContext, serviceProvider);
            await dbContext.SaveChangesAsync();
        }
    }
}
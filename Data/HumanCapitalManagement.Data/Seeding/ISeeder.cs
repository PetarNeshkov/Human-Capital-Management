namespace HumanCapitalManagement.Data.Seeding
{
    public interface ISeeder
    {
        Task SeedAsync(HumanCapitalManagementDbContext dbContext, IServiceProvider serviceProvider);
    }
}

using HumanCapitalManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HumanCapitalManagement.Data.Seeding;

public class DepartmentSeeder : ISeeder
{
    public async Task SeedAsync(HumanCapitalManagementDbContext dbContext, IServiceProvider serviceProvider)
    {
        var isExistingDepartments = await dbContext.Departments.AnyAsync();

        if (isExistingDepartments)
        {
            return;
        }
        
        var departments= new List<Department>()
        {
            new()
            {
                Name = "HR"
            },
            new()
            {
                Name = "Development"
            },
            new()
            {
                Name = "Management"
            }
        };
        
        await dbContext.Departments.AddRangeAsync(departments);
    }
}
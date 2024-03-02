using HumanCapitalManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HumanCapitalManagement.Data.Seeding;

public class EmployeeSeeder : ISeeder
{
    public async Task SeedAsync(HumanCapitalManagementDbContext dbContext, IServiceProvider serviceProvider)
    {
        var isExistingEmployees = await dbContext.Employees.AnyAsync();

        if (isExistingEmployees)
        {
            return;
        }

        var employees = new List<Employee>
        {
            new()
            {
                Name = "Michael Todorov",
                DepartmentId = 1,
                HireDate = new DateTime(2017, 03, 04).ToUniversalTime(),
                Position = "HR Lead",
                Salary = 3000,
            },
            new()
            {
                Name = "Ivana Petrova",
                DepartmentId = 2,
                HireDate = new DateTime(2023, 12, 03).ToUniversalTime(),
                Position = "Junior Software Developer",
                Salary = 1300,
            },
            new()
            {
                Name = "Krasimir Stoyanova",
                DepartmentId = 2,
                HireDate = new DateTime(2015, 06, 03).ToUniversalTime(),
                Position = "Tech Lead",
                Salary = 8000,
            },
            new()
            {
                Name = "Blago Karakachanov",
                DepartmentId = 3,
                HireDate = new DateTime(2010, 03, 23).ToUniversalTime(),
                Position = "Manager",
                Salary = 20000
            }
        };
        
        await dbContext.Employees.AddRangeAsync(employees);
    }
}
using HumanCapitalManagement.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using static HumanCapitalManagement.Common.GlobalConstants.Administrator;

namespace HumanCapitalManagement.Data.Seeding;

public class AdministratorSeeder : ISeeder
{
    public async Task SeedAsync(HumanCapitalManagementDbContext dbContext, IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        var isExistingAdmin = await roleManager.RoleExistsAsync(AdministratorRoleName);

        if (!isExistingAdmin)
        {
            var role = new IdentityRole { Name = AdministratorRoleName };

            await roleManager.CreateAsync(role);

            var admin = new User
            {
                UserName = AdministratorUsername,
                FullName = AdministratorUsername,
                Email = AdministratorEmail,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(admin, AdministratorPassword);

            await userManager.AddToRoleAsync(admin, role.Name);
        }
    }
}
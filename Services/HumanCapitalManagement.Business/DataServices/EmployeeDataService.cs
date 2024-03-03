using HumanCapitalManagement.Business.DataServices.Interfaces;
using HumanCapitalManagement.Common.Data;
using HumanCapitalManagement.Data;
using HumanCapitalManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HumanCapitalManagement.Business.DataServices;

public class EmployeeDataService(HumanCapitalManagementDbContext db) 
    : DataService<Employee>(db), IEmployeeDataService
{
    public async Task<bool> ExistsByName(string name) 
        => await GetQuery(e => e.Name == name)
            .AnyAsync();

    public async Task<int> GetCountByAvailability(bool takeUnavailableItems = false)
        =>  await (takeUnavailableItems ? 
            GetQuery().CountAsync()
            : GetQuery().CountAsync(e => !e.IsDeleted));
    
}
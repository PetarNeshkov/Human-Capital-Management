using HumanCapitalManagement.Business.DependencyInjectionInterfaces;
using HumanCapitalManagement.Common.Data;
using HumanCapitalManagement.Data.Models;

namespace HumanCapitalManagement.Business.DataServices.Interfaces;

public interface IEmployeeDataService : IDataService<Employee>, IService
{
    Task<bool> ExistsByName(string name);

    Task<int> GetCountByAvailability(bool takeUnavailableItems = false);
    
}
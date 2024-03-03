using HumanCapitalManagement.Business.DependencyInjectionInterfaces;
using HumanCapitalManagement.Common.Data;
using HumanCapitalManagement.Data.Models;

namespace HumanCapitalManagement.Business.DataServices.Interfaces;

public interface IDepartmentDataService : IDataService<Department>, IService
{
    Task<bool> ExistsByName(string name);
}
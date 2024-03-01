using HumanCapitalManagement.Business.DependencyInjectionInterfaces;

namespace HumanCapitalManagement.Business.BusinessServices;

public interface IDepartmentBusinessService : IService
{
    Task<IEnumerable<TModel>> GetAllDepartments<TModel>();
}
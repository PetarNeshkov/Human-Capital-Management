using HumanCapitalManagement.Business.DependencyInjectionInterfaces;

namespace HumanCapitalManagement.Business.BusinessServices.Interfaces;

public interface IDepartmentBusinessService : IService
{
    Task<IEnumerable<TModel>> GetAllDepartments<TModel>();
}
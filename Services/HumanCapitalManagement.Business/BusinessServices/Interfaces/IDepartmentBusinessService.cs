using HumanCapitalManagement.Business.DependencyInjectionInterfaces;
using HumanCapitalManagement.Models.Admin.Departments;

namespace HumanCapitalManagement.Business.BusinessServices.Interfaces;

public interface IDepartmentBusinessService : IService
{
    Task<IEnumerable<TModel>> GetAllDepartments<TModel>();

    Task<bool> CreateDepartment(CreateDepartmentFormModel model);
}
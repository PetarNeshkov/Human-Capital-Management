using HumanCapitalManagement.Business.DependencyInjectionInterfaces;
using HumanCapitalManagement.Models.Admin.Employees;
using HumanCapitalManagement.Models.Employees;

namespace HumanCapitalManagement.Business.BusinessServices.Interfaces;

public interface IEmployeeBusinessService : IService
{
    Task<bool> CreateEmployee(CreateEmployeeFormModel model);
    
    Task<bool> UpdateEmployee(AdminEditEmployeesFormModel model);

    Task DeleteEmployee(int id);

    Task<int> GetNonDeletedCount();

    Task<EmployeesViewModel> GetCurrentEmployees(int page);
    
    Task<AdminEmployeesViewModel> GetAllEmployees(int page);

    Task<TService?> GetById<TService>(int id);
}
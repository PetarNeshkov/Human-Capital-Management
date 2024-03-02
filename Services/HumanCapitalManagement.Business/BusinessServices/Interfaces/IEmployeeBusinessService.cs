using HumanCapitalManagement.Business.DependencyInjectionInterfaces;
using HumanCapitalManagement.Models.Employees;

namespace HumanCapitalManagement.Business.BusinessServices.Interfaces;

public interface IEmployeeBusinessService : IService
{
    Task<bool> CreateEmployee(CreateEmployeeFormModel model);

    Task<EmployeesViewModel> GetCurrentEmployees(int page);
}
using HumanCapitalManagement.Business.DependencyInjectionInterfaces;
using HumanCapitalManagement.Business.Models;

namespace HumanCapitalManagement.Business.BusinessServices.Interfaces;

public interface IEmployeeBusinessService : IService
{
    Task<bool> CreateEmployee(EmployeesBusinessServiceModel model);
}
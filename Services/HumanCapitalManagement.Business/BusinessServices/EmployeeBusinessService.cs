using HumanCapitalManagement.Business.BusinessServices.Interfaces;
using HumanCapitalManagement.Business.DataServices.Interfaces;
using HumanCapitalManagement.Business.Models;
using HumanCapitalManagement.Data.Models;

namespace HumanCapitalManagement.Business.BusinessServices;

public class EmployeeBusinessService(IEmployeeDataService employeeDataService)
    : IEmployeeBusinessService
{
    public async Task<bool> CreateEmployee(EmployeesBusinessServiceModel model)
    {
        var exists = await employeeDataService.ExistsByName(model.Name);

        if (exists)
        {
            return false;
        }

        var employee = new Employee
        {
            Name = model.Name,
            DepartmentId = model.Department.Id,
            Department = model.Department,
        };

        await employeeDataService.Add(employee);
        await employeeDataService.SaveChanges();

        return true;
    }
}
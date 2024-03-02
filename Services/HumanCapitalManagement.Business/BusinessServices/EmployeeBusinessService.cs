using System.Globalization;
using HumanCapitalManagement.Business.BusinessServices.Interfaces;
using HumanCapitalManagement.Business.DataServices.Interfaces;
using HumanCapitalManagement.Data.Models;
using HumanCapitalManagement.Models.Employees;

namespace HumanCapitalManagement.Business.BusinessServices;

public class EmployeeBusinessService(IEmployeeDataService employeeDataService)
    : IEmployeeBusinessService
{
    public async Task<bool> CreateEmployee(CreateEmployeeFormModel model)
    {
        var exists = await employeeDataService.ExistsByName(model.Name);

        if (exists)
        {
            return false;
        }
        
        var dateString = model.HireDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        var formattedDate = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToUniversalTime();
        var employee = new Employee
        {
            Name = model.Name,
            DepartmentId = model.DepartmentId,
            HireDate = formattedDate,
            Salary = model.Salary,
            Position = model.Position
        };

        await employeeDataService.Add(employee);
        await employeeDataService.SaveChanges();

        return true;
    }
}
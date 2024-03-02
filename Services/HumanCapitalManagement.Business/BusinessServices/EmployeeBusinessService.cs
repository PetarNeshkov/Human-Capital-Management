using System.Globalization;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HumanCapitalManagement.Business.BusinessServices.Interfaces;
using HumanCapitalManagement.Business.DataServices.Interfaces;
using HumanCapitalManagement.Data.Models;
using HumanCapitalManagement.Models.Employees;
using Microsoft.EntityFrameworkCore;

using static HumanCapitalManagement.Common.GlobalConstants.Employee;

namespace HumanCapitalManagement.Business.BusinessServices;

public class EmployeeBusinessService(
    IEmployeeDataService employeeDataService,
    IMapper mapper)
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

    public async Task<EmployeesViewModel> GetCurrentEmployees(int page)
    {
        var count = await employeeDataService.GetCount();
        var skip = (page - 1) * EmployeesPerPage;

        var modelResult = new EmployeesViewModel();
        
        var pagination = PaginationProvider.PaginationProvider.PaginationHelper(page, count, EmployeesPerPage);
       var employees = await employeeDataService.GetQuery(filter: e => !e.IsDeleted, skip: skip, take: EmployeesPerPage)
            .ProjectTo<EmployeesListingModel>(mapper.ConfigurationProvider)
            .ToListAsync();

       return new EmployeesViewModel
       {
           Employees = employees,
           Pagination = pagination
       };
       
    }
}
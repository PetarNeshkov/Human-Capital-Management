using System.Globalization;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HumanCapitalManagement.Business.BusinessServices.Interfaces;
using HumanCapitalManagement.Business.DataServices.Interfaces;
using HumanCapitalManagement.Data.Models;
using HumanCapitalManagement.Models.Admin.Employees;
using HumanCapitalManagement.Models.Employees;
using Microsoft.EntityFrameworkCore;
using static HumanCapitalManagement.Business.PaginationProvider.PaginationProvider;
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
        var formattedDate = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            .ToUniversalTime();
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

    public async Task<bool> UpdateEmployee(AdminEditEmployeesFormModel model)
    {
        var employee = await employeeDataService.GetByName(model.Name);

        if (employee == null)
        {
            return false;
        }

        var dateString = model.HireDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        var formattedDate = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            .ToUniversalTime();

        employee.Name = model.Name;
        employee.DepartmentId = model.DepartmentId;
        employee.HireDate = formattedDate;
        employee.Salary = model.Salary;
        employee.Position = model.Position;

        employeeDataService.Update(employee);
        await employeeDataService.SaveChanges();

        return true;
    }

    public async Task DeleteEmployee(int id)
    {
        var employee = await employeeDataService.GetByIdQuery(id)
            .FirstOrDefaultAsync();

        if (employee != null)
        {
            employee.IsDeleted = true;
            employee.DeletedOn = DateTime.UtcNow;

            await employeeDataService.SaveChanges();
        }
    }

    public async Task<int> GetNonDeletedCount()
        => await employeeDataService.GetCountByAvailability();

    public async Task<EmployeesViewModel> GetCurrentEmployees(int page)
    {
        var count = await employeeDataService.GetCountByAvailability();
        var skip = (page - 1) * EmployeesPerPage;

        var pagination = PaginationHelper(page, count, EmployeesPerPage);
        var employees = await employeeDataService
            .GetQuery(filter: e => !e.IsDeleted,
                skip: skip,
                take: EmployeesPerPage,
                orderBy: e => e.Id,
                descending: false)
            .ProjectTo<EmployeesListingModel>(mapper.ConfigurationProvider)
            .ToListAsync();

        return new EmployeesViewModel
        {
            Employees = employees,
            Pagination = pagination
        };
    }

    public async Task<AdminEmployeesViewModel> GetAllEmployees(int page)
    {
        var count = await employeeDataService.GetCountByAvailability(true);
        var skip = (page - 1) * EmployeesPerPage;

        var pagination = PaginationHelper(page, count, EmployeesPerPage);
        var employees = await employeeDataService
            .GetQuery(
                orderBy: e => e.Id,
                descending: false,
                skip: skip,
                take: EmployeesPerPage
            )
            .ProjectTo<AdminEmployeesListingModel>(mapper.ConfigurationProvider)
            .ToListAsync();

        return new AdminEmployeesViewModel
        {
            Employees = employees,
            Pagination = pagination
        };
    }

    public async Task<TService?> GetById<TService>(int id)
        => await employeeDataService.GetByIdQuery(id)
            .ProjectTo<TService>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
}
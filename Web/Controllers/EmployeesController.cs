using AutoMapper;
using HumanCapitalManagement.Business.BusinessServices.Interfaces;
using HumanCapitalManagement.Business.Models;
using HumanCapitalManagement.Models.Departments;
using HumanCapitalManagement.Models.Employees;
using HumanCapitalManagement.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HumanCapitalManagement.Common.ErrorMessages.Employee;

namespace HumanCapitalManagement.Web.Controllers;

[Authorize]
public class EmployeesController(
    IEmployeeBusinessService employeeBusinessService,
    IMapper mapper)
    : Controller
{
    public IActionResult Create()
        => View(new CreateEmployeeFormModel
        {
            Departments = Enumerable.Empty<DepartmentsListingModel>()
        });

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var exists = await employeeBusinessService.CreateEmployee(model.Map<EmployeesBusinessServiceModel>(mapper));

        if (!exists)
        {
            ModelState.AddModelError(nameof(model.Name), EmployeeExistsErrorMessage);

            return View(model);
        }

        return RedirectToAction(nameof(Create));
    }
}
using HumanCapitalManagement.Business.BusinessServices.Interfaces;
using HumanCapitalManagement.Models.Departments;
using HumanCapitalManagement.Models.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HumanCapitalManagement.Common.ErrorMessages.Employee;

namespace HumanCapitalManagement.Web.Controllers;

[Authorize]
public class EmployeesController(
    IEmployeeBusinessService employeeBusinessService)
    : Controller
{
    public IActionResult Create()
        => View(new CreateEmployeeFormModel
        {
            HireDate = DateTime.Today,
        });

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var exists = await employeeBusinessService.CreateEmployee(model);

        if (!exists)
        {
            ModelState.AddModelError(nameof(model.Name), EmployeeExistsErrorMessage);

            return View(model);
        }

        return RedirectToAction(nameof(Create));
    }
}
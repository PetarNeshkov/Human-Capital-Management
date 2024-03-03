using HumanCapitalManagement.Business.BusinessServices.Interfaces;
using HumanCapitalManagement.Models.Admin.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static HumanCapitalManagement.Common.GlobalConstants.Administrator;
using static HumanCapitalManagement.Common.ErrorMessages.Employee;

namespace HumanCapitalManagement.Web.Areas.Admin.Controllers;

[Area(AdministratorUsername)]
[Authorize(Roles =AdministratorRoleName)]
public class EmployeesController (
    IEmployeeBusinessService employeeBusinessService)
    : Controller
{
    public async Task<IActionResult> All([FromQuery] int page = 1)
    {
        var model = await employeeBusinessService.GetAllEmployees(page);

        return View(model);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var employee = await employeeBusinessService.GetById<AdminEditEmployeesFormModel>(id);

        if (employee == null)
        {
            return NotFound();
        }
        
        return View(employee);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(AdminEditEmployeesFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var exists = await employeeBusinessService.UpdateEmployee(model);

        if (!exists)
        {
            ModelState.AddModelError(nameof(model.Name), EmployeeExistsErrorMessage);

            return View(model);
        }

        return RedirectToAction(nameof(All));
    }
}
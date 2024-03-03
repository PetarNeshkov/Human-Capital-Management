using HumanCapitalManagement.Business.BusinessServices.Interfaces;
using HumanCapitalManagement.Models.Admin.Departments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static HumanCapitalManagement.Common.ErrorMessages.Department;

using static HumanCapitalManagement.Common.GlobalConstants.Administrator;

namespace HumanCapitalManagement.Web.Areas.Admin.Controllers;

[Area(AdministratorUsername)]
[Authorize(Roles =AdministratorRoleName)]
public class DepartmentsController(
    IDepartmentBusinessService departmentBusinessService)
    : Controller
{
    public IActionResult Create()
        => View(new CreateDepartmentFormModel());
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateDepartmentFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var exists = await departmentBusinessService.CreateDepartment(model);

        if (!exists)
        {
            ModelState.AddModelError(nameof(model.Name), DepartmentExistsErrorMessage);

            return View(model);
        }

        return RedirectToAction("All","Employees");
    }
}
using HumanCapitalManagement.Business.BusinessServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static HumanCapitalManagement.Common.GlobalConstants.Administrator;

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
    
    
}
using HumanCapitalManagement.Web.Models.Departments;
using HumanCapitalManagement.Web.Models.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanCapitalManagement.Web.Controllers;

[Authorize]
public class EmployeesController : Controller
{
    public IActionResult Create()
        => View(new CreateEmployeeFormModel
        {
            Departments = Enumerable.Empty<DepartmentsListingModel>()
        });
}
using HumanCapitalManagement.Web.Models.Departments;
using HumanCapitalManagement.Business.BusinessServices;
using HumanCapitalManagement.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace HumanCapitalManagement.Web.Controllers.API;


public class DepartmentsController(IDepartmentBusinessService departmentsBusinessService)
    : BaseApiController
{
    [HttpGet]
    [Authorize]
    [ProducesResponseType(typeof(IEnumerable<DepartmentsListingModel>), Status200OK)]
    public async Task<IActionResult> GetDepartments()
        => await departmentsBusinessService
            .GetAllDepartments<DepartmentsListingModel>()
            .ToOkResult();


}
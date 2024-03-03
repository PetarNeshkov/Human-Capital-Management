using HumanCapitalManagement.Business.BusinessServices.Interfaces;
using HumanCapitalManagement.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

using static Microsoft.AspNetCore.Http.StatusCodes;

namespace HumanCapitalManagement.Web.Areas.Admin.Controllers.API;

public class EmployeesController(IEmployeeBusinessService employeeBusinessService)
    : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(int), Status200OK)]
    public async Task<IActionResult> GetCurrentCount()
        => await employeeBusinessService.GetNonDeletedCount()
            .ToOkResult();
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => await employeeBusinessService.DeleteEmployee(id)
            .ToOkResult();

}
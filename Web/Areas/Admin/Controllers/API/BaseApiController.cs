using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static HumanCapitalManagement.Common.GlobalConstants.Administrator;

namespace HumanCapitalManagement.Web.Areas.Admin.Controllers.API;

[ApiController]
[Route("api/admin/[controller]/[action]")]
[Area(AdministratorUsername)]
[Authorize(Roles =AdministratorRoleName)]
[Produces("application/json")]
public class BaseApiController : ControllerBase;
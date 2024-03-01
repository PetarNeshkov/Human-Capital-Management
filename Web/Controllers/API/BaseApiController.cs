using Microsoft.AspNetCore.Mvc;

namespace HumanCapitalManagement.Web.Controllers.API;

[ApiController]
[Route("api/[controller]/[action]")]
[Produces("application/json")]
public class BaseApiController : ControllerBase;
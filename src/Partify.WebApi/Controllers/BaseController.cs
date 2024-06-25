using Microsoft.AspNetCore.Mvc;

namespace Partify.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
	public long GetUserId => Convert.ToInt64(HttpContext.User.FindFirst("Id")?.Value);
}
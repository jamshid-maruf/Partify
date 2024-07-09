﻿using Microsoft.AspNetCore.Mvc;

namespace Partify.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
//[CustomAuthorize]
public class BaseController : ControllerBase
{
    public long GetUserId => Convert.ToInt64(HttpContext.User.FindFirst("Id")?.Value);
}
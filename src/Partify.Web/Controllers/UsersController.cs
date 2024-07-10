using Microsoft.AspNetCore.Mvc;
using Partify.Web.WebServices.Users;

namespace Partify.Web.Controllers;

public class UsersController(IUserWebService userWebService) : Controller
{
	public async ValueTask<IActionResult> Index()
	{
		var users = await userWebService.GetAllAsync();
		return View(users);
	}
}

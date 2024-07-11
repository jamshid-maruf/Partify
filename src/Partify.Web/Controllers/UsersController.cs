using Microsoft.AspNetCore.Mvc;
using Partify.Web.Models.UserRoles;
using Partify.Web.Models.Users;
using Partify.Web.WebServices.Users;

namespace Partify.Web.Controllers;

public class UsersController(IUserWebService userWebService) : Controller
{
	public async ValueTask<IActionResult> Index()
	{
		var users = await userWebService.GetAllAsync();
		return View(users);
	}

    [HttpGet]
	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
    public async ValueTask<IActionResult> Create(UserCreateModel createModel)
    {
        var result = await userWebService.CreateAsync(createModel);
        if (result is not null)
            return RedirectToAction("Index");

        return View();
    }

    public IActionResult Edit()
    {
        return View();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Edit(UserUpdateModel createModel)
    {
        return View();
    }
}

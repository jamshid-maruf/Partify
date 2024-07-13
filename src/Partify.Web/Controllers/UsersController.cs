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

    public async ValueTask<IActionResult> Edit(long id)
    {
        var result = await userWebService.GetAsync(id);
        return View(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> Edit(long id, UserUpdateModel createModel)
    {
        var result = await userWebService.ModifyAsync(id, createModel);
        if (result is not null)
            return RedirectToAction("Index");

        return View();
    }

    public async ValueTask<IActionResult> Delete(long id)
    {
        var result = await userWebService.DeleteAsync(id);
        if(result)
            return RedirectToAction("Index");

        return View();
    }
}

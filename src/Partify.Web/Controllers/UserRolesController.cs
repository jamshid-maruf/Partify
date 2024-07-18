using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Partify.Web.Models.UserRoles;
using Partify.Web.WebServices.UserRoles;

namespace Partify.Web.Controllers;

[Authorize]
public class UserRolesController(IUserRoleWebService userRoleWebService) : Controller
{
    public async ValueTask<IActionResult> Index()
    {
        var userRoles = await userRoleWebService.GetAllAsync();
        return View(userRoles);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create(UserRoleCreateModel createModel)
    {
        var result = await userRoleWebService.CreateAsync(createModel);
        if (result is not null)
            return RedirectToAction("Index");

        return View();
    }

    public async ValueTask<IActionResult> Edit(long id)
    {
        var result = await userRoleWebService.GetByIdAsync(id);
        return View(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> Edit(long id, UserRoleUpdateModel updateModel)
    {
        var result = await userRoleWebService.UpdateAsync(id, updateModel);
        if (result is not null)
            return RedirectToAction("Index");

        return View();
    }

    public async ValueTask<IActionResult> Delete(long id)
    {
        var result = await userRoleWebService.DeleteAsync(id);
        if (result)
            return RedirectToAction("Index");

        return View();
    }
}

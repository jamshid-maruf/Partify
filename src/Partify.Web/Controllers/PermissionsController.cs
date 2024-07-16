using Microsoft.AspNetCore.Mvc;
using Partify.Web.Models.Permissions;
using Partify.Web.WebServices.Permissions;
using Partify.Web.WebServices.Users;
using Partify.WebApi.Models.Ads;

namespace Partify.Web.Controllers;

public class PermissionsController(IPermissionWebService permissionWebService) : Controller
{
    public async Task<IActionResult> Index(int? page, string search = null)
    {
        var permissions = await permissionWebService.GetAllAsync(page, search);
        return View(new PermissionPagedListModel { Permissions = permissions });
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(PermissionCreateModel model)
    {     
        var result = await permissionWebService.CreateAsync(model);
        if (result is not null)
            return RedirectToAction("Index");

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(long id)
    {
        var model = await permissionWebService.GetByIdAsync(id);
        if (model == null)
        {
            return NotFound();
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(long id, PermissionUpdateModel model)
    {
        if (ModelState.IsValid)
        {
            await permissionWebService.UpdateAsync(id, model);
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    public async Task<IActionResult> Delete(long id)
    {
        await permissionWebService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}

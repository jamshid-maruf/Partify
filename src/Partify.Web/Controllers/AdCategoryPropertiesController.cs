using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Partify.Web.Models.AdCategories;
using Partify.Web.WebServices.AdCategoryProperties;

namespace Partify.Web.Controllers;

[Authorize]
public class AdCategoryPropertiesController(IAdCategoryPropertyWebService adCategoryPropertyWebService) : Controller
{
    public async ValueTask<IActionResult> Index()
    {
        var adCategoryProperties = await adCategoryPropertyWebService.GetAllAsync();
        return View(adCategoryProperties);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create(AdCategoryPropertyCreateModel createModel)
    {
        var result = await adCategoryPropertyWebService.CreateAsync(createModel);
        if (result is not null)
            return RedirectToAction("Index");

        return View();
    }

    public async ValueTask<IActionResult> Edit(long id)
    {
        var result = await adCategoryPropertyWebService.GetByIdAsync(id);
        return View(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> Edit(long id, AdCategoryPropertyUpdateModel updateModel)
    {
        var result = await adCategoryPropertyWebService.UpdateAsync(id, updateModel);
        if (result is not null)
            return RedirectToAction("Index");

        return View();
    }

    public async ValueTask<IActionResult> Delete(long id)
    {
        var result = await adCategoryPropertyWebService.DeleteAsync(id);
        if (result)
            return RedirectToAction("Index");

        return View();
    }
}

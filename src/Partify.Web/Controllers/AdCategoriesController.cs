using Microsoft.AspNetCore.Mvc;
using Partify.Web.Models.AdCategories;
using Partify.Web.WebServices.AdCategories;

namespace Partify.Web.Controllers;

public class AdCategoriesController(IAdCategoryWebService adCategoryWebService) : Controller
{
    public async ValueTask<IActionResult> Index()
    {
        var adCategories = await adCategoryWebService.GetAllAsync();
        return View(adCategories);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create(AdCategoryCreateModel createModel)
    {
        var result = await adCategoryWebService.CreateAsync(createModel);
        if (result is not null)
            return RedirectToAction("Index");

        return View();
    }

    public async ValueTask<IActionResult> Edit(long id)
    {
        var result = await adCategoryWebService.GetByIdAsync(id);
        return View(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> Edit(long id, AdCategoryUpdateModel updateModel)
    {
        var result = await adCategoryWebService.UpdateAsync(id, updateModel);
        if (result is not null)
            return RedirectToAction("Index");

        return View();
    }

    public async ValueTask<IActionResult> Delete(long id)
    {
        var result = await adCategoryWebService.DeleteAsync(id);
        if (result)
            return RedirectToAction("Index");

        return View();
    }
}

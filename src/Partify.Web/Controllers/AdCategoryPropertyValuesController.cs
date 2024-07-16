using Microsoft.AspNetCore.Mvc;
using Partify.Web.Models.AdCategoryPropertyValues;
using Partify.Web.WebServices.AdCategoryPropertyValues;

namespace Partify.Web.Controllers;

public class AdCategoryPropertyValuesController(IAdCategoryPropertyValueWebService adCategoryPropertyValueWebService) : Controller
{
    public async ValueTask<IActionResult> Index()
    {
        var adCategoryPropertyValues = await adCategoryPropertyValueWebService.GetAllAsync();
        return View(adCategoryPropertyValues);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create(AdCategoryPropertyValueCreateModel createModel)
    {
        var result = await adCategoryPropertyValueWebService.CreateAsync(createModel);
        if (result is not null)
            return RedirectToAction("Index");

        return View();
    }

    public async ValueTask<IActionResult> Edit(long id)
    {
        var result = await adCategoryPropertyValueWebService.GetByIdAsync(id);
        return View(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> Edit(long id, AdCategoryPropertyValueUpdateModel updateModel)
    {
        var result = await adCategoryPropertyValueWebService.UpdateAsync(id, updateModel);
        if (result is not null)
            return RedirectToAction("Index");

        return View();
    }

    public async ValueTask<IActionResult> Delete(long id)
    {
        var result = await adCategoryPropertyValueWebService.DeleteAsync(id);
        if (result)
            return RedirectToAction("Index");

        return View();
    }
}

using Microsoft.AspNetCore.Mvc;
using Partify.Web.Models.Facilities;
using Partify.Web.WebServices.Facilities;

namespace Partify.Web.Controllers;

public class FacilitiesController(IFacilityWebService facilityWebService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var facilities = await facilityWebService.GetAllAsync();
        return View(facilities);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(FacilityCreateModel createModel)
    {
        var result = await facilityWebService.CreateAsync(createModel);
        if (result is not null)
            return RedirectToAction("Index");

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(long id)
    {
        var facility = await facilityWebService.GetByIdAsync(id);
        if (facility == null)
        {
            return NotFound();
        }
        return View(facility);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(long id, FacilityUpdateModel updateModel)
    {
        if (ModelState.IsValid)
        {
            await facilityWebService.UpdateAsync(id, updateModel);
            return RedirectToAction(nameof(Index));
        }
        return View(updateModel);
    }

    public async Task<IActionResult> Delete(long id)
    {
        await facilityWebService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}

using Microsoft.AspNetCore.Mvc;
using Partify.Service.Configurations;
using Partify.WebApi.ApiServices.AdFacilities;
using Partify.WebApi.Controllers;
using Partify.WebApi.Models.AdFacilities;
using Partify.WebApi.Models.Commons;

public class AdFacilitiesController(IAdFacilityApiService adFacilityApiService) : BaseController
{
    [HttpPost("create")]
    public async ValueTask<IActionResult> PostAsync(AdFacilityCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await adFacilityApiService.CreateAsync(createModel)
        });
    }
    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, AdFacilityUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await adFacilityApiService.UpdateAsync(id, updateModel)
        });
    }
    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await adFacilityApiService.DeleteAsync(id)
        });
    }
    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await adFacilityApiService.GetByIdAsync(id)
        });
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAsync(
        [FromQuery] PaginationParams @params,
    [FromQuery] Filter filter,
        [FromQuery] string search = null)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await adFacilityApiService.GetAllAsync(@params, filter, search)
        });
    }
}
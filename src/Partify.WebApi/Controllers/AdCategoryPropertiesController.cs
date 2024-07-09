using Microsoft.AspNetCore.Mvc;
using Partify.Service.Configurations;
using Partify.WebApi.ApiServices.AdCategoryProperties;
using Partify.WebApi.Models.AdCategoryProperties;
using Partify.WebApi.Models.Commons;

namespace Partify.WebApi.Controllers;

public class AdCategoryPropertiesController(IAdCategoryPropertyApiService adCategoryPropertyApiService) : BaseController
{
    [HttpPost("create")]
    public async ValueTask<IActionResult> PostAsync(AdCategoryPropertyCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await adCategoryPropertyApiService.CreateAsync(createModel)
        });
    }
    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, AdCategoryPropertyUpdateModel updateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await adCategoryPropertyApiService.UpdateAsync(id, updateModel)
        });
    }
    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await adCategoryPropertyApiService.DeleteAsync(id)
        });
    }
    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await adCategoryPropertyApiService.GetByIdAsync(id)
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
            Data = await adCategoryPropertyApiService.GetAllAsync(@params, filter, search)
        });
    }
}
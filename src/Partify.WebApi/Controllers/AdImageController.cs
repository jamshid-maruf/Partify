using Microsoft.AspNetCore.Mvc;
using Partify.Service.Configurations;
using Partify.WebApi.ApiServices.AdImages;
using Partify.WebApi.Models.AdImages;
using Partify.WebApi.Models.Commons;

namespace Partify.WebApi.Controllers;

public class AdImageController(IAdImageApiService adImageApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(AdImageCreateModel createModel, IFormFile formFile)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await adImageApiService.CreateAsync(createModel.AdId, formFile)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await adImageApiService.DeleteAsync(id)
        });
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await adImageApiService.GetByIdAsync(id)
        });
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetListAsync(long adId, Filter filter)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await adImageApiService.GetAllAsync(adId, filter)
        });
    }
}

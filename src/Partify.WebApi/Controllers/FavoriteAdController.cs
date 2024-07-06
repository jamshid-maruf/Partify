using Microsoft.AspNetCore.Mvc;
using Partify.Service.Configurations;
using Partify.WebApi.ApiServices.FavoriteAds;
using Partify.WebApi.Models.Commons;
using Partify.WebApi.Models.FavoriteAds;

namespace Partify.WebApi.Controllers;

public class FavoriteAdsController(IFavoriteAdApiService favoriteAdApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(FavoriteAdCreateModel favoriteAdCreateModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await favoriteAdApiService.CreateAsync(favoriteAdCreateModel)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await favoriteAdApiService.DeleteAsync(id)
        }); ;
    }

    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await favoriteAdApiService.GetByIdAsync(id)
        }); ;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetListAsync([FromQuery] PaginationParams @params)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await favoriteAdApiService.GetAllAsync(@params)
        }); ;
    }
}

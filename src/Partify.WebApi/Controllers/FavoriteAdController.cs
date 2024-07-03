using Microsoft.AspNetCore.Mvc;
using Partify.Service.Configurations;
using Partify.WebApi.ApiServices.FavoriteAds;
using Partify.WebApi.Models.Commons;
using Partify.WebApi.Models.FavoriteAds;

namespace Partify.WebApi.Controllers;

public class FavoriteAdController(IFavoriteAdApiService favoriteAdApiService) : BaseController
{
    [HttpPost("Create")]
    public async ValueTask<IActionResult> CreateAsync(FavoriteAdCreateModel favoriteAdCreateModel)
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
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await favoriteAdApiService.GetByIdAsync(id)
        }); ;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync(PaginationParams @params)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await favoriteAdApiService.GetAllAsync(@params)
        }); ;
    }
}

using Microsoft.AspNetCore.Mvc;
using Partify.WebApi.ApiServices.AdScores;
using Partify.WebApi.Models.AdScores;
using Partify.WebApi.Models.Commons;

namespace Partify.WebApi.Controllers;

public class AdScoreController(IAdScoreApiService adScoreApiService) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> UpsertScoreAsync(AdScoreCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await adScoreApiService.AddOrUpdateScoreAsync(createModel)
        });
    }

    [HttpGet("{adId:long}")]
    public async ValueTask<IActionResult> GetAverageScoreAsync(long adId)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await adScoreApiService.GetAverageScoreAsync(adId)
        });
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response 
        {
            StatusCode = 200,
            Message = "Success",
            Data = await adScoreApiService.DeleteAsync(id)
        });

    }

}
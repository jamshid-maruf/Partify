
using Microsoft.AspNetCore.Mvc;
using Partify.WebApi.ApiServices.AdScores;
using Partify.WebApi.Models.AdScores;
using Partify.WebApi.Models.Commons;

namespace Partify.WebApi.Controllers;

public class AdScoreController(IAdScoreApiService adScoreApiService) : BaseController
{
    [HttpPost("ad-or-update")]
    public async ValueTask<IActionResult> AddOrUpdateScoreAsync(AdScoreCreateModel createModel)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await adScoreApiService.AddOrUpdateScoreAsync(createModel)
        });
    }

    [HttpGet("get-average-score")]
    public async ValueTask<IActionResult> GetAverageScoreAsync([FromQuery] long adId)
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
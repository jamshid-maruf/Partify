using Microsoft.AspNetCore.Mvc;
using Partify.WebApi.ApiServices.Assests;
using Partify.WebApi.Models.Commons;

namespace Partify.WebApi.Controllers
{
	public class AssetsController(IAssetApiService assetApiService) : BaseController
	{
		[HttpDelete("{id:long}")]
		public async ValueTask<IActionResult> DeleteAsync(long id)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await assetApiService.DeleteAsync(id)
			});
		}
		[HttpGet("{id:long}")]
		public async ValueTask<IActionResult> GetAsync(long id)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await assetApiService.GetByIdAsync(id)
			});
		}
		[HttpPost("create")]
		public async ValueTask<IActionResult> CreateAsync(IFormFile file, string fileType)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await assetApiService.UploadAsync(file, fileType)
			});
		}
	}
}

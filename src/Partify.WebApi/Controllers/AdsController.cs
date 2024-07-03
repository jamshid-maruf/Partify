using Microsoft.AspNetCore.Mvc;
using Partify.Service.Configurations;
using Partify.WebApi.ApiServices.Ads;
using Partify.WebApi.Models.Ads;
using Partify.WebApi.Models.Commons;

namespace Partify.WebApi.Controllers
{
	public class AdsController(IAdApiService adApiService) : BaseController
	{
		[HttpPost("create")]
		public async ValueTask<IActionResult> CreateAsync(AdCreateModel createModel)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await adApiService.CreateAsync(createModel)
			});
		}
		[HttpPut("{id:long}")]
		public async ValueTask<IActionResult> PutAsync(long id, AdUpdateModel updateModel)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await adApiService.UpdateAsync(id, updateModel)
			});
		}
		[HttpDelete("{id:long}")]
		public async ValueTask<IActionResult> DeleteAsync(long id)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await adApiService.DeleteAsync(id)
			});
		}
		[HttpGet("{id:long}")]
		public async ValueTask<IActionResult> GetAsync(long id)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await adApiService.GetByIdAsync(id)
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
				Data = await adApiService.GetAllAsync(@params, filter, search)
			});
		}
	}
}

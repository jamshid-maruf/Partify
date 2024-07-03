using Microsoft.AspNetCore.Mvc;
using Partify.Service.Configurations;
using Partify.WebApi.ApiServices.AdComments;
using Partify.WebApi.Models.AddComments;
using Partify.WebApi.Models.Commons;

namespace Partify.WebApi.Controllers
{
	public class AdCommentsController(IAdCommentApiService adCommentApiService) : BaseController
	{

		[HttpPost("create")]
		public async ValueTask<IActionResult> CreateAsync(AdCommentCreateModel createModel)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await adCommentApiService.CreateAsync(createModel)
			});
		}
		[HttpPut("{id:long}")]
		public async ValueTask<IActionResult> PutAsync(long id, AdCommentUpdateModel updateModel)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await adCommentApiService.UpdateAsync(id, updateModel)
			});
		}
		[HttpDelete("{id:long}")]
		public async ValueTask<IActionResult> DeleteAsync(long id)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await adCommentApiService.DeleteAsync(id)
			});
		}
		[HttpGet("{id:long}")]
		public async ValueTask<IActionResult> GetAsync(long id)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await adCommentApiService.GetByIdAsync(id)
			});
		}

		[HttpGet]
		public async ValueTask<IActionResult> GetAsync(
			[FromQuery] PaginationParams @params,
			[FromQuery] Filter filter)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await adCommentApiService.GetAllAsync(@params, filter)
			});
		}
	}
}

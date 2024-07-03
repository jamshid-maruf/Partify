using Microsoft.AspNetCore.Mvc;
using Partify.Service.Configurations;
using Partify.WebApi.ApiServices.Facilities;
using Partify.WebApi.Models.Commons;
using Partify.WebApi.Models.Facilities;

namespace Partify.WebApi.Controllers
{
	public class FacilitiesController(IFacilityApiService facilityApiService) : BaseController
	{
		[HttpPost("create")]
		public async ValueTask<IActionResult> CreateAsync(FacilityCreateModel createModel)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await facilityApiService.CreateAsync(createModel)
			});
		}
		[HttpPut("{id:long}")]
		public async ValueTask<IActionResult> PutAsync(long id, FacilityUpdateModel updateModel)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await facilityApiService.UpdateAsync(id, updateModel)
			});
		}
		[HttpDelete("{id:long}")]
		public async ValueTask<IActionResult> DeleteAsync(long id)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await facilityApiService.DeleteAsync(id)
			});
		}
		[HttpGet("{id:long}")]
		public async ValueTask<IActionResult> GetAsync(long id)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await facilityApiService.GetByIdAsync(id)
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
				Data = await facilityApiService.GetAllAsync(@params, filter, search)
			});
		}
	}
}

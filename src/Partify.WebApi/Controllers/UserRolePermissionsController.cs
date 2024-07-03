using Microsoft.AspNetCore.Mvc;
using Partify.Service.Configurations;
using Partify.WebApi.ApiServices.UserRolePermissions;
using Partify.WebApi.Models.Commons;
using Partify.WebApi.Models.UserRolePermissions;

namespace Partify.WebApi.Controllers
{
	public class UserRolePermissionsController(IUserRolePermissionApiService userRolePermissionApiService) : BaseController
	{
		[HttpPost("create")]
		public async ValueTask<IActionResult> CreateAsync(UserRolePermissionCreateModel createModel)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await userRolePermissionApiService.CreateAsync(createModel)
			});
		}
		[HttpPut("{id:long}")]
		public async ValueTask<IActionResult> PutAsync(long id, UserRolePermissionUpdateModel updateModel)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await userRolePermissionApiService.UpdateAsync(id, updateModel)
			});
		}
		[HttpDelete("{id:long}")]
		public async ValueTask<IActionResult> DeleteAsync(long id)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await userRolePermissionApiService.DeleteAsync(id)
			});
		}
		[HttpGet("{id:long}")]
		public async ValueTask<IActionResult> GetAsync(long id)
		{
			return Ok(new Response
			{
				StatusCode = 200,
				Message = "Success",
				Data = await userRolePermissionApiService.GetByIdAsync(id)
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
				Data = await userRolePermissionApiService.GetAllAsync(@params, filter, search)
			});
		}
	}
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Partify.Service.Configurations;
using Partify.WebApi.ApiServices.Users;
using Partify.WebApi.Models.Commons;
using Partify.WebApi.Models.Users;

namespace Partify.WebApi.Controllers;

public class UsersController(IUserApiService userApiService) : BaseController
{
	[HttpPut("{id:long}")]
	public async ValueTask<IActionResult> PutAsync(UserUpdateModel updateModel)
	{
		return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
			Data = await userApiService.ModifyAsync(GetUserId, updateModel)
		});
	}

	[HttpDelete("{id:long}")]
	public async ValueTask<IActionResult> DeleteAsync()
	{
		return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
			Data = await userApiService.DeleteAsync(GetUserId)
		});
	}

	[HttpGet("{id:long}")]
	public async ValueTask<IActionResult> GetAsync()
	{
		return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
			Data = await userApiService.GetAsync(GetUserId)
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
			Data = await userApiService.GetAllAsync(@params, filter, search)
		});
	}

	[HttpPatch("change-password")]
	public async ValueTask<IActionResult> PatchAsync(string oldPassword, string newPassword, string confirmPassword)
	{
		return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
			Data = await userApiService.ChangePasswordAsync(oldPassword, newPassword, confirmPassword)
		});
	}
}

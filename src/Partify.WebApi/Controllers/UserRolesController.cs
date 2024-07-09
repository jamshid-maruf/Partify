﻿using Microsoft.AspNetCore.Mvc;
using Partify.Service.Configurations;
using Partify.WebApi.ApiServices.UserRoles;
using Partify.WebApi.Models.Commons;
using Partify.WebApi.Models.UserRoles;

namespace Partify.WebApi.Controllers;

public class UserRolesController(IUserRoleApiService userRoleApiService) : BaseController
{
	[HttpPost("create")]
	public async ValueTask<IActionResult> CreateAsync(UserRoleCreateModel createModel)
	{
		return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
			Data = await userRoleApiService.CreateAsync(createModel)
		});
	}
	[HttpPut("{id:long}")]
	public async ValueTask<IActionResult> PutAsync(long id, UserRoleUpdateModel updateModel)
	{
		return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
			Data = await userRoleApiService.UpdateAsync(id, updateModel)
		});
	}
	[HttpDelete("{id:long}")]
	public async ValueTask<IActionResult> DeleteAsync(long id)
	{
		return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
			Data = await userRoleApiService.DeleteAsync(id)
		});
	}
	[HttpGet("{id:long}")]
	public async ValueTask<IActionResult> GetAsync(long id)
	{
		return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
			Data = await userRoleApiService.GetByIdAsync(id)
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
			Data = await userRoleApiService.GetAllAsync(@params, filter, search)
		});
	}
}

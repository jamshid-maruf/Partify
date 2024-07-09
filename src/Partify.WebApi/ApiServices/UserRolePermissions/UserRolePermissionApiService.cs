﻿using AutoMapper;
using Partify.Domain.Entities.Users;
using Partify.Service.Configurations;
using Partify.Service.Services.UserRolePermissions;
using Partify.WebApi.Models.UserRolePermissions;

namespace Partify.WebApi.ApiServices.UserRolePermissions;

public class UserRolePermissionApiService(IUserRolePermissionService userRolePermissionService, IMapper mapper) : IUserRolePermissionApiService
{
	public async ValueTask<UserRolePermissionViewModel> CreateAsync(UserRolePermissionCreateModel createModel)
	{
		var createdUserRolePermission = await userRolePermissionService.CreateAsync(mapper.Map<UserRolePermission>(createModel));
		return mapper.Map<UserRolePermissionViewModel>(createdUserRolePermission);
	}

	public async ValueTask<UserRolePermissionViewModel> UpdateAsync(long id, UserRolePermissionUpdateModel updateModel)
	{
		var updatedUserRolePermission = await userRolePermissionService.UpdateAsync(id, mapper.Map<UserRolePermission>(updateModel));
		return mapper.Map<UserRolePermissionViewModel>(updatedUserRolePermission);
	}

	public async ValueTask<bool> DeleteAsync(long id)
	{
		return await userRolePermissionService.DeleteAsync(id);
	}

	public async ValueTask<UserRolePermissionViewModel> GetByIdAsync(long id)
	{
		var result = await userRolePermissionService.GetByIdAsync(id);
		return mapper.Map<UserRolePermissionViewModel>(result);
	}

	public async ValueTask<IEnumerable<UserRolePermissionViewModel>> GetAllAsync(
		PaginationParams @params,
		Filter filter,
		string search = null)
	{
		var result = await userRolePermissionService.GetAllAsync(@params, filter, search);
		return mapper.Map<IEnumerable<UserRolePermissionViewModel>>(result);
	}

	public async ValueTask<IEnumerable<UserRolePermissionViewModel>> GetAllByRoleIdAsync(long roleId)
	{
		var result = await userRolePermissionService.GetAllByRoleIdAsync(roleId);
		return mapper.Map<IEnumerable<UserRolePermissionViewModel>>(result);
	}
}
using Partify.Service.Configurations;
using Partify.WebApi.Models.UserRolePermissions;

namespace Partify.WebApi.ApiServices.UserRolePermissions;

public class UserRolePermissionApiService : IUserRolePermissionApiService
{
	public ValueTask<UserRolePermissionViewModel> CreateAsync(UserRolePermissionCreateModel createModel)
	{
		throw new NotImplementedException();
	}
	
	public ValueTask<UserRolePermissionViewModel> UpdateAsync(long id, UserRolePermissionUpdateModel updateModel)
	{
		throw new NotImplementedException();
	}

	public ValueTask<bool> DeleteAsync(long id)
	{
		throw new NotImplementedException();
	}
	
	public ValueTask<UserRolePermissionViewModel> GetByIdAsync(long id)
	{
		throw new NotImplementedException();
	}
	
	public ValueTask<IEnumerable<UserRolePermissionViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
	{
		throw new NotImplementedException();
	}

	public ValueTask<IEnumerable<UserRolePermissionViewModel>> GetAlByRoleIdAsync(long roleId)
	{
		throw new NotImplementedException();
	}
}

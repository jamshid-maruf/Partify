using Partify.Domain.Entities.Users;
using Partify.Service.Configurations;

namespace Partify.Service.Services.UserRolePermissions;

public class UserRolePermissionService : IUserRolePermissionService
{
	public ValueTask<UserRolePermission> CreateAsync(UserRolePermission userRolePermission)
	{
		throw new NotImplementedException();
	}

	public ValueTask<bool> DeleteAsync(long id)
	{
		throw new NotImplementedException();
	}

	public ValueTask<UserRolePermission> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
	{
		throw new NotImplementedException();
	}

	public ValueTask<UserRolePermission> GetByIdAsync(long id)
	{
		throw new NotImplementedException();
	}

	public ValueTask<UserRolePermission> UpdateAsync(long id, UserRolePermission userRolePermission)
	{
		throw new NotImplementedException();
	}
}
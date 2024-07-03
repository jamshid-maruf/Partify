using Partify.Domain.Entities.Users;
using Partify.Service.Configurations;

namespace Partify.Service.Services.UserRolePermissions;

public interface IUserRolePermissionService
{
	ValueTask<UserRolePermission> CreateAsync(UserRolePermission userRolePermission);
	ValueTask<UserRolePermission> UpdateAsync(long id, UserRolePermission userRolePermission);
	ValueTask<bool> DeleteAsync(long id);
	ValueTask<UserRolePermission> GetByIdAsync(long id);
	ValueTask<IEnumerable<UserRolePermission>> GetAlByRoleIdAsync(long roleId);
	ValueTask<IEnumerable<UserRolePermission>> GetAllAsync(
		PaginationParams @params,
		Filter filter,
		string search = null);
}
using Partify.WebApi.Models.Permissions;
using Partify.WebApi.Models.UserRoles;

namespace Partify.WebApi.Models.UserRolePermissions;

public class UserRolePermissionViewModel
{
	public long Id { get; set; }
	public UserRoleViewModel UserRole { get; set; }
	public PermissionViewModel Permission { get; set; }
}

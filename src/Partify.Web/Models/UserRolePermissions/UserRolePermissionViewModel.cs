
using Partify.Web.Models.Permissions;
using Partify.Web.Models.UserRoles;

namespace Partify.Web.Models.UserRolePermissions;

public class UserRolePermissionViewModel
{
	public long Id { get; set; }
	public UserRoleViewModel UserRole { get; set; }
	public PermissionViewModel Permission { get; set; }
}

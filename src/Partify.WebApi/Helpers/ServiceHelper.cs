using Partify.Service.Services.UserRolePermissions;
using Partify.Service.Services.UserRoles;

namespace Partify.WebApi.Helpers;

public static class ServiceHelper
{
	public static IUserRoleService UserRoleService { get; set; }
	public static IUserRolePermissionService UserRolePermissionService { get; set; }
}

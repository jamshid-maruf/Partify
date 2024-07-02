using Partify.Service.Services.UserRolePermissions;
using Partify.Service.Services.UserRoles;

namespace Partify.WebApi.Helpers;

public static class ServiceHelper
{
	public static IUserRoleService UserRoleService { get; set; }
	public static IUserRolePermissionService UserRolePermissionService { get; set; }

	public static void InitializeServices(IServiceProvider serviceProvider)
	{
		using (var scope = serviceProvider.CreateScope())
		{
			var scopedProvider = scope.ServiceProvider;
			UserRolePermissionService = scopedProvider.GetRequiredService<IUserRolePermissionService>();
			UserRoleService = scopedProvider.GetRequiredService<IUserRoleService>();
		}
	}
}

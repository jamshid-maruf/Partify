using Partify.Service.Configurations;
using Partify.Web.Models.UserRolePermissions;

namespace Partify.Web.WebServices.UserRolePermissions;

public interface IUserRolePermission
{
    ValueTask<UserRolePermissionViewModel> CreateAsync(UserRolePermissionCreateModel createModel);
    ValueTask<UserRolePermissionViewModel> UpdateAsync(long id, UserRolePermissionUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<UserRolePermissionViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<UserRolePermissionViewModel>> GetAlByRoleIdAsync(long roleId);
    ValueTask<IEnumerable<UserRolePermissionViewModel>> GetAllAsync();
}

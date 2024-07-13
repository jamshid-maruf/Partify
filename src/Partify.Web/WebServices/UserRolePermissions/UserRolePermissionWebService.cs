using AutoMapper;
using Partify.Domain.Entities.Users;
using Partify.Service.Services.UserRolePermissions;
using Partify.Web.Models.UserRolePermissions;


namespace Partify.Web.WebServices.UserRolePermissions;

public class UserRolePermissionWebService(IUserRolePermissionService userRolePermissionService, IMapper mapper) : IUserRolePermissionWebService
{
    public async ValueTask<UserRolePermissionViewModel> CreateAsync(UserRolePermissionCreateModel createModel)
    {
        var mappedUserRolePermission = mapper.Map<UserRolePermission>(createModel);
        var createdUserRolePermission = await userRolePermissionService.CreateAsync(mappedUserRolePermission);
        return mapper.Map<UserRolePermissionViewModel>(createdUserRolePermission);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await userRolePermissionService.DeleteAsync(id);
    }

    public async ValueTask<IEnumerable<UserRolePermissionViewModel>> GetAlByRoleIdAsync(long roleId)
    {
        var userRolePermissions = await userRolePermissionService.GetAlByRoleIdAsync(roleId);
        return mapper.Map<IEnumerable<UserRolePermissionViewModel>>(userRolePermissions);
    }

    public async ValueTask<IEnumerable<UserRolePermissionViewModel>> GetAllAsync()
    {
        var userRolePermissions = await userRolePermissionService.GetAllAsync();
        return mapper.Map<IEnumerable<UserRolePermissionViewModel>>(userRolePermissions);
    }

    public async ValueTask<UserRolePermissionViewModel> GetByIdAsync(long id)
    {
        return mapper.Map<UserRolePermissionViewModel>(await userRolePermissionService.GetByIdAsync(id));
    }

    public async ValueTask<UserRolePermissionViewModel> UpdateAsync(long id, UserRolePermissionUpdateModel updateModel)
    {
        var mappedUserRolePermission = mapper.Map<UserRolePermission>(updateModel);
        var updatedUserRolePersmission = await userRolePermissionService.UpdateAsync(id, mappedUserRolePermission);
        return mapper.Map<UserRolePermissionViewModel>(updatedUserRolePersmission);
    }
}

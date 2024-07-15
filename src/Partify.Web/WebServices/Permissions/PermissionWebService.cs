using AutoMapper;
using Partify.Domain.Entities.Users;
using Partify.Service.Configurations;
using Partify.Service.Services.Permissions;
using Partify.Web.Models.Permissions;

namespace Partify.Web.WebServices.Permissions;

public class PermissionWebService(IPermissionService permissionService, IMapper mapper) : IPermissionWebService
{
    public async ValueTask<PermissionViewModel> CreateAsync(PermissionCreateModel createModel)
    {
        var mappedPermission = mapper.Map<Permission>(createModel);
        var createdPermission = await permissionService.CreateAsync(mappedPermission);
        return mapper.Map<PermissionViewModel>(createdPermission);
    }

    public async ValueTask<PermissionViewModel> UpdateAsync(long id, PermissionUpdateModel updateModel)
    {
        var mappedPermission = mapper.Map<Permission>(updateModel);
        var updatedPermission = await permissionService.UpdateAsync(id, mappedPermission);
        return mapper.Map<PermissionViewModel>(updatedPermission);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await permissionService.DeleteAsync(id);
    }

    public async ValueTask<PermissionViewModel> GetByIdAsync(long id)
    {
        return mapper.Map<PermissionViewModel>(await permissionService.GetByIdAsync(id));
    }

    public async ValueTask<IEnumerable<PermissionViewModel>> GetAllAsync(
      PaginationParams @params,
      Filter filter,
      string search = null)
    {
        var result = await permissionService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<PermissionViewModel>>(result);
    }

    public async ValueTask<IEnumerable<PermissionViewModel>> GetAllAsync()
    {
        var result = await permissionService.GetAllAsync();
        return mapper.Map<IEnumerable<PermissionViewModel>>(result);
    }
}

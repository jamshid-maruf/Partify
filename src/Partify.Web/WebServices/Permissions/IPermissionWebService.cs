using Partify.Service.Configurations;
using Partify.Web.Models.Permissions;

namespace Partify.Web.WebServices.Permissions;

public interface IPermissionWebService
{
    ValueTask<PermissionViewModel> CreateAsync(PermissionCreateModel createModel);
    ValueTask<PermissionViewModel> UpdateAsync(long id, PermissionUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<PermissionViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<PermissionViewModel>> GetAllAsync(
     PaginationParams @params,
     Filter filter,
     string search = null);
    ValueTask<IEnumerable<PermissionViewModel>> GetAllAsync();
}
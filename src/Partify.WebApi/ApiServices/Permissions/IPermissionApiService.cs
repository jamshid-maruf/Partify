using Partify.Domain.Entities.Users;
using Partify.Service.Configurations;
using Partify.WebApi.Models.Permissions;

namespace Partify.WebApi.ApiServices.Permissions;

public interface IPermissionApiService
{
	ValueTask<PermissionViewModel> CreateAsync(PermissionCreateModel createModel);
	ValueTask<PermissionViewModel> UpdateAsync(long id, PermissionUpdateModel updateModel);
	ValueTask<bool> DeleteAsync(long id);
	ValueTask<PermissionViewModel> GetByIdAsync(long id);
	ValueTask<IEnumerable<PermissionViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
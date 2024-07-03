using Partify.Service.Configurations;
using Partify.WebApi.Models.Permissions;

namespace Partify.WebApi.ApiServices.Permissions;

public class PermissionApiService : IPermissionApiService
{
	public ValueTask<PermissionViewModel> CreateAsync(PermissionCreateModel createModel)
	{
		throw new NotImplementedException();
	}

	public ValueTask<PermissionViewModel> UpdateAsync(long id, PermissionUpdateModel updateModel)
	{
		throw new NotImplementedException();
	}

	public ValueTask<bool> DeleteAsync(long id)
	{
		throw new NotImplementedException();
	}
	public ValueTask<PermissionViewModel> GetByIdAsync(long id)
	{
		throw new NotImplementedException();
	}

	public ValueTask<IEnumerable<PermissionViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
	{
		throw new NotImplementedException();
	}
}
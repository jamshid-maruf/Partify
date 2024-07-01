using Partify.Domain.Entities.Users;
using Partify.Service.Configurations;

namespace Partify.Service.Services.UserRoles;

public class UserRoleService() : IUserRoleService
{
	public ValueTask<UserRole> CreateAsync(UserRole userRole)
	{
		throw new NotImplementedException();
	}

	public ValueTask<bool> DeleteAsync(long id)
	{
		throw new NotImplementedException();
	}

	public ValueTask<IEnumerable<UserRole>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
	{
		throw new NotImplementedException();
	}

	public ValueTask<UserRole> GetByIdAsync(long id)
	{
		throw new NotImplementedException();
	}

	public ValueTask<UserRole> UpdateAsync(long id, UserRole userRole)
	{
		throw new NotImplementedException();
	}
}

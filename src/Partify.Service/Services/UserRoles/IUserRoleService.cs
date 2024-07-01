using Partify.Domain.Entities.Users;
using Partify.Service.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partify.Service.Services.UserRoles;

public interface IUserRoleService
{
	ValueTask<UserRole> CreateAsync(UserRole userRole);
	ValueTask<UserRole> UpdateAsync(long id, UserRole userRole);
	ValueTask<bool> DeleteAsync(long id);
	ValueTask<UserRole> GetByIdAsync(long id);
	ValueTask<IEnumerable<UserRole>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
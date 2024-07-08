using Partify.Domain.Entities.Users;
using Partify.Service.Configurations;

namespace Partify.Service.Services.Permissions;

public interface IPermissionService
{
    ValueTask<Permission> CreateAsync(Permission permission);
    ValueTask<Permission> UpdateAsync(long id, Permission permission);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Permission> GetByIdAsync(long id);
    ValueTask<IEnumerable<Permission>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
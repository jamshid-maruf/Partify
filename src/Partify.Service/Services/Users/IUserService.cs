using Partify.Domain.Entities.Users;
using Partify.Service.Configurations;

namespace Partify.Service.Services.Users;

public interface IUserService
{
	ValueTask<User> ModifyAsync(long id, User user);
	ValueTask<bool> DeleteAsync(long id);
	ValueTask<User> GetAsync(long id);
	ValueTask<IEnumerable<User>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
	ValueTask<User> ChangePasswordAsync(string oldPasword, string newPassword, string confirmPassword);
}
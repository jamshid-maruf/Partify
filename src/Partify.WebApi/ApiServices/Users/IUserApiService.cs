using Partify.Service.Configurations;
using Partify.WebApi.Models.Users;

namespace Partify.WebApi.ApiServices.Users;

public interface IUserApiService
{
	ValueTask<UserViewModel> ModifyAsync(long id, UserUpdateModel updateModel);
	ValueTask<bool> DeleteAsync(long id);
	ValueTask<UserViewModel> GetAsync(long id);
	ValueTask<IEnumerable<UserViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
	ValueTask<UserViewModel> ChangePasswordAsync(string oldPasword, string newPassword, string confirmPassword);
}
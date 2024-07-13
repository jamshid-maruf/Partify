using Partify.Web.Models.Users;

namespace Partify.Web.WebServices.Users;

public interface IUserWebService
{
    ValueTask<UserViewModel> CreateAsync(UserCreateModel createModel);
    ValueTask<UserViewModel> ModifyAsync(long id, UserUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<UserViewModel> GetAsync(long id);
    ValueTask<IEnumerable<UserViewModel>> GetAllAsync();
    ValueTask<UserViewModel> ChangePasswordAsync(string oldPasword, string newPassword, string confirmPassword);
    ValueTask<UserViewModel> ChangeRoleAsync(long userId, long roleId);
}
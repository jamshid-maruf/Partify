using AutoMapper;
using Partify.Domain.Entities.Users;
using Partify.Service.Services.Users;
using Partify.Web.Models.Users;

namespace Partify.Web.WebServices.Users;

public class UserWebService(IUserService userService, IMapper mapper) : IUserWebService
{
    public async ValueTask<UserViewModel> ModifyAsync(long id, UserUpdateModel updateModel)
    {
        var mappedUser = mapper.Map<User>(updateModel);
        var updatedUser = await userService.ModifyAsync(id, mappedUser);
        return mapper.Map<UserViewModel>(updatedUser);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await userService.DeleteAsync(id);
    }

    public async ValueTask<UserViewModel> GetAsync(long id)
    {
        return mapper.Map<UserViewModel>(await userService.GetAsync(id));
    }

    public async ValueTask<IEnumerable<UserViewModel>> GetAllAsync()
    {
        var result = await userService.GetAllAsync();
        return mapper.Map<IEnumerable<UserViewModel>>(result);
    }

    public async ValueTask<UserViewModel> ChangePasswordAsync(string oldPasword, string newPassword, string confirmPassword)
    {
        var result = await userService.ChangePasswordAsync(oldPasword, newPassword, confirmPassword);
        return mapper.Map<UserViewModel>(result);
    }

    public async ValueTask<UserViewModel> ChangeRoleAsync(long userId, long roleId)
    {
        var result = await userService.ChangeRoleAsync(userId, roleId);
        return mapper.Map<UserViewModel>(result);
    }
}
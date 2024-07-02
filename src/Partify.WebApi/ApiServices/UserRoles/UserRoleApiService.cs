using AutoMapper;
using Partify.Domain.Entities.Users;
using Partify.Service.Services.UserRoles;
using Partify.WebApi.Models.UserRoles;

namespace Partify.WebApi.ApiServices.UserRoles;

public class UserRoleApiService(IUserRoleService userRoleService, IMapper mapper) : IUserRoleApiService
{
    public async ValueTask<UserRoleViewModel> CreateAsync(UserRoleCreateModel createModel)
    {
        var createdUserRole = await userRoleService.CreateAsync(mapper.Map<UserRole>(createModel));
        return mapper.Map<UserRoleViewModel>(createdUserRole);
    }

    public async ValueTask<UserRoleViewModel> UpdateAsync(long id, UserRoleUpdateModel updateModel)
    {
        var updatedUserRole = await userRoleService.UpdateAsync(id, mapper.Map<UserRole>(updateModel));
        return mapper.Map<UserRoleViewModel>(updatedUserRole);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var deletedUserRole = await userRoleService.DeleteAsync(id);
        return true;
    }

    public ValueTask<IEnumerable<UserRoleViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserRoleViewModel> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}

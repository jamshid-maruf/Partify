using Partify.Service.Configurations;
using Partify.Web.Models.UserRoles;

namespace Partify.Web.WebServices.UserRoles
{
    public interface IUserRoleWebService
    {
        ValueTask<UserRoleViewModel> CreateAsync(UserRoleCreateModel createModel);
        ValueTask<UserRoleViewModel> UpdateAsync(long id, UserRoleUpdateModel updateModel);
        ValueTask<bool> DeleteAsync(long id);
        ValueTask<UserRoleViewModel> GetByIdAsync(long id);
        ValueTask<IEnumerable<UserRoleViewModel>> GetAllAsync(
            PaginationParams @params,
            Filter filter,
            string search = null);
        ValueTask<IEnumerable<UserRoleViewModel>> GetAllAsync();
    }
}

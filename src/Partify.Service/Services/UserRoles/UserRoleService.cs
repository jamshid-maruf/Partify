using Microsoft.EntityFrameworkCore;
using Partify.DataAccess.UnitOfWorks;
using Partify.Domain.Entities.Users;
using Partify.Service.Configurations;
using Partify.Service.Exceptions;
using Partify.Service.Extensions;
using Partify.Service.Helpers;

namespace Partify.Service.Services.UserRoles;

public class UserRoleService(IUnitOfWork unitOfWork) : IUserRoleService
{
    public async ValueTask<UserRole> CreateAsync(UserRole userRole)
    {
        var alreadyExistUserRole = await unitOfWork.UserRoleRepository
            .SelectAsync(ur => ur.Name.ToLower() == userRole.Name.ToLower());
        if (alreadyExistUserRole is not null)
            throw new AlreadyExistException($"This User Role is already exist with this name={userRole.Name}");

        userRole.CreatedById = HttpContextHelper.GetUserId;
        var createdUserRole = await unitOfWork.UserRoleRepository.InsertAsync(userRole);
        await unitOfWork.SaveAsync();
        return createdUserRole;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existUserRole = await unitOfWork.UserRoleRepository.SelectAsync(ur => ur.Id == id)
            ?? throw new NotFoundException($"This User Role is not found with this ID={id}");

        await unitOfWork.UserRoleRepository.DeleteAsync(existUserRole);
        await unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<UserRole>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var userRoles = unitOfWork.UserRoleRepository.Select().OrderBy(filter);

        if (!string.IsNullOrWhiteSpace(search))
            userRoles = userRoles.Where(userRole => userRole.Name.ToLower().Contains(search.ToLower()));

        var pagedUserRoles = userRoles.ToPaginateAsQueryable(@params);
        return await pagedUserRoles.ToListAsync();
    }

    public async ValueTask<UserRole> GetByIdAsync(long id)
    {
        var existUserRole = await unitOfWork.UserRoleRepository.SelectAsync(ur => ur.Id == id)
            ?? throw new NotFoundException($"This User Role is not found with this ID={id}");

        return existUserRole;
    }

    public async ValueTask<UserRole> UpdateAsync(long id, UserRole userRole)
    {
        var existUserRole = await unitOfWork.UserRoleRepository.SelectAsync(ur => ur.Id == id)
            ?? throw new NotFoundException($"This User Role is not found with this ID={id}");

        var alreadyExistUserRole = await unitOfWork.UserRoleRepository
            .SelectAsync(ur => ur.Id != id && ur.Name.ToLower() == userRole.Name.ToLower());
        if (alreadyExistUserRole is not null)
            throw new AlreadyExistException($"This User Role is already exist with this name={userRole.Name}");

        existUserRole.Name = userRole.Name;
        var updatedUserRole = await unitOfWork.UserRoleRepository.UpdateAsync(existUserRole);
        await unitOfWork.SaveAsync();
        return updatedUserRole;
    }
}

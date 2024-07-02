using Microsoft.EntityFrameworkCore;
using Partify.DataAccess.UnitOfWorks;
using Partify.Domain.Entities.Users;
using Partify.Service.Configurations;
using Partify.Service.Exceptions;
using Partify.Service.Extensions;
using Partify.Service.Helpers;
using Partify.Service.Services.Permissions;
using Partify.Service.Services.UserRoles;

namespace Partify.Service.Services.UserRolePermissions;

public class UserRolePermissionService(IUnitOfWork unitOfWork, IUserRoleService userRole, IPermissionService permissionService) : IUserRolePermissionService
{
    public async ValueTask<UserRolePermission> CreateAsync(UserRolePermission userRolePermission)
    {
        var alreadyExistUserRolePermission = await unitOfWork.UserRolePermissionRepository
               .SelectAsync(urp => urp.UserRoleId == userRolePermission.UserRoleId && urp.PermissionId == userRolePermission.PermissionId);
        if (alreadyExistUserRolePermission is not null)
            throw new AlreadyExistException($"This User Role Permission is already exist with this Id={userRolePermission.Id}");

        var existUserRole = userRole.GetByIdAsync(userRolePermission.UserRoleId);
        var existPermission = permissionService.GetByIdAsync(userRolePermission.PermissionId);

        userRolePermission.CreatedById = HttpContextHelper.GetUserId;
        var createdUserRolePermission = await unitOfWork.UserRolePermissionRepository.InsertAsync(userRolePermission);
        await unitOfWork.SaveAsync();
        return createdUserRolePermission;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existUserRolePermission = await unitOfWork.UserRolePermissionRepository.SelectAsync(urp => urp.Id == id)
            ?? throw new NotFoundException($"This User Role Permission is not found with this ID={id}");

        await unitOfWork.UserRolePermissionRepository.DeleteAsync(existUserRolePermission);
        await unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<UserRolePermission>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var userRolePermissions = unitOfWork.UserRolePermissionRepository.Select().OrderBy(filter);

        if (!string.IsNullOrWhiteSpace(search))
            userRolePermissions = userRolePermissions.Where(userRolePermission => userRolePermission.UserRole.Name.ToLower().Contains(search.ToLower()));

        var pagedUserRoles = userRolePermissions.ToPaginateAsQueryable(@params);
        return await pagedUserRoles.ToListAsync();
    }

    public async ValueTask<UserRolePermission> GetByIdAsync(long id)
    {
        var existUserRolePermission = await unitOfWork.UserRolePermissionRepository.SelectAsync(urp => urp.Id == id)
          ?? throw new NotFoundException($"This User Role Permission is not found with this ID={id}");

        return existUserRolePermission;
    }

    public async ValueTask<UserRolePermission> UpdateAsync(long id, UserRolePermission userRolePermission)
    {
        var existUserRolePermission = await unitOfWork.UserRolePermissionRepository.SelectAsync(urp => urp.Id == id)
               ?? throw new NotFoundException($"This User Role Permission is not found with this ID={id}");
        var existUserRole = userRole.GetByIdAsync(userRolePermission.UserRoleId);

        var existPermission = permissionService.GetByIdAsync(userRolePermission.PermissionId);

        var alreadyExistUserRolePermission = await unitOfWork.UserRolePermissionRepository
            .SelectAsync(urp => urp.Id != id && urp.UserRoleId == userRolePermission.UserRoleId && urp.PermissionId == userRolePermission.PermissionId);
        if (alreadyExistUserRolePermission is not null)
            throw new AlreadyExistException($"This User Role is already exist with this dates = {userRolePermission.UserRoleId} and {userRolePermission.PermissionId}");

        existUserRolePermission.UserRoleId = userRolePermission.UserRoleId;
        existUserRolePermission.UserRole = userRolePermission.UserRole;
        existUserRolePermission.PermissionId = userRolePermission.PermissionId;
        existUserRolePermission.Permission = userRolePermission.Permission;

        var updatedUserRolePermission = await unitOfWork.UserRolePermissionRepository.UpdateAsync(existUserRolePermission);
        await unitOfWork.SaveAsync();
        return updatedUserRolePermission;
    }
}
using Partify.DataAccess.UnitOfWorks;
using Partify.Service.Services.AdCategories;
using Partify.Service.Services.AdCategoryPropertyValues;
using Partify.Service.Services.Facilities;
using Partify.Service.Services.Permissions;
using Partify.Service.Services.UserRolePermissions;
using Partify.Service.Services.UserRoles;
using Partify.Service.Services.Users;
using Partify.Web.WebServices.AdCategories;
using Partify.Web.WebServices.AdCategoryPropertyValues;
using Partify.Web.WebServices.Facilities;
using Partify.Web.WebServices.Permissions;
using Partify.Web.WebServices.UserRolePermissions;
using Partify.Web.WebServices.UserRoles;
using Partify.Web.WebServices.Users;

namespace Partify.Web.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<IAdCategoryService, AdCategoryService>();
        services.AddScoped<IUserRolePermissionService, UserRolePermissionService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IFacilityService, FacilityService>();
        services.AddScoped<IAdCategoryPropertyValueService, AdCategoryPropertyValueService>();
    }

    public static void AddWebServices(this IServiceCollection services)
    {
        services.AddScoped<IUserWebService, UserWebService>();
        services.AddScoped<IUserRoleWebService, UserRoleWebService>();
        services.AddScoped<IAdCategoryPropertyValueWebService, AdCategoryPropertyValueWebService>();
        services.AddScoped<IUserRolePermissionWebService, UserRolePermissionWebService>();
        services.AddScoped<IPermissionWebService, PermissionWebService>();
        services.AddScoped<IFacilityWebService, FacilityWebService>();
    }
}

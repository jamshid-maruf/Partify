using Partify.DataAccess.UnitOfWorks;
using Partify.Service.Services.Accounts;
using Partify.Service.Services.AdCategories;
using Partify.Service.Services.AdComments;
using Partify.Service.Services.AdImages;
using Partify.Service.Services.Ads;
using Partify.Service.Services.AdScores;
using Partify.Service.Services.AdViews;
using Partify.Service.Services.Assets;
using Partify.Service.Services.Facilities;
using Partify.Service.Services.FavoriteAds;
using Partify.Service.Services.Permissions;
using Partify.Service.Services.UserRolePermissions;
using Partify.Service.Services.UserRoles;
using Partify.Service.Services.Users;
using Partify.Web.WebServices.AdCategories;
using Partify.Web.WebServices.UserRoles;
using Partify.Web.WebServices.Users;

namespace Partify.Web.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddServices(this IServiceCollection  services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<IAdCategoryService, AdCategoryService>();
    }

    public static void AddWebServices(this IServiceCollection services)
    {
        services.AddScoped<IUserWebService, UserWebService>();
        services.AddScoped<IUserRoleWebService, UserRoleWebService>();
        services.AddScoped<IAdCategoryWebService, AdCategoryWebService>();
    }
}

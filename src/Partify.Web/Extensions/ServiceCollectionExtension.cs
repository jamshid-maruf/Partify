using Partify.DataAccess.UnitOfWorks;
using Partify.Service.Helpers;
using Partify.Service.Services.Accounts;
using Partify.Service.Services.AdCategories;
using Partify.Service.Services.AdCategoryPropertyValues;
using Partify.Service.Services.Facilities;
using Partify.Service.Services.Permissions;
using Partify.Service.Services.UserRolePermissions;
using Partify.Service.Services.UserRoles;
using Partify.Service.Services.Users;
using Partify.Web.WebServices.Accounts;
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
        services.AddScoped<IAccountService, AccountService>();
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
        services.AddScoped<IAccountWebService, AccountWebService>();
        services.AddScoped<IAdCategoryWebService, AdCategoryWebService>();
        services.AddScoped<IAdCategoryPropertyValueWebService, AdCategoryPropertyValueWebService>();
        services.AddScoped<IUserRolePermissionWebService, UserRolePermissionWebService>();
        services.AddScoped<IPermissionWebService, PermissionWebService>();
        services.AddScoped<IFacilityWebService, FacilityWebService>();
    }

    public static void AddPathInitializer(this WebApplication app)
    {
        HttpContextHelper.ContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
        EnvironmentHelper.JwtKey = app.Configuration.GetSection("Jwt:Key").Value;
        EnvironmentHelper.TokenLifeTimeInHour = app.Configuration.GetSection("Jwt:LifeTime").Value;
        EnvironmentHelper.SmtpHost = app.Configuration.GetSection("Email:SmtpHost").Value;
        EnvironmentHelper.SmtpPort = app.Configuration.GetSection("Email:SmtpPort").Value;
        EnvironmentHelper.EmailAddress = app.Configuration.GetSection("Email:EmailAddress").Value;
        EnvironmentHelper.EmailPassword = app.Configuration.GetSection("Email:EmailPassword").Value;
        EnvironmentHelper.SuperAdminLogin = app.Configuration.GetSection("SuperAdmin:Login").Value;
        EnvironmentHelper.SuperAdminPassword = app.Configuration.GetSection("SuperAdmin:Password").Value;
    }

}

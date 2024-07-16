using AutoMapper;
using Partify.Domain.Entities.Ads;
using Partify.Domain.Entities.Facilities;
using Partify.Domain.Entities.Users;
using Partify.Web.Models.AdCategories;
using Partify.Web.Models.AdCategoryPropertyValues;
using Partify.Web.Models.Facilities;
using Partify.Web.Models.Permissions;
using Partify.Web.Models.UserRolePermissions;
using Partify.Web.Models.UserRoles;
using Partify.Web.Models.Users;
using Partify.WebApi.Models.AdCategoryProperties;


namespace Partify.Web.MapperConfigurations;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserRegisterModel, User>();
        CreateMap<UserUpdateModel, User>();
        CreateMap<UserCreateModel, User>();
        CreateMap<User, UserViewModel>();
        CreateMap<UserRegisterModel, User>();
        CreateMap<User, LoginViewModel>();

        CreateMap<UserRole, UserRoleCreateModel>().ReverseMap();
        CreateMap<UserRole, UserRoleUpdateModel>().ReverseMap();
        CreateMap<UserRole, UserRoleViewModel>().ReverseMap();

        CreateMap<UserRolePermissionCreateModel, UserRolePermission>();
        CreateMap<UserRolePermissionUpdateModel, UserRolePermission>();
        CreateMap<UserRolePermission, UserRolePermissionViewModel>();

        CreateMap<PermissionCreateModel, Permission>();
        CreateMap<PermissionUpdateModel, Permission>();
        CreateMap<Permission, PermissionViewModel>();

        //CreateMap<AdImage, AdImageCreateModel>().ReverseMap();
        //CreateMap<AdImage, AdImageViewModel>().ReverseMap();

        //CreateMap<FavoriteAd, FavoriteAdViewModel>().ReverseMap();
        //CreateMap<FavoriteAd, FavoriteAdCreateModel>().ReverseMap();

        //CreateMap<AdScore, AdScoreCreateModel>().ReverseMap();
        //CreateMap<AdScore, AdScoreViewModel>().ReverseMap();

        //CreateMap<AdView, AdViewViewModel>().ReverseMap();



        //CreateMap<AdCommentCreateModel, AdComment>();
        //CreateMap<AdCommentUpdateModel, AdComment>();
        //CreateMap<AdComment, AdCommentViewModel>();

        //CreateMap<AdCreateModel, Ad>();
        //CreateMap<AdUpdateModel, Ad>();
        //CreateMap<Ad, AdViewModel>();

        CreateMap<FacilityCreateModel, Facility>();
        CreateMap<FacilityUpdateModel, Facility>();
        CreateMap<Facility, FacilityViewModel>();

        CreateMap<AdCategoryCreateModel, AdCategory>();
        CreateMap<AdCategoryUpdateModel, AdCategory>();
        CreateMap<AdCategory, AdCategoryViewModel>();

        CreateMap<AdCategoryPropertyValueCreateModel, AdCategoryPropertyValue>();
        CreateMap<AdCategoryPropertyValueUpdateModel, AdCategoryPropertyValue>();
        CreateMap<AdCategoryPropertyValue, AdCategoryPropertyValueViewModel>();
    }
}

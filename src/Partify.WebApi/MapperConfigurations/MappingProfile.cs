using AutoMapper;
using Partify.Domain.Entities.Ads;
using Partify.Domain.Entities.Facilities;
using Partify.Domain.Entities.Users;
using Partify.WebApi.Models.AdCategories;
using Partify.WebApi.Models.AdCategoryProperties;
using Partify.WebApi.Models.AddComments;
using Partify.WebApi.Models.AdImages;
using Partify.WebApi.Models.Ads;
using Partify.WebApi.Models.AdScores;
using Partify.WebApi.Models.AdViews;
using Partify.WebApi.Models.Facilities;
using Partify.WebApi.Models.FavoriteAds;
using Partify.WebApi.Models.Permissions;
using Partify.WebApi.Models.UserRolePermissions;
using Partify.WebApi.Models.UserRoles;
using Partify.WebApi.Models.Users;

namespace Partify.WebApi.MapperConfigurations;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserRegisterModel, User>();
        CreateMap<UserUpdateModel, User>();
        CreateMap<User, UserViewModel>();
        CreateMap<UserRegisterModel, User>();
        CreateMap<User, LoginViewModel>();

        CreateMap<UserRole, UserRoleCreateModel>().ReverseMap();
        CreateMap<UserRole, UserRoleUpdateModel>().ReverseMap();
        CreateMap<UserRole, UserRoleViewModel>().ReverseMap();

        CreateMap<AdImage, AdImageCreateModel>().ReverseMap();
        CreateMap<AdImage, AdImageViewModel>().ReverseMap();

        CreateMap<FavoriteAd, FavoriteAdViewModel>().ReverseMap();
        CreateMap<FavoriteAd, FavoriteAdCreateModel>().ReverseMap();

        CreateMap<AdScore, AdScoreCreateModel>().ReverseMap();
        CreateMap<AdScore, AdScoreViewModel>().ReverseMap();

        CreateMap<AdView, AdViewViewModel>().ReverseMap();

        CreateMap<PermissionCreateModel, Permission>();
        CreateMap<PermissionUpdateModel, Permission>();
        CreateMap<Permission, PermissionViewModel>();

        CreateMap<UserRolePermissionCreateModel, UserRolePermission>();
        CreateMap<UserRolePermissionUpdateModel, UserRolePermission>();
        CreateMap<UserRolePermission, UserRolePermissionViewModel>();

        CreateMap<AdCommentCreateModel, AdComment>();
        CreateMap<AdCommentUpdateModel, AdComment>();
        CreateMap<AdComment, AdCommentViewModel>();

        CreateMap<AdCreateModel, Ad>();
        CreateMap<AdUpdateModel, Ad>();
        CreateMap<Ad, AdViewModel>();

        CreateMap<FacilityCreateModel, Facility>();
        CreateMap<FacilityUpdateModel, Facility>();
        CreateMap<Facility, FacilityViewModel>();

        CreateMap<AdCategoryCreateModel, AdCategory>();
        CreateMap<AdCategoryUpdateModel, AdCategory>();
        CreateMap<AdCategory, AdCategoryViewModel>();

        CreateMap<AdCategoryPropertyCreateModel, AdCategoryProperty>();
        CreateMap<AdCategoryPropertyUpdateModel, AdCategoryProperty>();
        CreateMap<AdCategoryProperty, AdCategoryPropertyViewModel>();
    }
}

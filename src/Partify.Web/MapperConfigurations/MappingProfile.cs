using AutoMapper;
using Partify.Domain.Entities.Ads;
using Partify.Domain.Entities.Facilities;
using Partify.Domain.Entities.Users;
using Partify.Web.Models.UserRoles;
using Partify.Web.Models.Users;

namespace Partify.Web.MapperConfigurations;

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

        //CreateMap<AdImage, AdImageCreateModel>().ReverseMap();
        //CreateMap<AdImage, AdImageViewModel>().ReverseMap();

        //CreateMap<FavoriteAd, FavoriteAdViewModel>().ReverseMap();
        //CreateMap<FavoriteAd, FavoriteAdCreateModel>().ReverseMap();

        //CreateMap<AdScore, AdScoreCreateModel>().ReverseMap();
        //CreateMap<AdScore, AdScoreViewModel>().ReverseMap();

        //CreateMap<AdView, AdViewViewModel>().ReverseMap();

        //CreateMap<PermissionCreateModel, Permission>();
        //CreateMap<PermissionUpdateModel, Permission>();
        //CreateMap<Permission, PermissionViewModel>();

        //CreateMap<UserRolePermissionCreateModel, UserRolePermission>();
        //CreateMap<UserRolePermissionUpdateModel, UserRolePermission>();
        //CreateMap<UserRolePermission, UserRolePermissionViewModel>();

        //CreateMap<AdCommentCreateModel, AdComment>();
        //CreateMap<AdCommentUpdateModel, AdComment>();
        //CreateMap<AdComment, AdCommentViewModel>();

        //CreateMap<AdCreateModel, Ad>();
        //CreateMap<AdUpdateModel, Ad>();
        //CreateMap<Ad, AdViewModel>();

        //CreateMap<FacilityCreateModel, Facility>();
        //CreateMap<FacilityUpdateModel, Facility>();
        //CreateMap<Facility, FacilityViewModel>();

        //CreateMap<AdCategoryCreateModel, AdCategory>();
        //CreateMap<AdCategoryUpdateModel, AdCategory>();
        //CreateMap<AdCategory, AdCategoryViewModel>();
    }
}

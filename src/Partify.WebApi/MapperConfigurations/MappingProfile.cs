using AutoMapper;
using Partify.Domain.Entities.Ads;
using Partify.Domain.Entities.Users;
using Partify.WebApi.Models.AdViews;
using Partify.WebApi.Models.FavoriteAds;
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

        CreateMap<AdView, AdViewViewModel>().ReverseMap();

        CreateMap<FavoriteAd, FavoriteAdViewModel>().ReverseMap();
        CreateMap<FavoriteAd, FavoriteAdCreateModel>().ReverseMap();

    }
}

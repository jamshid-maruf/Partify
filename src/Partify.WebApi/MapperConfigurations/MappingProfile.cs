using AutoMapper;
using Partify.Domain.Entities.Users;
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
	}
}

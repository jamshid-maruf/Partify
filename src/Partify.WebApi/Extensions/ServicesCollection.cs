using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Partify.DataAccess.UnitOfWorks;
using Partify.Service.Services.Accounts;
using Partify.Service.Services.Users;
using Partify.WebApi.ApiServices.Accounts;
using Partify.WebApi.ApiServices.Users;
using Partify.WebApi.Middlewares;
using System.Text;

namespace Partify.WebApi.Extensions;

public static class ServicesCollection
{
	public static void AddServices(this IServiceCollection services)
	{
		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddScoped<IUserService, UserService>();
		services.AddScoped<IAccountService, AccountService>();
	}

	public static void AddApiServices(this IServiceCollection services)
	{
		services.AddScoped<IAccountApiService, AccountApiService>();
		services.AddScoped<IUserApiService, UserApiService>();
	}

	public static void AddExceptions(this IServiceCollection services)
	{
		services.AddExceptionHandler<NotFoundExceptionMiddleware>();
		services.AddExceptionHandler<ForbiddenExceptionMiddleware>();
		services.AddExceptionHandler<AlreadyExistExceptionMiddleware>();
		services.AddExceptionHandler<InternalServerExceptionMiddleware>();
		services.AddExceptionHandler<ArgumentIsNotValidExceptionMiddleware>();
	}

	public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddAuthentication(x =>
		{
			x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		}).AddJwtBearer(o =>
		{
			var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
			o.SaveToken = true;
			o.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = false,
				ValidateAudience = false,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = configuration["Jwt:Issuer"],
				ValidAudience = configuration["Jwt:Audience"],
				IssuerSigningKey = new SymmetricSecurityKey(key)
			};
		});
	}

	public static void ConfigureSwagger(this IServiceCollection services)
	{
		services.AddSwaggerGen(setup =>
		{
			var jwtSecurityScheme = new OpenApiSecurityScheme
			{
				BearerFormat = "JWT",
				Name = "JWT Authentication",
				In = ParameterLocation.Header,
				Type = SecuritySchemeType.Http,
				Scheme = JwtBearerDefaults.AuthenticationScheme,
				Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

				Reference = new OpenApiReference
				{
					Id = JwtBearerDefaults.AuthenticationScheme,
					Type = ReferenceType.SecurityScheme
				}
			};

			setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

			setup.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{ jwtSecurityScheme, Array.Empty<string>() }
				});
		});
	}
}

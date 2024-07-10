using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Partify.DataAccess.UnitOfWorks;
using Partify.Domain.Entities.Users;
using Partify.Service.Exceptions;
using Partify.Service.Helpers;
using System.Net.Http.Headers;

namespace Partify.Service.Services.Accounts;

public class AccountService(IUnitOfWork unitOfWork, IMemoryCache memoryCache) : IAccountService
{
	public async ValueTask RegisterAsync(User user)
	{
		var existUser = await unitOfWork.UserRepository.SelectAsync(u => u.Phone == user.Phone && u.Email == user.Email);
		if (existUser?.Phone is not null)
		{
			throw new AlreadyExistException($"This user is already exist with this phone | Phone={user.Phone}");
		}
		else if (existUser?.Email is not null)
		{
			throw new AlreadyExistException($"This user is already exist with this email | Email={user.Email}");
		}
		else if (existUser?.Phone is not null && existUser?.Email is not null)
		{
			throw new AlreadyExistException($"This user is already exist with this email and phone | Email={user.Email} & Phone={existUser.Phone}");
		}

		var roleWhichIsUser = await unitOfWork.UserRoleRepository.SelectAsync(u => u.Name.ToLower() == "user");

		user.RoleId = roleWhichIsUser.Id;
		user.Password = PasswordHasher.Hash(user.Password);
		var json = JsonConvert.SerializeObject(user);
		CacheSet($"registerKey-{user.Email}", json);

		await EmailHelper.SendCodeAsync(memoryCache, user.Email, $"registerCodeKey-{user.Email}");
	}

	public async ValueTask RegisterVerifyAsync(string email, string code)
	{
		var codeInCache = memoryCache.Get($"registerCodeKey-{email}");
		if (codeInCache?.ToString() != code)
			throw new ArgumentIsNotValidException("Invalid code");

		CacheSet($"verifiedAccount-{email}", "verified");

		await Task.CompletedTask;
	}

	public async ValueTask<User> CreateAsync(string email)
	{
		var cacheValue = memoryCache.Get($"verifiedAccount-{email}");
		if (cacheValue is null)
			throw new ArgumentIsNotValidException("Account is not verified");

		var json = memoryCache.Get($"registerKey-{email}");
		var user = JsonConvert.DeserializeObject<User>(json.ToString());

		var createdUser = await unitOfWork.UserRepository.InsertAsync(user);
		await unitOfWork.SaveAsync();

		await unitOfWork.MerchantRepository.InsertAsync(new Merchant { UserId = createdUser.Id });
		await unitOfWork.SaveAsync();

		return createdUser;
	}

	public async ValueTask<(User user, string token)> LoginAsync(long phone, string password)
	{
		if(EnvironmentHelper.SuperAdminLogin == phone.ToString() && EnvironmentHelper.SuperAdminPassword == password)
		{
			var superAdminRole = await unitOfWork.UserRoleRepository
				.SelectAsync(role => role.Name.ToLower() == "superadmin");

			var user = new User
			{
				Id = -1,
				Role = superAdminRole,
				RoleId = superAdminRole.Id,
				Phone = Convert.ToInt64(EnvironmentHelper.SuperAdminLogin)
			};
			return (user: user,	token: AuthHelper.GenerateToken(-1, Convert.ToInt64(EnvironmentHelper.SuperAdminLogin), "SuperAdmin"));
		}
		else
		{
			var existUser = await unitOfWork.UserRepository
				.SelectAsync(expression: user => user.Phone == phone, includes: ["Role"])
			?? throw new ForbiddenException("Phone or Password is invalid");

			if (!PasswordHasher.Verify(password, existUser.Password))
				throw new ForbiddenException("Phone or Password is invalid");

			return (user: existUser, token: AuthHelper.GenerateToken(existUser.Id, existUser.Phone, existUser.Role.Name));
		}
	}

	public async ValueTask<bool> SendCodeAsync(string email)
	{
		var existUser = await unitOfWork.UserRepository.SelectAsync(user => user.Email == email)
			?? throw new ForbiddenException("This user is not found");

		await EmailHelper.SendCodeAsync(memoryCache, existUser.Email, $"codeKey-{email}");

		return true;
	}

	public async ValueTask<bool> VerifyAsync(string email, string code)
	{
		var existUser = await unitOfWork.UserRepository.SelectAsync(user => user.Email == email)
			?? throw new ForbiddenException("This user is not found");

		var codeInCache = memoryCache.Get($"codeKey-{email}");
		if (codeInCache.ToString() != code)
			throw new ArgumentIsNotValidException("Code is invalid");

		CacheSet($"verified-{email}", "verified");

		return true;
	}

	public async ValueTask<User> ResetPasswordAsync(string email, string newPassword)
	{
		var existUser = await unitOfWork.UserRepository.SelectAsync(user => user.Email == email)
			?? throw new ForbiddenException("This user is not found");

		var cacheValue = memoryCache.Get($"verified-{existUser.Email}");
		if (cacheValue is null)
			throw new ArgumentIsNotValidException("Account is not verified");

		existUser.Password = PasswordHasher.Hash(newPassword);
		await unitOfWork.UserRepository.UpdateAsync(existUser);
		await unitOfWork.SaveAsync();

		memoryCache.Remove($"verified-{existUser.Email}");

		return existUser;
	}

	private void CacheSet(string key, string value)
	{
		var cacheOptions = new MemoryCacheEntryOptions()
				.SetSlidingExpiration(TimeSpan.FromSeconds(60))
				.SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
				.SetPriority(CacheItemPriority.Normal)
				.SetSize(1024);

		memoryCache.Set(key, value, cacheOptions);
	}
}
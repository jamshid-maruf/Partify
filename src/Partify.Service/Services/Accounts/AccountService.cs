using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Partify.DataAccess.UnitOfWorks;
using Partify.Domain.Entities.Users;
using Partify.Service.Exceptions;
using Partify.Service.Helpers;
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

		user.Password = PasswordHasher.Hash(user.Password);
		var json = JsonConvert.SerializeObject(user);
		CacheSet($"registerKey-{user.Phone}", json);

		await EmailHelper.SendCodeAsync(memoryCache, user.Email, $"registerCodeKey-{user.Phone}");
	}

	public async ValueTask RegisterVerifyAsync(long phone, string code)
	{
		var codeInCache = memoryCache.Get($"registerCodeKey-{phone}");
		if (codeInCache?.ToString() != code)
			throw new ArgumentIsNotValidException("Invalid code");

		CacheSet($"verifiedAccount-{phone}", "verified");

		await Task.CompletedTask;
	}

	public async ValueTask<User> CreateAsync(long phone)
	{
		var cacheValue = memoryCache.Get($"verifiedAccount-{phone}");
		if (cacheValue is null)
			throw new ArgumentIsNotValidException("Account is not verified");

		var json = memoryCache.Get($"registerKey-{phone}");
		var user = JsonConvert.DeserializeObject<User>(json.ToString());

		var createdUser = await unitOfWork.UserRepository.InsertAsync(user);
		await unitOfWork.SaveAsync();
		return createdUser;
	}

	public async ValueTask<(User user, string token)> LoginAsync(long phone, string password)
	{
		var existUser = await unitOfWork.UserRepository.SelectAsync(user => user.Phone == phone)
			?? throw new ForbiddenException("Phone or Password is invalid");

		if (!PasswordHasher.Verify(password, existUser.Password))
			throw new ForbiddenException("Phone or Password is invalid");

		return (user: existUser, token: AuthHelper.GenerateToken(existUser));
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

	public async ValueTask<User> ResetPasswordAsync(long phone, string newPassword)
	{
		var existUser = await unitOfWork.UserRepository.SelectAsync(user => user.Phone == phone)
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
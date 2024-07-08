using AutoMapper;
using Partify.Domain.Entities.Users;
using Partify.Service.Exceptions;
using Partify.Service.Services.Accounts;
using Partify.Service.Services.UserRolePermissions;
using Partify.WebApi.Extensions;
using Partify.WebApi.Models.Permissions;
using Partify.WebApi.Models.Users;
using Partify.WebApi.Validators.Accounts;

namespace Partify.WebApi.ApiServices.Accounts;

public class AccountApiService(
	IMapper mapper,
	IAccountService accountService,
	AccountLoginValidator loginValidator,
	AccountVerifyValidator verifyValidator,
	AccountCreateValidator createValidator,
	AccountSendCodeValidator sendCodeValidator,
	AccountRegisterModelValidator registerValidator,
	AccountResetPasswordValidator resetPasswordValidator,
	IUserRolePermissionService userRolePermissionService) : IAccountApiService
{
	public async ValueTask RegisterAsync(UserRegisterModel registerModel)
	{
		await registerValidator.EnsureValidatedAsync(registerModel);
		await accountService.RegisterAsync(mapper.Map<User>(registerModel));
	}

	public async ValueTask RegisterVerifyAsync(string email, string code)
	{
		await verifyValidator.EnsureValidatedAsync(email, code);
		await accountService.RegisterVerifyAsync(email, code);
	}

	public async ValueTask<UserViewModel> CreateAsync(string email)
	{
		var validatorResult = await createValidator.ValidateAsync(email);
		if (validatorResult.Errors.Any())
			throw new ArgumentIsNotValidException(validatorResult.Errors.FirstOrDefault().ErrorMessage);

		var result = await accountService.CreateAsync(email);
		return mapper.Map<UserViewModel>(result);
	}

	public async ValueTask<LoginViewModel> LoginAsync(long phone, string password)
	{
		var validatorResult = await loginValidator.ValidateAsync((phone, password));
		if (validatorResult.Errors.Any())
			throw new ArgumentIsNotValidException(validatorResult.Errors.FirstOrDefault().ErrorMessage);

		var result = await accountService.LoginAsync(phone, password);
		var rolePermissions = await userRolePermissionService.GetAlByRoleIdAsync(result.user.RoleId);
		var mappedResult = mapper.Map<LoginViewModel>(result.user);
		var permissions = rolePermissions.Select(p => p.Permission);
		mappedResult.Permissions = mapper.Map<IEnumerable<PermissionViewModel>>(permissions);
		mappedResult.Token = result.token;
		return mappedResult;
	}

	public async ValueTask<bool> SendCodeAsync(string email)
	{
		await sendCodeValidator.EnsureValidatedAsync(email);
		return await accountService.SendCodeAsync(email);
	}

	public async ValueTask<bool> VerifyAsync(string email, string code)
	{
		var result = await verifyValidator.ValidateAsync((email, code));
		if (result.Errors.Any())
			throw new ArgumentIsNotValidException(result.Errors.FirstOrDefault().ErrorMessage);

		return await accountService.VerifyAsync(email, code);
	}

	public async ValueTask<UserViewModel> ResetPasswordAsync(string email, string newPassword)
	{
		var validatorResult = await resetPasswordValidator.ValidateAsync((email, newPassword));
		if (validatorResult.Errors.Any())
			throw new ArgumentIsNotValidException(validatorResult.Errors.FirstOrDefault().ErrorMessage);

		var result = await accountService.ResetPasswordAsync(email, newPassword);
		return mapper.Map<UserViewModel>(result);
	}
}
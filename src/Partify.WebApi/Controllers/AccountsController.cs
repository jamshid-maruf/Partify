using Microsoft.AspNetCore.Mvc;
using Partify.WebApi.ApiServices.Accounts;
using Partify.WebApi.Models.Commons;
using Partify.WebApi.Models.Users;

namespace Partify.WebApi.Controllers;

public class AccountsController(IAccountApiService accountApiService) : BaseController
{
	[HttpPost("register")]
	public async ValueTask<IActionResult> RegisterAsync(UserRegisterModel registerModel)
	{
		await accountApiService.RegisterAsync(registerModel);
		return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
		});
	}

	[HttpGet("register-verify")]
	public async ValueTask<IActionResult> RegisterVerifyAsync(long phone, string code)
	{
		await accountApiService.RegisterVerifyAsync(phone, code);
		return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
		});
	}

	[HttpPost("create")]
	public async ValueTask<IActionResult> CreateAsync(long phone)
	{
		return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
			Data = await accountApiService.CreateAsync(phone)
		});
	}

	[HttpPost("login")]
	public async ValueTask<IActionResult> LoginAsync(long phone, string password)
	{
		return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
			Data = await accountApiService.LoginAsync(phone, password)
		});
	}

	[HttpPost("send-code")]
	public async ValueTask<IActionResult> SendCodeAsync(string email)
	{
		return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
			Data = await accountApiService.SendCodeAsync(email)
		});
	}

	[HttpPost("verify")]
	public async ValueTask<IActionResult> VerifyAsync(string email, string code)
	{
		return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
			Data = await accountApiService.VerifyAsync(email, code)
		});
	}


	[HttpPost("reset-password")]
	public async ValueTask<IActionResult> ResetPasswordAsync(long phone, string newPassword)
	{
		return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
			Data = await accountApiService.ResetPasswordAsync(phone, newPassword)
		});
	}
}
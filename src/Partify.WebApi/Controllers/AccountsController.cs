using Microsoft.AspNetCore.Mvc;
using Partify.WebApi.ApiServices.Accounts;
using Partify.WebApi.Models.Commons;
using Partify.WebApi.Models.Users;

namespace Partify.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController(IAccountApiService accountApiService) : ControllerBase
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
	public async ValueTask<IActionResult> RegisterVerifyAsync(string email, string code)
	{
		await accountApiService.RegisterVerifyAsync(email, code);
		return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
		});
	}

	[HttpPost("create")]
	public async ValueTask<IActionResult> CreateAsync(string email)
	{
		return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
			Data = await accountApiService.CreateAsync(email)
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
	public async ValueTask<IActionResult> ResetPasswordAsync(string email, string newPassword)
	{
		return Ok(new Response
		{
			StatusCode = 200,
			Message = "Success",
			Data = await accountApiService.ResetPasswordAsync(email, newPassword)
		});
	}
}
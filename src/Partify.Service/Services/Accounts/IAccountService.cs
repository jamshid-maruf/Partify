using Partify.Domain.Entities.Users;

namespace Partify.Service.Services.Accounts;

public interface IAccountService
{
	ValueTask RegisterAsync(User user);
	ValueTask RegisterVerifyAsync(string email, string code);
	ValueTask<User> CreateAsync(string email);
	ValueTask<(User user, string token)> LoginAsync(long phone, string password);
	ValueTask<User> WebLoginAsync(long phone, string password);
    ValueTask<bool> SendCodeAsync(string email);
	ValueTask<bool> VerifyAsync(string email, string code);
	ValueTask<User> ResetPasswordAsync(string email, string newPassword);
}
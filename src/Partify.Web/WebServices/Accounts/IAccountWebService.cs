using Partify.Web.Models.Accounts;

namespace Partify.Web.WebServices.Accounts;

public interface IAccountWebService
{
    ValueTask<LoginViewModel> LoginAsync(LoginModel model);
    ValueTask<bool> SendCodeAsync(string email);
    ValueTask<bool> VerifyAsync(string email, string code);
    ValueTask<LoginViewModel> ResetPasswordAsync(string email, string newPassword);
}
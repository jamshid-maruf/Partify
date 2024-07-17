using AutoMapper;
using Partify.Service.Services.Accounts;
using Partify.Web.Models.Accounts;

namespace Partify.Web.WebServices.Accounts;

public class AccountWebService(IAccountService accountService, IMapper mapper) : IAccountWebService
{
    public async ValueTask<LoginViewModel> LoginAsync(LoginModel model)
    {
        var result = await accountService.LoginAsync(model.Phone, model.Password);
        return new LoginViewModel
        {
            Id = result.user.Id,
            Email = result.user.Email,
            Phone = result.user.Phone,
            LastName = result.user.LastName,
            FirstName = result.user.FirstName
        };
    }

    public async ValueTask<LoginViewModel> ResetPasswordAsync(string email, string newPassword)
    {
        var result = await accountService.ResetPasswordAsync(email, newPassword);
        return mapper.Map<LoginViewModel>(result);
    }

    public async ValueTask<bool> SendCodeAsync(string email)
    {
        return await accountService.SendCodeAsync(email);
    }

    public ValueTask<bool> VerifyAsync(string email, string code)
    {
        return accountService.VerifyAsync(email, code);
    }
}
using FluentValidation;
using Partify.WebApi.Helpers;

namespace Partify.WebApi.Validators.Accounts;

public class AccountSendCodeValidator : AbstractValidator<string>
{
	public AccountSendCodeValidator()
	{
		RuleFor(model => model)
			.NotNull()
			.Must(ValidationHelper.IsValidEmail)
			.WithMessage("Email is not valid");
	}
}

using FluentValidation;
using Partify.WebApi.Helpers;

namespace Partify.WebApi.Validators.Accounts;

public class AccountVerifyValidator : AbstractValidator<(string email, string code)>
{
	public AccountVerifyValidator()
	{
		RuleFor(model => model.email)
			.NotNull()
			.Must(ValidationHelper.IsValidEmail)
			.WithMessage(model => $"{nameof(model.email)} is not valid");

		RuleFor(model => model.code)
			.NotNull()
			.Must(model => model.Length == 5)
			.WithMessage(model => $"{nameof(model.code)} is not valid");
	}
}
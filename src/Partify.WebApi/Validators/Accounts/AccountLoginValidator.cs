using FluentValidation;
using Partify.WebApi.Helpers;

namespace Partify.WebApi.Validators.Accounts;

public class AccountLoginValidator : AbstractValidator<(long phone, string password)>
{
	public AccountLoginValidator()
	{
		RuleFor(model => model.phone)
			.NotNull()
			.Must(ValidationHelper.IsValidPhoneNumber)
			.WithMessage("Phone is not valid");

		RuleFor(model => model.password)
			.NotNull()
			.Must(ValidationHelper.IsHardPassword)
			.WithMessage("Password is not valid, password must be hard!");
	}
}
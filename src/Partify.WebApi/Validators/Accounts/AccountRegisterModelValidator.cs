using FluentValidation;
using Partify.WebApi.Helpers;
using Partify.WebApi.Models.Users;

namespace Partify.WebApi.Validators.Accounts;

public class AccountRegisterModelValidator : AbstractValidator<UserRegisterModel>
{
	public AccountRegisterModelValidator()
	{
		RuleFor(user => user.FirstName)
			.NotNull()
			.NotEmpty()
			.WithMessage(user => $"{nameof(user.FirstName)} is not specified");

		RuleFor(user => user.LastName)
			.NotNull()
			.NotEmpty()
			.WithMessage(user => $"{nameof(user.FirstName)} is not specified");

		RuleFor(user => user.Phone)
			.NotNull()
			.Must(ValidationHelper.IsValidPhoneNumber)
			.WithMessage(user => $"{nameof(user.Phone)} is not valid");

		RuleFor(user => user.Email)
			.NotNull()
			.Must(ValidationHelper.IsValidEmail)
			.WithMessage(user => $"{nameof(user.Email)} is not valid");

		RuleFor(user => user.Password)
			.NotNull()
			.Must(ValidationHelper.IsHardPassword)
			.WithMessage(user => $"{nameof(user.Password)} is not valid, password must be hard");
	}
}
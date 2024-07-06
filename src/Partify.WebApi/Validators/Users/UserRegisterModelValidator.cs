using FluentValidation;
using Partify.WebApi.Models.Users;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Partify.WebApi.Validators.Users;

public class UserRegisterModelValidator : AbstractValidator<UserRegisterModel>
{
    public UserRegisterModelValidator()
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
			.Must(IsValidPhoneNumber)
			.WithMessage(user => $"{nameof(user.Phone)} is not valid");

		RuleFor(user => user.Email)
			.NotNull()
			.Must(IsValidEmail)
			.WithMessage(user => $"{nameof(user.Email)} is not valid");

		RuleFor(user => user.Password)
			.NotNull()
			.Must(IsHardPassword)
			.WithMessage(user => $"{nameof(user.Password)} is not valid, password must be hard");
	}

	public bool IsValidPhoneNumber(long phone)
	{
		return true;
	}

	public bool IsValidEmail(string email)
	{
		string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
		return Regex.IsMatch(email, pattern);
	}

	public bool IsHardPassword(string password)
	{
		// Check if the password is at least 8 characters long
		if (password.Length < 8) return false;

		// Check if the password contains at least one uppercase letter
		if (!password.Any(char.IsUpper)) return false;

		// Check if the password contains at least one lowercase letter
		if (!password.Any(char.IsLower)) return false;

		// Check if the password contains at least one digit
		if (!password.Any(char.IsDigit)) return false;

		return true;
	}
}

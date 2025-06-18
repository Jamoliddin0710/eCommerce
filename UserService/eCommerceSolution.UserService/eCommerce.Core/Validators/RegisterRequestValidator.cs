using eCommerce.Core.DTOs;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
            .Length(1, 50).WithMessage("Person Name should be 1 to 50 characters long");

        RuleFor(x => x.Password).NotEmpty().Length(3, 20).WithMessage("Password is required");

        RuleFor(x => x.Gender).NotEmpty().WithMessage("Gender is required")
            .IsInEnum().WithMessage("Gender is not valid");
    }
}
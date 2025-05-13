using FluentValidation;
using RentalAndSales.Application.Users.DTOs;

namespace RentalAndSales.Application.Users.Validators;

public class UserDtoValidator: AbstractValidator<UserDto>
{
    public UserDtoValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required.")
            .MaximumLength(100).WithMessage("Full name must be at most 100 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is invalid.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?\d{7,20}$").WithMessage("Phone number format is invalid.");

        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters.");
    }
    
}
using FluentValidation;
using RentalAndSales.Application.Cars.DTOs;

namespace RentalAndSales.Application.Cars.Validators;

public class CarDtoValidator: AbstractValidator<CarDto>
{
    public CarDtoValidator()
    {
        RuleFor(x => x.Brand)
            .NotEmpty().WithMessage("Brand is required.")
            .MaximumLength(50).WithMessage("Brand must be at most 50 characters.");

        RuleFor(x => x.Model)
            .NotEmpty().WithMessage("Model is required.")
            .MaximumLength(50).WithMessage("Model must be at most 50 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");
    }
}
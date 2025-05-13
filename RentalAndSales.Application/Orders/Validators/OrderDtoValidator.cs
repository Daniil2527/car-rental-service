using FluentValidation;
using RentalAndSales.Application.Orders.DTOs;

namespace RentalAndSales.Application.Orders.Validators;

public class OrderDtoValidator : AbstractValidator<OrderDto>
{
    public OrderDtoValidator()
    {
        RuleFor(x => x.BuyerId)
            .NotEqual(Guid.Empty).WithMessage("BuyerId is required.");

        RuleFor(x => x.CarId)
            .NotEqual(Guid.Empty).WithMessage("CarId is required.");

        RuleFor(x => x.OrderDate)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Order date cannot be in the future.");

        RuleFor(x => x.Type)
            .IsInEnum().WithMessage("Invalid order type.");

        // Если в будущем ты решишь передавать BuyerName и CarName с клиента — их тоже можно валидировать
    }
}
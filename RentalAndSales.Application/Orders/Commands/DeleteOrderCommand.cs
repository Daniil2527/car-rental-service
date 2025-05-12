using MediatR;

namespace RentalAndSales.Application.Orders.Commands;

public record DeleteOrderCommand(Guid Id):IRequest<bool>;
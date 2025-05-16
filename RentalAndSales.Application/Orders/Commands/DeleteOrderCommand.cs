using MediatR;
using RentalAndSales.Application.Common.Models;

namespace RentalAndSales.Application.Orders.Commands;

public record DeleteOrderCommand(Guid Id) : IRequest<Result<bool>>;
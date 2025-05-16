using MediatR;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Application.Orders.DTOs;

namespace RentalAndSales.Application.Orders.Commands;

public record UpdateOrderCommand(Guid Id, OrderDto Order) : IRequest<Result<bool>>;
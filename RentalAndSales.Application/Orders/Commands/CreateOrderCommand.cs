using MediatR;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Application.Orders.DTOs;

namespace RentalAndSales.Application.Orders.Commands;

public record CreateOrderCommand(OrderDto Order) : IRequest<Result<Guid>>;
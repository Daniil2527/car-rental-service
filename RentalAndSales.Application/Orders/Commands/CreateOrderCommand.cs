using MediatR;
using RentalAndSales.Application.Orders.DTOs;

namespace RentalAndSales.Application.Orders.Commands;

public record CreateOrderCommand(OrderDto Order) : IRequest<Guid>;
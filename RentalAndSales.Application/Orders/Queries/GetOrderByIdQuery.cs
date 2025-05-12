using MediatR;
using RentalAndSales.Application.Orders.DTOs;

namespace RentalAndSales.Application.Orders.Queries;

public record GetOrderByIdQuery(Guid Id):IRequest<OrderDto>;
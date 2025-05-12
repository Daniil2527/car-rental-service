using MediatR;
using RentalAndSales.Application.Orders.DTOs;

namespace RentalAndSales.Application.Orders.Queries;

public record GetAllOrdersQuery():IRequest<List<OrderDto>>;
using AutoMapper;
using MediatR;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Application.Orders.DTOs;
using RentalAndSales.Application.Orders.Queries;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Orders.Handlers;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Result<OrderDto>>
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;

    public GetOrderByIdHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _repository = orderRepository;
        _mapper = mapper;
    }

    public async Task<Result<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.Id, cancellationToken);
        return order is null
            ? Result<OrderDto>.Failure("Заказ не найден")
            : Result<OrderDto>.Success(_mapper.Map<OrderDto>(order));
    }
}
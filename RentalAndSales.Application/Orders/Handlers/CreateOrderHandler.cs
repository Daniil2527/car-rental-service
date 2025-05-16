using AutoMapper;
using MediatR;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Application.Orders.Commands;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Orders.Handlers;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Result<Guid>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public CreateOrderHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Order>(request.Order);
        order.Id = Guid.NewGuid();
        order.OrderDate = DateTime.UtcNow;

        await _orderRepository.AddAsync(order, cancellationToken);
        return Result<Guid>.Success(order.Id);
    }
}
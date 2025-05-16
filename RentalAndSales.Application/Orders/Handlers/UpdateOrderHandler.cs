using AutoMapper;
using MediatR;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Application.Orders.Commands;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Orders.Handlers;

public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, Result<bool>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public UpdateOrderHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<Result<bool>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var existingOrder = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);
        if (existingOrder is null)
            return Result<bool>.Failure("Заказ не найден");

        _mapper.Map(request.Order, existingOrder);
        await _orderRepository.UpdateAsync(existingOrder, cancellationToken);
        return Result<bool>.Success(true);
    }
}
using AutoMapper;
using MediatR;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Application.Orders.Commands;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Orders.Handlers;

public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, Result<bool>>
{
    private readonly IOrderRepository _orderRepository;

    public DeleteOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Result<bool>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var existingOrder = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);
        if (existingOrder is null)
            return Result<bool>.Failure("Заказ не найден");

        await _orderRepository.DeleteAsync(existingOrder, cancellationToken);
        return Result<bool>.Success(true);
    }
}
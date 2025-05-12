using AutoMapper;
using MediatR;
using RentalAndSales.Application.Orders.Commands;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Orders.Handlers;

public class DeleteOrderHandler: IRequestHandler<DeleteOrderCommand, bool>
{
    private readonly IOrderRepository _orderRepository;

    public DeleteOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var existingOrder = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);
        if (existingOrder is null)
            return false;

        await _orderRepository.DeleteAsync(existingOrder, cancellationToken);
        return true;
    }
}
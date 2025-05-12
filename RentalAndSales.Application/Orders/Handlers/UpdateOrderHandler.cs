using AutoMapper;
using MediatR;
using RentalAndSales.Application.Orders.Commands;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Orders.Handlers;

public class UpdateOrderHandler: IRequestHandler<UpdateOrderCommand, bool>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public UpdateOrderHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var existingOrder = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);
        if (existingOrder is null)
            return false;

        _mapper.Map(request.Order, existingOrder);
        await _orderRepository.UpdateAsync(existingOrder, cancellationToken);

        return true;
    }
}
using AutoMapper;
using MediatR;
using RentalAndSales.Application.Orders.DTOs;
using RentalAndSales.Application.Orders.Queries;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Orders.Handlers;

public class GetAllOrdersHandler: IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;

    public GetAllOrdersHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _repository = orderRepository;
        _mapper = mapper;
    }

    public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<OrderDto>>(orders);
    }
    
}

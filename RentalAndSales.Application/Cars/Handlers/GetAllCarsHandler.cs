using AutoMapper;
using MediatR;
using RentalAndSales.Application.Cars.DTOs;
using RentalAndSales.Application.Cars.Queries;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Cars.Handlers;

public class GetAllCarsHandler:IRequestHandler<GetAllCarsQuery, List<CarDto>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetAllCarsHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<List<CarDto>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        var cars = await _carRepository.GetAllAsync(cancellationToken);

        return _mapper.Map<List<CarDto>>(cars);
    }
}
using AutoMapper;
using MediatR;
using RentalAndSales.Application.Cars.DTOs;
using RentalAndSales.Application.Cars.Queries;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Cars.Handlers;

public class GetCarByIdHandler: IRequestHandler<GetCarByIdQuery, CarDto?>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetCarByIdHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<CarDto?> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.Id);
        return car is null ? null : _mapper.Map<CarDto>(car);
    }
}
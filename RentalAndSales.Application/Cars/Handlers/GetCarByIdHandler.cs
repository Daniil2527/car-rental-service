using AutoMapper;
using MediatR;
using RentalAndSales.Application.Cars.DTOs;
using RentalAndSales.Application.Cars.Queries;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Cars.Handlers;

public class GetCarByIdHandler : IRequestHandler<GetCarByIdQuery, Result<CarDto>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetCarByIdHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<Result<CarDto>> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.Id, cancellationToken);
        if (car is null)
            return Result<CarDto>.Failure("Машина не найдена");

        var dto = _mapper.Map<CarDto>(car);
        return Result<CarDto>.Success(dto);
    }
}
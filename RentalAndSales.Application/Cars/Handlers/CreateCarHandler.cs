using AutoMapper;
using MediatR;
using RentalAndSales.Application.Cars.Commands;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Cars.Handlers;

public class CreateCarHandler : IRequestHandler<CreateCarCommand, Result<Guid>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public CreateCarHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var car = _mapper.Map<Car>(request.Car);
        car.Id = Guid.NewGuid();

        await _carRepository.AddAsync(car, cancellationToken);
        return Result<Guid>.Success(car.Id);
    }
}
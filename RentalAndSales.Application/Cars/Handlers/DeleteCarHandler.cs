using AutoMapper;
using MediatR;
using RentalAndSales.Application.Cars.Commands;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Cars.Handlers;

public class DeleteCarHandler : IRequestHandler<DeleteCarCommand, Result<bool>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public DeleteCarHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<Result<bool>> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        var existingCar = await _carRepository.GetByIdAsync(request.Id, cancellationToken);
        if (existingCar is null)
            return Result<bool>.Failure("Машина не найдена");

        await _carRepository.DeleteAsync(existingCar, cancellationToken);
        return Result<bool>.Success(true);
    }
}
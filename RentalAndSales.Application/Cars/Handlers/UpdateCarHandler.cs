using AutoMapper;
using MediatR;
using RentalAndSales.Application.Cars.Commands;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Cars.Handlers;

public class UpdateCarHandler: IRequestHandler<UpdateCarCommand, bool>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public UpdateCarHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var existingCar = await _carRepository.GetByIdAsync(request.Id, cancellationToken);
        if (existingCar is null)
            return false;

        // Обновляем значения из DTO
        _mapper.Map(request.Car, existingCar);

        await _carRepository.UpdateAsync(existingCar, cancellationToken);
        return true;
    }
}
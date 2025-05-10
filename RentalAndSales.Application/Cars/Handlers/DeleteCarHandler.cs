using AutoMapper;
using MediatR;
using RentalAndSales.Application.Cars.Commands;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Cars.Handlers;

public class DeleteCarHandler: IRequestHandler<DeleteCarCommand, bool>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public DeleteCarHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        var existingCar = await _carRepository.GetByIdAsync(request.Id);
        if (existingCar is null)
            return false;

        await _carRepository.DeleteAsync(request.Id);
        return true;
    }
}
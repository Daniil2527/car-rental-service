using MediatR;
using RentalAndSales.Application.Cars.DTOs;

namespace RentalAndSales.Application.Cars.Commands;

public record CreateCarCommand(CarDto Car) : IRequest<Guid>;

    

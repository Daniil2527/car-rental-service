using MediatR;
using RentalAndSales.Application.Cars.DTOs;

namespace RentalAndSales.Application.Cars.Commands;

public record UpdateCarCommand(Guid Id, CarDto Car) : IRequest<bool>;

    

using MediatR;
using RentalAndSales.Application.Cars.DTOs;
using RentalAndSales.Application.Common.Models;

namespace RentalAndSales.Application.Cars.Commands;

public record CreateCarCommand(CarDto Car) : IRequest<Result<Guid>>;

    

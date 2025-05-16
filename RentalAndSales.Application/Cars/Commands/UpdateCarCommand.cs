using MediatR;
using RentalAndSales.Application.Cars.DTOs;
using RentalAndSales.Application.Common.Models;

namespace RentalAndSales.Application.Cars.Commands;

public record UpdateCarCommand(Guid Id, CarDto Car) : IRequest<Result<bool>>;

    

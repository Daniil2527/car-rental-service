using MediatR;
using RentalAndSales.Application.Cars.DTOs;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Cars.Queries;

public record GetCarByIdQuery(Guid Id) : IRequest<Result<CarDto>>;

    

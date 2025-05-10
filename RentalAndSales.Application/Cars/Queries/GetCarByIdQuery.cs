using MediatR;
using RentalAndSales.Application.Cars.DTOs;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Cars.Queries;

public record GetCarByIdQuery(Guid Id) : IRequest<CarDto?>;

    

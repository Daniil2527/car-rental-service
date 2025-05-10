using MediatR;
using RentalAndSales.Application.Cars.DTOs;

namespace RentalAndSales.Application.Cars.Queries;

public record GetAllCarsQuery(): IRequest<List<CarDto>>;
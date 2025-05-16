using MediatR;
using RentalAndSales.Application.Cars.DTOs;
using RentalAndSales.Application.Common.Models;

namespace RentalAndSales.Application.Cars.Queries;

public record GetAllCarsQuery(): IRequest<Result<List<CarDto>>>;
using MediatR;
using RentalAndSales.Application.Common.Models;

namespace RentalAndSales.Application.Cars.Commands;

public record DeleteCarCommand(Guid Id) : IRequest<Result<bool>>;

    

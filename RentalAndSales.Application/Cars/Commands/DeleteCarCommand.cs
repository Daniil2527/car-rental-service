using MediatR;

namespace RentalAndSales.Application.Cars.Commands;

public record DeleteCarCommand(Guid Id) : IRequest<bool>;

    

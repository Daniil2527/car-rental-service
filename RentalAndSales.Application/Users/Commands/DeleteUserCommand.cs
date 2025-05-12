using MediatR;

namespace RentalAndSales.Application.Users.Commands;

public record DeleteUserCommand(Guid Id): IRequest<bool>;
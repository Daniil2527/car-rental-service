using MediatR;
using RentalAndSales.Application.Common.Models;

namespace RentalAndSales.Application.Users.Commands;

public record DeleteUserCommand(Guid Id) : IRequest<Result<bool>>;
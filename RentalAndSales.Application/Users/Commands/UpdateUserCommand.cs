using MediatR;
using RentalAndSales.Application.Users.DTOs;

namespace RentalAndSales.Application.Users.Commands;

public record UpdateUserCommand(Guid Id, UserDto User):IRequest<bool>;
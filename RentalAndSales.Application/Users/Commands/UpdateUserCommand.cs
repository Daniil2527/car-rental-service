using MediatR;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Application.Users.DTOs;

namespace RentalAndSales.Application.Users.Commands;

public record UpdateUserCommand(Guid Id, UserDto User) : IRequest<Result<bool>>;
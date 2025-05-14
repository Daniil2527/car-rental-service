using MediatR;
using RentalAndSales.Application.Users.DTOs;

namespace RentalAndSales.Application.Users.Commands;

public record CreateUserCommand(CreateUserRequest Request):IRequest<Guid>;
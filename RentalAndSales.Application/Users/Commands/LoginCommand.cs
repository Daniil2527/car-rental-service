using MediatR;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Application.Users.DTOs;

namespace RentalAndSales.Application.Users.Commands;

public record LoginCommand(string Email, string Password) : IRequest<Result<UserDto>>;
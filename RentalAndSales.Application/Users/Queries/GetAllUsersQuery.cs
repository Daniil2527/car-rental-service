using MediatR;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Application.Users.DTOs;

namespace RentalAndSales.Application.Users.Queries;

public record GetAllUsersQuery : IRequest<Result<List<UserDto>>>;

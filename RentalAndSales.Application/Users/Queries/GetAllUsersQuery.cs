using MediatR;
using RentalAndSales.Application.Users.DTOs;

namespace RentalAndSales.Application.Users.Queries;

public record  GetAllUsersQuery : IRequest<List<UserDto>>;

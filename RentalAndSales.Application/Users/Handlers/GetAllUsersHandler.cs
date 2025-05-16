using AutoMapper;
using MediatR;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Application.Users.DTOs;
using RentalAndSales.Application.Users.Queries;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Users.Handlers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, Result<List<UserDto>>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUsersHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        var dtoList = _mapper.Map<List<UserDto>>(users);
        return Result<List<UserDto>>.Success(dtoList);
    }
}
using AutoMapper;
using MediatR;
using RentalAndSales.Application.Users.DTOs;
using RentalAndSales.Application.Users.Queries;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Users.Handlers;

public class GetUserByIdHandler: IRequestHandler<GetUserByIdQuery, UserDto?>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        return user is null ? null : _mapper.Map<UserDto>(user);
    }
}
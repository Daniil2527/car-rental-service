using AutoMapper;
using MediatR;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Application.Users.DTOs;
using RentalAndSales.Application.Users.Queries;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Users.Handlers;

public class GetUserByIdHandler: IRequestHandler<GetUserByIdQuery, Result<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user is null)
            return Result<UserDto>.Failure("Пользователь не найден");

        var dto = _mapper.Map<UserDto>(user);
        return Result<UserDto>.Success(dto);
    }
}
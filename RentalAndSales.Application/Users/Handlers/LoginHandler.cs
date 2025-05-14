using AutoMapper;
using MediatR;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Application.Users.Commands;
using RentalAndSales.Application.Users.DTOs;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Users.Handlers;

public class LoginHandler : IRequestHandler<LoginCommand, Result<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public LoginHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Result<UserDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (user is null)
            return Result<UserDto>.Failure("Пользователь не найден");

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
        if (!isPasswordValid)
            return Result<UserDto>.Failure("Неверный пароль");

        var userDto = _mapper.Map<UserDto>(user);
        return Result<UserDto>.Success(userDto);
    }
}
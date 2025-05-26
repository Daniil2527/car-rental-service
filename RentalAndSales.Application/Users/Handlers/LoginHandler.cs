using AutoMapper;
using MediatR;
using RentalAndSales.Application.Common.Interfaces.Auth;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Application.Users.Commands;
using RentalAndSales.Application.Users.DTOs;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Users.Handlers;

public class LoginHandler : IRequestHandler<LoginCommand, Result<AuthResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwt;

    public LoginHandler(IUserRepository userRepository, IMapper mapper, IJwtTokenGenerator jwt)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _jwt = jwt;
    }

    public async Task<Result<AuthResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (user is null)
            return Result<AuthResponse>.Failure("Пользователь не найден");

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
        if (!isPasswordValid)
            return Result<AuthResponse>.Failure("Неверный пароль");

        var userDto = _mapper.Map<UserDto>(user);
        var token = _jwt.GenerateToken(user.Id, user.Email, user.FullName);
        return Result<AuthResponse>.Success(new AuthResponse
        {
            User = userDto,
            Token = token
        });
    }
}
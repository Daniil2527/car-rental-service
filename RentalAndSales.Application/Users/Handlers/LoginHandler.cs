using AutoMapper;
using MediatR;
using RentalAndSales.Application.Users.Commands;
using RentalAndSales.Application.Users.DTOs;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Users.Handlers;

public class LoginHandler: IRequestHandler<LoginCommand, UserDto?>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public LoginHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto?> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if(user == null)
            return null;
        
        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
        if (!isPasswordValid)
            return null;

        return _mapper.Map<UserDto>(user);
    }
}
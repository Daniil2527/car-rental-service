using AutoMapper;
using MediatR;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Application.Users.Commands;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Users.Handlers;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Result<bool>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Result<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (existingUser == null)
        {
            return Result<bool>.Failure("Пользователь не найден");
        }

        _mapper.Map(request.User, existingUser);
        await _userRepository.UpdateAsync(existingUser, cancellationToken);

        return Result<bool>.Success(true);
    }
}
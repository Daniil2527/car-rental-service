using MediatR;
using RentalAndSales.Application.Common.Models;
using RentalAndSales.Application.Users.Commands;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Users.Handlers;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result<bool>>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user is null)
            return Result<bool>.Failure("Пользователь не найден");

        await _userRepository.DeleteAsync(user, cancellationToken);
        return Result<bool>.Success(true);
    }
}
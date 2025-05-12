using AutoMapper;
using MediatR;
using RentalAndSales.Application.Users.Commands;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Users.Handlers;

public class CreateUserHandler:IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        user.Id = Guid.NewGuid();
        await _userRepository.AddAsync(user, cancellationToken);
        return user.Id;
        
    }
}
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RentalAndSales.Application.Common.Extensions;
using RentalAndSales.Application.Users.Commands;
using RentalAndSales.Application.Users.DTOs;
using RentalAndSales.Application.Users.Queries;
using LoginRequest = RentalAndSales.Application.Users.DTOs.LoginRequest;


namespace RentalAndSales.WebApi.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(id), cancellationToken);
    
        return result.ToActionResult();
    }

    [HttpPost]
    [AllowAnonymous] // если доступен без авторизации
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateUserCommand(request), cancellationToken);
        return result.ToActionResult();
    }
    
    [HttpGet]
    [Authorize] 
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllUsersQuery(), cancellationToken);
        return result.ToActionResult();
    }
    
    [Authorize]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UserDto dto, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new UpdateUserCommand(id, dto), cancellationToken);
        return result.ToActionResult();
    }
    
    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteUserCommand(id), cancellationToken);
        return result.ToActionResult();
    }
    
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new LoginCommand(request.Email, request.Password), cancellationToken);
        return result.ToActionResult();
    }
    
}
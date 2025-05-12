using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentalAndSales.Application.Users.Commands;
using RentalAndSales.Application.Users.DTOs;
using RentalAndSales.Application.Users.Queries;

namespace RentalAndSales.WebApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var user = await _mediator.Send(new GetUserByIdQuery(id), cancellationToken);
        if (user is null)
            return NotFound();

        return user;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] UserDto dto, CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand(dto);
        var userId = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = userId }, userId);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAll(CancellationToken cancellationToken)
    {
        var users = await _mediator.Send(new GetAllUsersQuery(), cancellationToken);
        return Ok(users);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UserDto dto, CancellationToken cancellationToken)
    {
        var command = new UpdateUserCommand(id, dto);
        var success = await _mediator.Send(command, cancellationToken);
        return success ? NoContent() : NotFound();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteUserCommand(id), cancellationToken);
        return result ? NoContent() : NotFound();
    }
}
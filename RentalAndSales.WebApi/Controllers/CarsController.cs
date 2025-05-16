using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalAndSales.Application.Cars.Commands;
using RentalAndSales.Application.Cars.DTOs;
using RentalAndSales.Application.Cars.Queries;
using RentalAndSales.Application.Common.Extensions;

namespace RentalAndSales.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CarDto dto, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateCarCommand(dto), cancellationToken);
        return result.ToActionResult();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetCarByIdQuery(id), cancellationToken);
        return result.ToActionResult();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllCarsQuery(), cancellationToken);
        return result.ToActionResult();
    }
    
    [HttpPut("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Update(Guid id, [FromBody] CarDto dto, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new UpdateCarCommand(id, dto), cancellationToken);
        return result.ToActionResult();
    }
    
    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteCarCommand(id), cancellationToken);
        return result.ToActionResult();
    }
}

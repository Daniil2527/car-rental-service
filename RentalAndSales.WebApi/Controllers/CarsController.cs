using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentalAndSales.Application.Cars.Commands;
using RentalAndSales.Application.Cars.DTOs;
using RentalAndSales.Application.Cars.Queries;

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
    public async Task<IActionResult> Create([FromBody] CarDto dto, CancellationToken cancellationToken)
    {
        var command = new CreateCarCommand(dto);
        var carId = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = carId }, new { id = carId });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var car = await _mediator.Send(new GetCarByIdQuery(id), cancellationToken);
        return car is null ? NotFound() : Ok(car);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var cars = await _mediator.Send(new GetAllCarsQuery(), cancellationToken);
        return Ok(cars);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CarDto dto, CancellationToken cancellationToken)
    {
        var command = new UpdateCarCommand(id, dto);
        var success = await _mediator.Send(command, cancellationToken);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteCarCommand(id);
        var success = await _mediator.Send(command, cancellationToken);
        return success ? NoContent() : NotFound();
    }
}

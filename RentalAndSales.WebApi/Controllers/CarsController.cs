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
    public async Task<IActionResult> Create(CarDto dto)
    {
        var command = new CreateCarCommand(dto);
        var carId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = carId }, new { id = carId });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var car = await _mediator.Send(new GetCarByIdQuery(id));
        return car is null ? NotFound() : Ok(car);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var car = await _mediator.Send(new GetAllCarsQuery());
        return Ok(car);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, CarDto dto)
    {
        var command = new UpdateCarCommand(id, dto);
        var success = await _mediator.Send(command);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteCarCommand(id);
        var success = await _mediator.Send(command);
        return success ? NoContent() : NotFound();
    }
}

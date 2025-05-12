using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentalAndSales.Application.Orders.Commands;
using RentalAndSales.Application.Orders.DTOs;
using RentalAndSales.Application.Orders.Queries;

namespace RentalAndSales.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] OrderDto dto, CancellationToken cancellationToken)
    {
        var command = new CreateOrderCommand(dto);
        var orderId = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = orderId }, orderId);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OrderDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var order = await _mediator.Send(new GetOrderByIdQuery(id), cancellationToken);
        if (order is null)
            return NotFound();

        return order;
    }

    [HttpGet]
    public async Task<ActionResult<List<OrderDto>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllOrdersQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] OrderDto dto, CancellationToken cancellationToken)
    {
        var command = new UpdateOrderCommand(id, dto);
        var success = await _mediator.Send(command, cancellationToken);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteOrderCommand(id), cancellationToken);
        return result ? NoContent() : NotFound();
    }
}
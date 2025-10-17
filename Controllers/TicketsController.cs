using Microsoft.AspNetCore.Mvc;
using Examen.Models.DTOS;
using Examen.Services;

namespace Examen.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _tickets;
    public TicketsController(ITicketService tickets) => _tickets = tickets;

    /// POST /api/tickets (valida asiento/capacidad)
    [HttpPost]
    public async Task<ActionResult<TicketDto>> Create([FromBody] CreateTicketDto dto, CancellationToken ct)
    {
        var created = await _tickets.CreateAsync(dto, ct);
        return CreatedAtAction(nameof(GetOne), new { id = created.Id }, created);
    }

    /// GET /api/tickets/{id}
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TicketDto>> GetOne(Guid id, CancellationToken ct)
    {
        var res = await _tickets.GetByIdAsync(id, ct);
        return res is null ? NotFound() : Ok(res);
    }

    /// GET /api/tickets/by-customer/{customerId}
    [HttpGet("by-customer/{customerId:guid}")]
    public async Task<ActionResult<IEnumerable<TicketDto>>> GetByCustomer(Guid customerId, CancellationToken ct)
    {
        var res = await _tickets.GetByCustomerAsync(customerId, ct);
        return Ok(res);
    }
}

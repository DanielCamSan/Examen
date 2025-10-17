using Microsoft.AspNetCore.Mvc;
using Examen.Models.DTOS;
using Examen.Services;
namespace Examen.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customers;
    private readonly ILoyaltyCardService _cards;

    public CustomersController(ICustomerService customers, ILoyaltyCardService cards)
    {
        _customers = customers;
        _cards = cards;
    }

    /// POST /api/customers
    [HttpPost]
    public async Task<ActionResult<CustomerDto>> Create([FromBody] CreateCustomerDto dto, CancellationToken ct)
    {
        var created = await _customers.CreateAsync(dto, ct);
        return CreatedAtAction(nameof(GetOne), new { id = created.Id }, created);
    }

    /// GET /api/customers/{id}
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CustomerDto>> GetOne(Guid id, CancellationToken ct)
    {
        var res = await _customers.GetByIdAsync(id, ct);
        return res is null ? NotFound() : Ok(res);
    }

    /// POST /api/customers/{id}/loyalty-cards 
    [HttpPost("{id:guid}/loyalty-cards")]
    public async Task<ActionResult<LoyaltyCardDto>> CreateLoyaltyCard(Guid id, [FromBody] CreateLoyaltyCardDto dto, CancellationToken ct)
    {
        var created = await _cards.CreateAsync(id, dto, ct);
        return CreatedAtAction(nameof(GetCards), new { id }, created);
    }

    /// GET /api/customers/{id}/loyalty-cards
    [HttpGet("{id:guid}/loyalty-cards")]
    public async Task<ActionResult<IEnumerable<LoyaltyCardDto>>> GetCards(Guid id, CancellationToken ct)
    {
        var res = await _cards.GetByCustomerAsync(id, ct);
        return Ok(res);
    }
}

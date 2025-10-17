using Microsoft.AspNetCore.Mvc;
using Examen.Models.DTOS;
using Examen.Services;
namespace Examen.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScreeningsController : ControllerBase
{
    private readonly IScreeningService _screenings;
    public ScreeningsController(IScreeningService screenings) => _screenings = screenings;

    /// POST /api/screenings  (valida no solapamiento)
    [HttpPost]
    public async Task<ActionResult<ScreeningDto>> Create([FromBody] CreateScreeningDto dto, CancellationToken ct)
    {
        var created = await _screenings.CreateAsync(dto, ct);
        return CreatedAtAction(nameof(GetOne), new { id = created.Id }, created);
    }

    /// GET /api/screenings/{id}
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ScreeningDto>> GetOne(Guid id, CancellationToken ct)
    {
        var res = await _screenings.GetByIdAsync(id, ct);
        return res is null ? NotFound() : Ok(res);
    }

    /// GET /api/screenings/next?from=...&to=...
    [HttpGet("next")]
    public async Task<ActionResult<IEnumerable<ScreeningDto>>> GetNext([FromQuery] DateTime from, [FromQuery] DateTime to, CancellationToken ct)
    {
        var res = await _screenings.GetRangeAsync(from, to, ct);
        return Ok(res);
    }
}

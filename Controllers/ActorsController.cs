using Examen.Models.DTOS;
using Microsoft.AspNetCore.Mvc;
using Examen.Services;


namespace Examen.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActorsController : ControllerBase
{
    private readonly IActorService _actors;
    public ActorsController(IActorService actors) => _actors = actors;

    /// POST /api/actors
    [HttpPost]
    public async Task<ActionResult<ActorDto>> Create([FromBody] CreateActorDto dto, CancellationToken ct)
    {
        var created = await _actors.CreateAsync(dto, ct);
        return CreatedAtAction(nameof(GetOne), new { id = created.Id }, created);
    }

    /// GET /api/actors/{id}
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ActorDto>> GetOne(Guid id, CancellationToken ct)
    {
        var actor = await _actors.GetByIdAsync(id, ct);
        return actor is null ? NotFound() : Ok(actor);
    }
}

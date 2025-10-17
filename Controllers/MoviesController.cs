using Microsoft.AspNetCore.Mvc;
using Examen.Models.DTOS;
using Examen.Services;
namespace Examen.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movies;
    public MoviesController(IMovieService movies) => _movies = movies;

    /// POST /api/movies
    [HttpPost]
    public async Task<ActionResult<MovieDto>> Create([FromBody] CreateMovieDto dto, CancellationToken ct)
    {
        var created = await _movies.CreateAsync(dto, ct);
        return CreatedAtAction(nameof(GetDetails), new { id = created.Id }, created);
    }

    /// GET /api/movies/{id}/details
    [HttpGet("{id:guid}/details")]
    public async Task<ActionResult<MovieDetailsDto>> GetDetails(Guid id, CancellationToken ct)
    {
        var res = await _movies.GetDetailsAsync(id, ct);
        return res is null ? NotFound() : Ok(res);
    }

    /// POST /api/movies/{id}/actors/{actorId}
    [HttpPost("{id:guid}/actors/{actorId:guid}")]
    public async Task<IActionResult> AddActor(Guid id, Guid actorId, CancellationToken ct)
    {
        var ok = await _movies.AddActorAsync(id, actorId, ct);
        return ok ? NoContent() : NotFound();
    }

    /// DELETE /api/movies/{id}/actors/{actorId}
    [HttpDelete("{id:guid}/actors/{actorId:guid}")]
    public async Task<IActionResult> RemoveActor(Guid id, Guid actorId, CancellationToken ct)
    {
        var ok = await _movies.RemoveActorAsync(id, actorId, ct);
        return ok ? NoContent() : NotFound();
    }
}

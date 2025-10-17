using Examen.Models.DTOS;

namespace Examen.Services
{
    public interface IMovieService
    {
        Task<MovieDto> CreateAsync(CreateMovieDto dto, CancellationToken ct);
        Task<MovieDetailsDto?> GetDetailsAsync(Guid id, CancellationToken ct);
        Task<bool> AddActorAsync(Guid movieId, Guid actorId, CancellationToken ct);
        Task<bool> RemoveActorAsync(Guid movieId, Guid actorId, CancellationToken ct);
    }
}

using Examen.Models;

namespace Examen.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<List<Movie>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(Movie entity, CancellationToken ct = default);
        Task UpdateAsync(Movie entity, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);

        // Relaciones N:M
        Task<bool> AddActorAsync(Guid movieId, Guid actorId, CancellationToken ct = default);
        Task<bool> RemoveActorAsync(Guid movieId, Guid actorId, CancellationToken ct = default);

        // Para MovieDetails
        Task<Movie?> GetDetailsAsync(Guid id, CancellationToken ct = default);
    }
}

using Examen.Models;

namespace Examen.Repositories
{
    public interface IActorRepository
    {
        Task<Actor?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<List<Actor>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(Actor entity, CancellationToken ct = default);
        Task UpdateAsync(Actor entity, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);
    }
}

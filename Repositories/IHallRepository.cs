using Examen.Models;

namespace Examen.Repositories
{
    public interface IHallRepository
    {
        Task<Hall?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<List<Hall>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(Hall entity, CancellationToken ct = default);
        Task UpdateAsync(Hall entity, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);
    }
}

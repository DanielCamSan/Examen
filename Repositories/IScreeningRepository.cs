using Examen.Models.DTOS;

namespace Examen.Repositories
{
    public interface IScreeningRepository
    {
        Task<Screening?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<List<Screening>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(Screening entity, CancellationToken ct = default);
        Task UpdateAsync(Screening entity, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);

        // Regla de negocio para conflicto de horarios
        Task<bool> ExistsOverlapAsync(Guid hallId, DateTime startsAt, int durationMin, CancellationToken ct = default);

        // Para filtrar funciones por rango de fechas
        Task<List<Screening>> GetRangeAsync(DateTime from, DateTime to, CancellationToken ct = default);
    }
}

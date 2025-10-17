using Examen.Data;
using Examen.Models.DTOS;
using Microsoft.EntityFrameworkCore;

namespace Examen.Repositories
{

    public class ScreeningRepository : IScreeningRepository
    {
        private readonly AppDbContext _db;
        public ScreeningRepository(AppDbContext db) => _db = db;

        public Task<Screening?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => _db.Screenings
                  .Include(s => s.Movie)
                  .Include(s => s.Hall)
                  .AsNoTracking()
                  .FirstOrDefaultAsync(s => s.Id == id, ct);

        public Task<List<Screening>> GetAllAsync(CancellationToken ct = default)
            => _db.Screenings.AsNoTracking().ToListAsync(ct);

        public async Task AddAsync(Screening entity, CancellationToken ct = default)
        {
            await _db.Screenings.AddAsync(entity, ct);
            await _db.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(Screening entity, CancellationToken ct = default)
        {
            _db.Screenings.Update(entity);
            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await _db.Screenings.FindAsync([id], ct);
            if (entity is null) return;
            _db.Screenings.Remove(entity);
            await _db.SaveChangesAsync(ct);
        }

        public Task<List<Screening>> GetRangeAsync(DateTime from, DateTime to, CancellationToken ct = default)
            => _db.Screenings
                  .Where(s => s.StartsAt >= from && s.StartsAt <= to)
                  .AsNoTracking()
                  .ToListAsync(ct);

        // === TODO evaluable: chequear solapamiento en la misma sala ===
        public async Task<bool> ExistsOverlapAsync(Guid hallId, DateTime startsAt, int durationMin, CancellationToken ct = default)
        {
            // Un screening A [startsAt, end) solapa a B si:
            // A.starts < B.end && A.end > B.starts
            var end = startsAt.AddMinutes(durationMin);

            return await _db.Screenings
                .Include(s => s.Movie)
                .AnyAsync(s =>
                    s.HallId == hallId &&
                    s.StartsAt < end &&
                    s.StartsAt.AddMinutes(s.Movie.DurationMin) > startsAt, ct);
        }
    }
}

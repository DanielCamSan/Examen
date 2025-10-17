using Examen.Data;
using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen.Repositories
{
    public class HallRepository : IHallRepository
    {
        private readonly AppDbContext _db;
        public HallRepository(AppDbContext db) => _db = db;

        public Task<Hall?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => _db.Halls.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id, ct);

        public Task<List<Hall>> GetAllAsync(CancellationToken ct = default)
            => _db.Halls.AsNoTracking().ToListAsync(ct);

        public async Task AddAsync(Hall entity, CancellationToken ct = default)
        {
            await _db.Halls.AddAsync(entity, ct);
            await _db.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(Hall entity, CancellationToken ct = default)
        {
            _db.Halls.Update(entity);
            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await _db.Halls.FindAsync([id], ct);
            if (entity is null) return;
            _db.Halls.Remove(entity);
            await _db.SaveChangesAsync(ct);
        }
    }
}

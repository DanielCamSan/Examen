using Examen.Data;
using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly AppDbContext _db;
        public ActorRepository(AppDbContext db) => _db = db;

        public Task<Actor?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => _db.Actors.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id, ct);

        public Task<List<Actor>> GetAllAsync(CancellationToken ct = default)
            => _db.Actors.AsNoTracking().ToListAsync(ct);

        public async Task AddAsync(Actor entity, CancellationToken ct = default)
        {
            await _db.Actors.AddAsync(entity, ct);
            await _db.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(Actor entity, CancellationToken ct = default)
        {
            _db.Actors.Update(entity);
            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await _db.Actors.FindAsync([id], ct);
            if (entity is null) return;
            _db.Actors.Remove(entity);
            await _db.SaveChangesAsync(ct);
        }
    }
}

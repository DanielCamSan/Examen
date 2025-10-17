using Examen.Data;
using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen.Repositories
{
    public class LoyaltyCardRepository : ILoyaltyCardRepository
    {
        private readonly AppDbContext _db;
        public LoyaltyCardRepository(AppDbContext db) => _db = db;

        public Task<LoyaltyCard?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => _db.LoyaltyCards.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id, ct);

        public Task<List<LoyaltyCard>> GetAllAsync(CancellationToken ct = default)
            => _db.LoyaltyCards.AsNoTracking().ToListAsync(ct);

        public async Task AddAsync(LoyaltyCard entity, CancellationToken ct = default)
        {
            await _db.LoyaltyCards.AddAsync(entity, ct);
            await _db.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(LoyaltyCard entity, CancellationToken ct = default)
        {
            _db.LoyaltyCards.Update(entity);
            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await _db.LoyaltyCards.FindAsync([id], ct);
            if (entity is null) return;
            _db.LoyaltyCards.Remove(entity);
            await _db.SaveChangesAsync(ct);
        }

        // === TODO evaluable: listar tarjetas por cliente ===
        public Task<List<LoyaltyCard>> GetByCustomerAsync(Guid customerId, CancellationToken ct = default)
            => _db.LoyaltyCards
                  .AsNoTracking()
                  .Where(l => l.CustomerId == customerId)
                  .ToListAsync(ct);
    }
}

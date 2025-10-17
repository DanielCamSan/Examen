using Examen.Data;
using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _db;
        public TicketRepository(AppDbContext db) => _db = db;

        public Task<Ticket?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => _db.Tickets.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id, ct);

        public Task<List<Ticket>> GetAllAsync(CancellationToken ct = default)
            => _db.Tickets.AsNoTracking().ToListAsync(ct);

        public async Task AddAsync(Ticket entity, CancellationToken ct = default)
        {
            await _db.Tickets.AddAsync(entity, ct);
            await _db.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(Ticket entity, CancellationToken ct = default)
        {
            _db.Tickets.Update(entity);
            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await _db.Tickets.FindAsync([id], ct);
            if (entity is null) return;
            _db.Tickets.Remove(entity);
            await _db.SaveChangesAsync(ct);
        }

        public Task<List<Ticket>> GetByCustomerAsync(Guid customerId, CancellationToken ct = default)
            => _db.Tickets.AsNoTracking().Where(t => t.CustomerId == customerId).ToListAsync(ct);

        // === TODO evaluable: verificar asiento ocupado ===
        public Task<bool> SeatTakenAsync(Guid screeningId, int seatNumber, CancellationToken ct = default)
            => _db.Tickets
                  .AsNoTracking()
                  .AnyAsync(t => t.ScreeningId == screeningId && t.SeatNumber == seatNumber, ct);
    }
}

using Examen.Data;
using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _db;
        public CustomerRepository(AppDbContext db) => _db = db;

        public Task<Customer?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => _db.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, ct);

        public Task<List<Customer>> GetAllAsync(CancellationToken ct = default)
            => _db.Customers.AsNoTracking().ToListAsync(ct);

        public async Task AddAsync(Customer entity, CancellationToken ct = default)
        {
            await _db.Customers.AddAsync(entity, ct);
            await _db.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(Customer entity, CancellationToken ct = default)
        {
            _db.Customers.Update(entity);
            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await _db.Customers.FindAsync([id], ct);
            if (entity is null) return;
            _db.Customers.Remove(entity);
            await _db.SaveChangesAsync(ct);
        }

        public Task<bool> ExistsByEmailAsync(string email, CancellationToken ct = default)
            => _db.Customers.AsNoTracking().AnyAsync(c => c.Email == email, ct);
    }
}

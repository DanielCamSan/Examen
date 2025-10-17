using Examen.Models;

namespace Examen.Repositories
{
    public interface ILoyaltyCardRepository
    {
        Task<LoyaltyCard?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<List<LoyaltyCard>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(LoyaltyCard entity, CancellationToken ct = default);
        Task UpdateAsync(LoyaltyCard entity, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);

        // Para obtener todas las tarjetas de un customer
        Task<List<LoyaltyCard>> GetByCustomerAsync(Guid customerId, CancellationToken ct = default);
    }
}

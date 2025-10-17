using Examen.Models;

namespace Examen.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<List<Customer>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(Customer entity, CancellationToken ct = default);
        Task UpdateAsync(Customer entity, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);

        // Validación extra
        Task<bool> ExistsByEmailAsync(string email, CancellationToken ct = default);
    }
}

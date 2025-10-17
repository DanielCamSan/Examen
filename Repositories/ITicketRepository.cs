using Examen.Models;

namespace Examen.Repositories
{
    public interface ITicketRepository
    {
        Task<Ticket?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<List<Ticket>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(Ticket entity, CancellationToken ct = default);
        Task UpdateAsync(Ticket entity, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);

        // Validaciones de tickets
        Task<bool> SeatTakenAsync(Guid screeningId, int seatNumber, CancellationToken ct = default);
        Task<List<Ticket>> GetByCustomerAsync(Guid customerId, CancellationToken ct = default);
    }
}

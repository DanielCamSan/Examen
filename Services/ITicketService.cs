using Examen.Models.DTOS;

namespace Examen.Services
{
    public interface ITicketService
    {
        Task<TicketDto> CreateAsync(CreateTicketDto dto, CancellationToken ct);
        Task<TicketDto?> GetByIdAsync(Guid id, CancellationToken ct);
        Task<IEnumerable<TicketDto>> GetByCustomerAsync(Guid customerId, CancellationToken ct);
    }
}

using Examen.Models.DTOS;

namespace Examen.Services
{
    public class TicketService : ITicketService
    {
        public Task<TicketDto> CreateAsync(CreateTicketDto dto, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TicketDto>> GetByCustomerAsync(Guid customerId, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<TicketDto?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}

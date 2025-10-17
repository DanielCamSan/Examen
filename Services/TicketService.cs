using Examen.Models;
using Examen.Models.DTOS;
using Examen.Repositories;

namespace Examen.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _tickets;
        private readonly IScreeningRepository _screenings;
        private readonly ICustomerRepository _customers;
        private readonly IHallRepository _halls;

        public TicketService(ITicketRepository tickets, IScreeningRepository screenings, ICustomerRepository customers, IHallRepository halls)
        {
            _tickets = tickets;
            _screenings = screenings;
            _customers = customers;
            _halls = halls;
        }

        public async Task<TicketDto> CreateAsync(CreateTicketDto dto, CancellationToken ct)
        {
            // Validaciones de existencia
            var screening = await _screenings.GetByIdAsync(dto.ScreeningId, ct) ?? throw new KeyNotFoundException("Screening not found");
            _ = await _customers.GetByIdAsync(dto.CustomerId, ct) ?? throw new KeyNotFoundException("Customer not found");

            // Obtener capacidad de la sala
            // (screening ya viene con Hall incluido en GetByIdAsync del repo; si no, busca hall por id)
            var hall = screening.Hall ?? (await _halls.GetByIdAsync(screening.HallId, ct) ?? throw new KeyNotFoundException("Hall not found"));
            if (dto.SeatNumber < 1 || dto.SeatNumber > hall.Capacity)
                throw new InvalidOperationException("Seat out of range");

            // TODO (EXAMEN): validar asiento ocupado
            // Usa _tickets.SeatTakenAsync(dto.ScreeningId, dto.SeatNumber, ct)
            // Si true -> throw new InvalidOperationException("Seat already taken");
            var taken = await _tickets.SeatTakenAsync(dto.ScreeningId, dto.SeatNumber, ct);
            if (taken) throw new InvalidOperationException("Seat already taken");

            var t = new Ticket
            {
                Id = Guid.NewGuid(),
                ScreeningId = dto.ScreeningId,
                CustomerId = dto.CustomerId,
                SeatNumber = dto.SeatNumber,
                Price = dto.Price
            };
            await _tickets.AddAsync(t, ct);
            return new TicketDto(t.Id, t.ScreeningId, t.CustomerId, t.SeatNumber, t.Price);
        }

        public async Task<TicketDto?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var t = await _tickets.GetByIdAsync(id, ct);
            return t is null ? null : new TicketDto(t.Id, t.ScreeningId, t.CustomerId, t.SeatNumber, t.Price);
        }

        public async Task<IEnumerable<TicketDto>> GetByCustomerAsync(Guid customerId, CancellationToken ct)
        {
            var list = await _tickets.GetByCustomerAsync(customerId, ct);
            return list.Select(t => new TicketDto(t.Id, t.ScreeningId, t.CustomerId, t.SeatNumber, t.Price));
        }
    }

}

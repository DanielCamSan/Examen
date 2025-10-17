namespace Examen.Models.DTOS
{
    public record CreateTicketDto(Guid ScreeningId, Guid CustomerId, int SeatNumber, decimal Price);
    public record TicketDto(Guid Id, Guid ScreeningId, Guid CustomerId, int SeatNumber, decimal Price);

}

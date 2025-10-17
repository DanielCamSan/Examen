namespace Examen.Models.DTOS
{
    public record CreateScreeningDto(Guid MovieId, Guid HallId, DateTime StartsAt);
    public record ScreeningDto(Guid Id, Guid MovieId, Guid HallId, DateTime StartsAt);
}

namespace Examen.Models.DTOS
{
    public record CreateMovieDto(string Title, int DurationMin);
    public record MovieDto(Guid Id, string Title, int DurationMin);
    public record MovieDetailsDto(Guid Id, string Title, int DurationMin, IEnumerable<ActorDto> Actors, IEnumerable<ScreeningDto> Upcoming);

}

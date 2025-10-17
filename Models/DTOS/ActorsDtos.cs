namespace Examen.Models.DTOS
{
    public record CreateActorDto(string FullName);
    public record ActorDto(Guid Id, string FullName);
}

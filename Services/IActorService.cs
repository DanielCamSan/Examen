using Examen.Models.DTOS;
namespace Examen.Services

{
    public interface IActorService
    {
        Task<ActorDto> CreateAsync(CreateActorDto dto, CancellationToken ct);
        Task<ActorDto?> GetByIdAsync(Guid id, CancellationToken ct);
    }
}

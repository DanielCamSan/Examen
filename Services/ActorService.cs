using Examen.Models.DTOS;

namespace Examen.Services
{
    public class ActorService : IActorService
    {
        public Task<ActorDto> CreateAsync(CreateActorDto dto, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ActorDto?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}

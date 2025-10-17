using Examen.Models;
using Examen.Models.DTOS;
using Examen.Repositories;

namespace Examen.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actors;
        public ActorService(IActorRepository actors) => _actors = actors;

        public async Task<ActorDto> CreateAsync(CreateActorDto dto, CancellationToken ct)
        {
            var entity = new Actor { Id = Guid.NewGuid(), FullName = dto.FullName.Trim() };
            await _actors.AddAsync(entity, ct);
            return new ActorDto(entity.Id, entity.FullName);
        }

        public async Task<ActorDto?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var a = await _actors.GetByIdAsync(id, ct);
            return a is null ? null : new ActorDto(a.Id, a.FullName);
        }
    }

}

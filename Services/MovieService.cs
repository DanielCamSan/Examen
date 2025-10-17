using Examen.Models.DTOS;

namespace Examen.Services
{
    public class MovieService : IMovieService
    {
        public Task<bool> AddActorAsync(Guid movieId, Guid actorId, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<MovieDto> CreateAsync(CreateMovieDto dto, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<MovieDetailsDto?> GetDetailsAsync(Guid id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveActorAsync(Guid movieId, Guid actorId, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}

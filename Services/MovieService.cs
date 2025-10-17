using Examen.Models;
using Examen.Models.DTOS;
using Examen.Repositories;

namespace Examen.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movies;
        private readonly IActorRepository _actors;

        public MovieService(IMovieRepository movies, IActorRepository actors)
        {
            _movies = movies;
            _actors = actors;
        }

        public async Task<MovieDto> CreateAsync(CreateMovieDto dto, CancellationToken ct)
        {
            var entity = new Movie { Id = Guid.NewGuid(), Title = dto.Title.Trim(), DurationMin = dto.DurationMin };
            await _movies.AddAsync(entity, ct);
            return new MovieDto(entity.Id, entity.Title, entity.DurationMin);
        }

        public async Task<MovieDetailsDto?> GetDetailsAsync(Guid id, CancellationToken ct)
        {
            var m = await _movies.GetDetailsAsync(id, ct);
            if (m is null) return null;

            var actors = m.MovieActors.Select(ma => new ActorDto(ma.Actor.Id, ma.Actor.FullName));
            var upcoming = m.Screenings
                .OrderBy(s => s.StartsAt)
                .Take(10)
                .Select(s => new ScreeningDto(s.Id, s.MovieId, s.HallId, s.StartsAt));

            return new MovieDetailsDto(m.Id, m.Title, m.DurationMin, actors, upcoming);
        }

        public async Task<bool> AddActorAsync(Guid movieId, Guid actorId, CancellationToken ct)
        {
            // (Puedes dejarlo listo)
            // Validar existencia básica (evita 500s feos)
            if (await _movies.GetByIdAsync(movieId, ct) is null) return false;
            if (await _actors.GetByIdAsync(actorId, ct) is null) return false;
            return await _movies.AddActorAsync(movieId, actorId, ct);
        }

        public Task<bool> RemoveActorAsync(Guid movieId, Guid actorId, CancellationToken ct)
            => _movies.RemoveActorAsync(movieId, actorId, ct);
    }

}

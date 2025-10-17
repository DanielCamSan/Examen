using Examen.Models.DTOS;
using Examen.Repositories;

namespace Examen.Services
{
    public class ScreeningService : IScreeningService
    {
        private readonly IScreeningRepository _screenings;
        private readonly IMovieRepository _movies;
        private readonly IHallRepository _halls;

        public ScreeningService(IScreeningRepository screenings, IMovieRepository movies, IHallRepository halls)
        {
            _screenings = screenings;
            _movies = movies;
            _halls = halls;
        }

        public async Task<ScreeningDto> CreateAsync(CreateScreeningDto dto, CancellationToken ct)
        {
            // Validaciones básicas
            var movie = await _movies.GetByIdAsync(dto.MovieId, ct) ?? throw new KeyNotFoundException("Movie not found");
            _ = await _halls.GetByIdAsync(dto.HallId, ct) ?? throw new KeyNotFoundException("Hall not found");

            // TODO (EXAMEN): NO SOLAPAMIENTO
            // Usa _screenings.ExistsOverlapAsync(dto.HallId, dto.StartsAt, movie.DurationMin, ct)
            // Si true -> throw new InvalidOperationException("Overlapping screening");
            var overlaps = await _screenings.ExistsOverlapAsync(dto.HallId, dto.StartsAt, movie.DurationMin, ct);
            if (overlaps) throw new InvalidOperationException("Overlapping screening");

            var s = new Screening { Id = Guid.NewGuid(), MovieId = dto.MovieId, HallId = dto.HallId, StartsAt = dto.StartsAt };
            await _screenings.AddAsync(s, ct);
            return new ScreeningDto(s.Id, s.MovieId, s.HallId, s.StartsAt);
        }

        public async Task<ScreeningDto?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var s = await _screenings.GetByIdAsync(id, ct);
            return s is null ? null : new ScreeningDto(s.Id, s.MovieId, s.HallId, s.StartsAt);
        }

        public async Task<IEnumerable<ScreeningDto>> GetRangeAsync(DateTime from, DateTime to, CancellationToken ct)
        {
            var list = await _screenings.GetRangeAsync(from, to, ct);
            return list.Select(s => new ScreeningDto(s.Id, s.MovieId, s.HallId, s.StartsAt));
        }
    }

}

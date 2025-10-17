using Examen.Data;
using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _db;
        public MovieRepository(AppDbContext db) => _db = db;

        public Task<Movie?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => _db.Movies.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id, ct);

        public Task<List<Movie>> GetAllAsync(CancellationToken ct = default)
            => _db.Movies.AsNoTracking().ToListAsync(ct);

        public async Task AddAsync(Movie entity, CancellationToken ct = default)
        {
            await _db.Movies.AddAsync(entity, ct);
            await _db.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(Movie entity, CancellationToken ct = default)
        {
            _db.Movies.Update(entity);
            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await _db.Movies.FindAsync([id], ct);
            if (entity is null) return;
            _db.Movies.Remove(entity);
            await _db.SaveChangesAsync(ct);
        }

        public Task<Movie?> GetDetailsAsync(Guid id, CancellationToken ct = default)
            => _db.Movies
                  .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                  .Include(m => m.Screenings)
                  .AsNoTracking()
                  .FirstOrDefaultAsync(m => m.Id == id, ct);

        // === TODOs evaluables: relación N:M ===
        public async Task<bool> AddActorAsync(Guid movieId, Guid actorId, CancellationToken ct = default)
        {
            // TODO: devolver false si ya existe el vínculo; si no, crearlo en MovieActors y guardar.
            var exists = await _db.MovieActors.AnyAsync(x => x.MovieId == movieId && x.ActorId == actorId, ct);
            if (exists) return false;

            _db.MovieActors.Add(new MovieActor { MovieId = movieId, ActorId = actorId });
            await _db.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> RemoveActorAsync(Guid movieId, Guid actorId, CancellationToken ct = default)
        {
            // TODO: devolver false si no existe; si existe, eliminar y guardar.
            var link = await _db.MovieActors.FirstOrDefaultAsync(x => x.MovieId == movieId && x.ActorId == actorId, ct);
            if (link is null) return false;

            _db.MovieActors.Remove(link);
            await _db.SaveChangesAsync(ct);
            return true;
        }
    }
}

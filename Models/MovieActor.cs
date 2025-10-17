namespace Examen.Models
{
    public class MovieActor
    {
        public Guid MovieId { get; set; }
        public Guid ActorId { get; set; }

        public Movie Movie { get; set; } = default!;
        public Actor Actor { get; set; } = default!;
    }
}

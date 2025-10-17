using Examen.Models.DTOS;
using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{

    public class Movie
    {
        public Guid Id { get; set; }
        [Required, StringLength(200)] public string Title { get; set; } = string.Empty;
        [Range(1, 600)] public int DurationMin { get; set; }

        public ICollection<Screening> Screenings { get; set; } = new List<Screening>();
        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    }
}

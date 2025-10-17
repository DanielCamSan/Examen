using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{
    public class Actor
    {
        public Guid Id { get; set; }
        [Required, StringLength(200)] public string FullName { get; set; } = string.Empty;

        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    }

}

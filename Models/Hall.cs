using Examen.Models.DTOS;
using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{
    public class Hall
    {
        public Guid Id { get; set; }
        [Required, StringLength(100)] public string Name { get; set; } = string.Empty;
        [Range(1, 1000)] public int Capacity { get; set; }

        public ICollection<Screening> Screenings { get; set; } = new List<Screening>();
    }

}

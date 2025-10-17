using System.Net.Sockets;

namespace Examen.Models.DTOS
{
    public class Screening
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid HallId { get; set; }
        public DateTime StartsAt { get; set; }

        public Movie Movie { get; set; } = default!;
        public Hall Hall { get; set; } = default!;
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }

}

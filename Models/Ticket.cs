using Examen.Models.DTOS;
using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public Guid ScreeningId { get; set; }
        public Guid CustomerId { get; set; }
        [Range(1, 10000)] public int SeatNumber { get; set; }
        [Range(0.01, 100000)] public decimal Price { get; set; }

        public Screening Screening { get; set; } = default!;
        public Customer Customer { get; set; } = default!;
    }
}

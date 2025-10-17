using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{
    public class LoyaltyCard
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        [Required, StringLength(50)] public string Code { get; set; } = string.Empty;
        [Range(0, int.MaxValue)] public int Points { get; set; } = 0;

        public Customer Customer { get; set; } = default!;
    }

}

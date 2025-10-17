using Examen.Models.DTOS;

namespace Examen.Services
{
    public class LoyaltyCardService : ILoyaltyCardService
    {
        public Task<LoyaltyCardDto> CreateAsync(Guid customerId, CreateLoyaltyCardDto dto, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LoyaltyCardDto>> GetByCustomerAsync(Guid customerId, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}

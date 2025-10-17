using Examen.Models.DTOS;
namespace Examen.Services
{
    public interface ILoyaltyCardService
    {
        Task<LoyaltyCardDto> CreateAsync(Guid customerId, CreateLoyaltyCardDto dto, CancellationToken ct);
        Task<IEnumerable<LoyaltyCardDto>> GetByCustomerAsync(Guid customerId, CancellationToken ct);
    }
}

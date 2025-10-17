using Examen.Models;
using Examen.Models.DTOS;
using Examen.Repositories;

namespace Examen.Services
{
    public class LoyaltyCardService : ILoyaltyCardService
    {
        private readonly ICustomerRepository _customers;
        private readonly ILoyaltyCardRepository _cards;

        public LoyaltyCardService(ICustomerRepository customers, ILoyaltyCardRepository cards)
        {
            _customers = customers;
            _cards = cards;
        }

        public async Task<LoyaltyCardDto> CreateAsync(Guid customerId, CreateLoyaltyCardDto dto, CancellationToken ct)
        {
            _ = await _customers.GetByIdAsync(customerId, ct) ?? throw new KeyNotFoundException("Customer not found");

            var card = new LoyaltyCard
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                Code = dto.Code.Trim(),
                Points = dto.Points
            };
            await _cards.AddAsync(card, ct);
            return new LoyaltyCardDto(card.Id, card.Code, card.Points, card.CustomerId);
        }

        public async Task<IEnumerable<LoyaltyCardDto>> GetByCustomerAsync(Guid customerId, CancellationToken ct)
        {
            var list = await _cards.GetByCustomerAsync(customerId, ct);
            return list.Select(c => new LoyaltyCardDto(c.Id, c.Code, c.Points, c.CustomerId));
        }
    }

}

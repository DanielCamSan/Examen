namespace Examen.Models.DTOS
{
    public record CreateLoyaltyCardDto(string Code, int Points);
    public record LoyaltyCardDto(Guid Id, string Code, int Points, Guid CustomerId);
}

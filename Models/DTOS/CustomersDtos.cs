namespace Examen.Models.DTOS
{
    public record CreateCustomerDto(string Email, string FullName);
    public record CustomerDto(Guid Id, string Email, string FullName, bool Active);
}

using Examen.Models.DTOS;
namespace Examen.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto> CreateAsync(CreateCustomerDto dto, CancellationToken ct);
        Task<CustomerDto?> GetByIdAsync(Guid id, CancellationToken ct);
    }
}

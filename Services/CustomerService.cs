using Examen.Models.DTOS;

namespace Examen.Services
{
    public class CustomerService : ICustomerService
    {
        public Task<CustomerDto> CreateAsync(CreateCustomerDto dto, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDto?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}

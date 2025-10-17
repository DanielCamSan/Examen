using Examen.Models;
using Examen.Models.DTOS;
using Examen.Repositories;

namespace Examen.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customers;

        public CustomerService(ICustomerRepository customers)
        {
            _customers = customers;
        }

        public async Task<CustomerDto> CreateAsync(CreateCustomerDto dto, CancellationToken ct)
        {
            var email = dto.Email.Trim().ToLowerInvariant();

            // BONUS (EXAMEN): email único
            if (await _customers.ExistsByEmailAsync(email, ct))
                throw new InvalidOperationException("Email already registered");

            var c = new Customer { Id = Guid.NewGuid(), Email = email, FullName = dto.FullName.Trim(), Active = true };
            await _customers.AddAsync(c, ct);
            return new CustomerDto(c.Id, c.Email, c.FullName, c.Active);
        }

        public async Task<CustomerDto?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var c = await _customers.GetByIdAsync(id, ct);
            return c is null ? null : new CustomerDto(c.Id, c.Email, c.FullName, c.Active);
        }
    }

}

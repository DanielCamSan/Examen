using Examen.Models.DTOS;

namespace Examen.Services
{
    public class ScreeningService : IScreeningService
    {
        public Task<ScreeningDto> CreateAsync(CreateScreeningDto dto, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ScreeningDto?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ScreeningDto>> GetRangeAsync(DateTime from, DateTime to, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}

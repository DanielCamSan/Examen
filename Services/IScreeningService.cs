using Examen.Models.DTOS;

namespace Examen.Services

{
    public interface IScreeningService
    {
        Task<ScreeningDto> CreateAsync(CreateScreeningDto dto, CancellationToken ct);
        Task<ScreeningDto?> GetByIdAsync(Guid id, CancellationToken ct);
        Task<IEnumerable<ScreeningDto>> GetRangeAsync(DateTime from, DateTime to, CancellationToken ct);
    }
}

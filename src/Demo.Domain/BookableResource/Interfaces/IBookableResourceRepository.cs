using Demo.Domain.BookableResource.DTO;
using Demo.Domain.Shared;

namespace Demo.Domain.BookableResource.Interfaces;

/// <summary>
///     Repository abstraction for Bookable Resources
/// </summary>
public interface IBookableResourceRepository
{
    Task<IEnumerable<BookableResourceDto>> GetAllAsync(CancellationToken ct = default);
    Task<BookableResourceDto> GetResourceByIdAsync(Guid resourceId, CancellationToken ct = default);
    IUnitOfWork UnitOfWork { get; }
    Task AddAsync(BookableResourceDto item, CancellationToken ct = default);
}

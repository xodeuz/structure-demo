using Demo.Domain.BookableResources.Entities;
using Demo.Domain.Shared;

namespace Demo.Domain.BookableResources.Interfaces;

/// <summary>
///     Repository abstraction for Bookable Resources
/// </summary>
public interface IBookableResourceRepository
{
    Task<IEnumerable<BookableResource>> GetAllAsync(CancellationToken ct = default);
    Task<BookableResource> GetResourceByIdAsync(Guid resourceId, CancellationToken ct = default);
    IUnitOfWork UnitOfWork { get; }
    Task AddAsync(BookableResource item, CancellationToken ct = default);
}

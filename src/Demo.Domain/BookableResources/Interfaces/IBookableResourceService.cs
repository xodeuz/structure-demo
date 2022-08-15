using Demo.Domain.BookableResources.DTO;

namespace Demo.Domain.BookableResources.Interfaces;

public interface IBookableResourceService
{
    /// <summary>
    ///     Get all bookable resources 
    /// </summary>
    Task<IEnumerable<BookableResourceDto>> GetAllResourcesAsync(CancellationToken ct = default);
}

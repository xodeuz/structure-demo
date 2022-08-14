using Demo.Domain.BookableResource.DTO;

namespace Demo.Domain.BookableResource.Interfaces;

public interface IBookableResourceService
{
    /// <summary>
    ///     Get all bookable resources 
    /// </summary>
    Task<IEnumerable<BookableResourceDto>> GetAllResourcesAsync(CancellationToken ct = default);
}

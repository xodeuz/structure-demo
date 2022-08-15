using Demo.Domain.BookableResources.DTO;
using Demo.Domain.BookableResources.Extensions;
using Demo.Domain.BookableResources.Interfaces;

namespace Demo.Domain.BookableResources.Services;

internal class BookableResourceService : IBookableResourceService
{
    private readonly IBookableResourceRepository _repository;

    public BookableResourceService(IBookableResourceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BookableResourceDto>> GetAllResourcesAsync(CancellationToken ct = default)
    {
        var entity = await _repository.GetAllAsync(ct);
        return entity.ToDtoCollection();
    }
}

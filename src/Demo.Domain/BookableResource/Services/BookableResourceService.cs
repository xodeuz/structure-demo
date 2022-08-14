using Demo.Domain.BookableResource.DTO;
using Demo.Domain.BookableResource.Interfaces;

namespace Demo.Domain.BookableResource.Services;

internal class BookableResourceService : IBookableResourceService
{
    private readonly IBookableResourceRepository _repository;

    public BookableResourceService(IBookableResourceRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<BookableResourceDto>> GetAllResourcesAsync(CancellationToken ct = default)
    {
        return _repository.GetAllAsync(ct);
    }
}

using Demo.Domain.BookableResource.DTO;
using Demo.Domain.BookableResource.Exceptions;
using Demo.Domain.BookableResource.Interfaces;
using Demo.Domain.Shared;
using Demo.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Persistence.BookableResource;

internal class BookableResourceRepository : IBookableResourceRepository
{
    private readonly BookingDbContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public BookableResourceRepository(BookingDbContext context)
    {
        _context = context;
    }

    public async Task<BookableResourceDto> GetResourceByIdAsync(Guid resourceId, CancellationToken ct = default)
    {
        var entity = await _context.Resources.FindAsync(new object?[] { resourceId }, cancellationToken: ct);

        if (entity is null)
        {
            throw new BookableResourceNotFoundException();
        }

        return entity.ToDto();
    }

    public async Task<IEnumerable<BookableResourceDto>> GetAllAsync(CancellationToken ct = default)
    {
        var entities = await _context.Resources.AsNoTracking().ToListAsync(ct);
        return entities.ToDtoCollection();
    }

    public async Task AddAsync(BookableResourceDto dto, CancellationToken ct = default)
    {
        var entity = dto.ToEntity();
        await _context.Resources.AddAsync(entity, ct);
    }
}

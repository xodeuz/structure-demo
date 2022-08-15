using Demo.Domain.BookableResources.Entities;
using Demo.Domain.BookableResources.Exceptions;
using Demo.Domain.BookableResources.Interfaces;
using Demo.Domain.Shared;
using Demo.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Persistence.BookableResources;

internal class BookableResourceRepository : IBookableResourceRepository
{
    private readonly BookingDbContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public BookableResourceRepository(BookingDbContext context)
    {
        _context = context;
    }

    public async Task<BookableResource> GetResourceByIdAsync(Guid resourceId, CancellationToken ct = default)
    {
        var entity = await _context.Resources.FindAsync(new object?[] { resourceId }, cancellationToken: ct);

        if (entity is null)
        {
            throw new BookableResourceNotFoundException();
        }

        return entity;
    }

    public async Task<IEnumerable<BookableResource>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.Resources.AsNoTracking().ToListAsync(ct);
    }

    public async Task AddAsync(BookableResource entity, CancellationToken ct = default)
    {
        await _context.Resources.AddAsync(entity, ct);
    }
}

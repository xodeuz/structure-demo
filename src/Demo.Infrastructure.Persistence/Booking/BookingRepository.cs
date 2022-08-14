using Demo.Domain.Bookings.DTO;
using Demo.Domain.Bookings.Exceptions;
using Demo.Domain.Bookings.Interfaces;
using Demo.Domain.Shared;
using Demo.Infrastructure.Persistence.Context;
using Demo.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Persistence.Booking;

internal class BookingRepository : IBookingRepository
{
    private readonly BookingDbContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public BookingRepository(BookingDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BookingDto>> GetAllAsync(CancellationToken ct = default)
    {
        var results = await _context.Bookings.AsNoTracking().ToListAsync(ct);
        return results.ToDtoCollection();
    }

    public async Task<BookingDto> GetBookingByIdAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _context.Bookings.FindAsync(new object?[] { id }, cancellationToken: ct);

        if (entity is null)
        {
            throw new BookingNotFoundException();
        }

        return entity.ToDto();
    }

    public async Task AddAsync(BookingDto booking, CancellationToken ct = default)
    {
        var entity = new BookingEntity
        {
            Id = booking.Id
        };

        await _context.Bookings.AddAsync(entity, ct);
    }
}
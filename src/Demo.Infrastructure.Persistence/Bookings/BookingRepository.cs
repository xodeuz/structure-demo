using Demo.Domain.Bookings.Entities;
using Demo.Domain.Bookings.Exceptions;
using Demo.Domain.Bookings.Interfaces;
using Demo.Domain.Shared;
using Demo.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Persistence.Bookings;

internal class BookingRepository : IBookingRepository
{
    private readonly BookingDbContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public BookingRepository(BookingDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Booking>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.Bookings.AsNoTracking().ToListAsync(ct);
    }

    public async Task<Booking> GetBookingByIdAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _context.Bookings.FindAsync(new object?[] { id }, cancellationToken: ct);

        if (entity is null)
        {
            throw new BookingNotFoundException();
        }

        return entity;
    }

    public async Task AddAsync(Booking entity, CancellationToken ct = default)
    {
        await _context.Bookings.AddAsync(entity, ct);
    }

    public async Task<IEnumerable<Booking>> GetBookingsAsync(DateTime date, Guid resourceId, CancellationToken ct = default)
    {
        return await _context.Bookings.Where(booking => booking.Date.ToShortDateString() == date.ToShortDateString() && booking.ResourceId == resourceId).AsNoTracking().ToListAsync(ct);
    }
}
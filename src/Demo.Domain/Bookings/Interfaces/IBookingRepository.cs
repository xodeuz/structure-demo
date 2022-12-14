using Demo.Domain.Bookings.Entities;
using Demo.Domain.Shared;

namespace Demo.Domain.Bookings.Interfaces;

/// <summary>
///     Repository abstraction for Bookings
/// </summary>
public interface IBookingRepository
{
    /// <summary>
    ///     Get all bookings
    /// </summary>
    Task<IEnumerable<Booking>> GetAllAsync(CancellationToken ct = default);

    /// <summary>
    ///     Get booking by unique identifier
    /// </summary>
    /// <param name="id">Unique ID</param>
    /// <param name="ct">CancellationToken</param>
    /// <returns>BookingDto</returns>
    Task<Booking> GetBookingByIdAsync(Guid id, CancellationToken ct = default);

    /// <summary>
    ///     Get bookings by date and resource id
    /// </summary>
    Task<IEnumerable<Booking>> GetBookingsAsync(DateTime date, Guid resourceId, CancellationToken ct = default);

    /// <summary>
    ///     Add new booking entity
    /// </summary>
    /// <remarks>
    ///     Repositories dont apply any changes until the unit of work has been commited.
    /// </remarks>
    Task AddAsync(Booking booking, CancellationToken ct = default);

    /// <summary>
    ///     Current unit of work
    /// </summary>
    IUnitOfWork UnitOfWork { get; }
}

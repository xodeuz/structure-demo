using Demo.Domain.Bookings.DTO;
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
    Task<IEnumerable<BookingDto>> GetAllAsync(CancellationToken ct = default);

    /// <summary>
    ///     Get booking by unique identifier
    /// </summary>
    /// <param name="id">Unique ID</param>
    /// <param name="ct">CancellationToken</param>
    /// <returns>BookingDto</returns>
    Task<BookingDto> GetBookingByIdAsync(Guid id, CancellationToken ct = default);

    /// <summary>
    ///     Add new booking entity
    /// </summary>
    /// <remarks>
    ///     Repositories dont apply any changes until the unit of work has been commited.
    /// </remarks>
    Task AddAsync(BookingDto booking, CancellationToken ct = default);

    /// <summary>
    ///     Current unit of work
    /// </summary>
    IUnitOfWork UnitOfWork { get; }
}

using Demo.Domain.Bookings.DTO;

namespace Demo.Domain.Bookings.Interfaces;

public interface IBookingService
{
    /// <summary>
    ///     Get booking by unique identifier
    /// </summary>
    /// <param name="id">Unique ID</param>
    /// <param name="ct">CancellationToken</param>
    /// <returns>BookingDto</returns>
    Task<BookingDto> GetBookingByIdAsync(Guid id, CancellationToken ct);

    /// <summary>
    ///     Get all bookings
    /// </summary>
    Task<IEnumerable<BookingDto>> GetAllBookingsAsync(CancellationToken ct);

    /// <summary>
    ///     Create new booking
    /// </summary>
    /// <param name="command">Data transfer object</param>
    /// <param name="ct"></param>
    /// <returns>Guid</returns>
    Task<Guid> CreateAsync(CreateBookingDto command, CancellationToken ct);
}

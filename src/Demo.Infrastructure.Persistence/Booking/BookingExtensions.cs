using Demo.Domain.Bookings.DTO;
using Demo.Infrastructure.Persistence.Entities;

namespace Demo.Infrastructure.Persistence.Booking;

/// <summary>
///     Mapping Extensions between internal entity and data transfer objects
/// </summary>
internal static class BookingExtensions
{
    public static BookingDto ToDto(this BookingEntity entity) => new()
    {
        Id = entity.Id
    };

    public static IEnumerable<BookingDto> ToDtoCollection(this IEnumerable<BookingEntity> entities)
        => entities.Select(entity => entity.ToDto()).ToList();
}

using Demo.Domain.Bookings.DTO;
using Demo.Domain.Bookings.Entities;

namespace Demo.Domain.Bookings.Extensions;

internal static class BookableResourceExtensions
{
    public static BookingDto ToDto(this Booking entity)
        => new(entity.Id, entity.UserId, entity.ResourceId, entity.Date);

    public static IEnumerable<BookingDto> ToDtoCollection(this IEnumerable<Booking> models)
        => models.Select(model => model.ToDto()).ToList();
}

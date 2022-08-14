using Demo.Domain.Bookings.DTO;

namespace Demo.Domain.Bookings.Extensions;

internal static class BookingExtensions
{
    public static BookingDto ToDto(this Entities.Booking model)
        => new()
        {
            Id = model.Id
        };
}

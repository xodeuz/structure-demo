using Demo.Domain.Bookings.DTO;

namespace Demo.Domain.Bookings.Extensions;

internal static class BookableResourceExtensions
{
    public static BookingDto ToDto(this Entities.Booking model)
        => new()
        {
            Id = model.Id
        };
}

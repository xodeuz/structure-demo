namespace Demo.Domain.Bookings.DTO
{
    public record BookingDto(
            Guid Id,
            Guid UserId,
            Guid ResourceId,
            DateTime Date
        );
}

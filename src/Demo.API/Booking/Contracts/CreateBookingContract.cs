namespace Demo.API.Booking.Contracts
{
    public record CreateBookingContract
        (Guid UserId,
        Guid ResourceId);
}

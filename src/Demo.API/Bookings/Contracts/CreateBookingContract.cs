namespace Demo.API.Bookings.Contracts
{
    public record CreateBookingContract
        (Guid UserId,
        Guid ResourceId,
        DateTime Date);
}

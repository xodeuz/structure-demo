namespace Demo.Domain.Bookings.DTO
{
    public class CreateBookingDto
    {
        public Guid UserId { get; init; }
        public Guid ResourceId { get; init; }
        public DateTime Date { get; init; }
    }
}

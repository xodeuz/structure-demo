namespace Demo.API.Booking.Contracts
{
    /// <summary>
    ///     Contract used to expose the data from the API.
    /// </summary>
    /// <param name="Id">Unique ID</param>
    public record BookingContract
        (Guid Id);
}

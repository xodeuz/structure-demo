namespace Demo.API.Bookings.Contracts
{
    /// <summary>
    ///     Contract used to expose the data from the API.
    /// </summary>
    /// <param name="Id">Unique ID</param>
    /// <param name="Date">Date resource is booked</param>
    /// <param name="ResourceId">Resource</param>
    /// <param name="UserId">User</param>
    public record BookingContract(
         Guid Id,
         Guid UserId,
         Guid ResourceId,
         DateTime Date
     );
}

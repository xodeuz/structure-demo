namespace Demo.API.BookableResources.Contracts
{
    /// <summary>
    ///     Bookable Resource contract
    /// </summary>
    /// <param name="Id">Unique Id</param>
    /// <param name="Name">Name of the resource</param>
    /// <param name="IsClosed">Is the resource open or closed</param>
    public record BookableResourceContract(Guid Id, string? Name, bool IsClosed);
}

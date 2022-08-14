namespace Demo.Domain.BookableResource.DTO
{
    /// <summary>
    ///     Data transfer object
    /// </summary>
    public class BookableResourceDto
    {
        public Guid Id { get; init; }

        public string? Name { get; init; }

        public bool IsClosed { get; init; }
    }
}

namespace Demo.Domain.BookableResources.DTO
{
    /// <summary>
    ///     Data transfer object
    /// </summary>
    public record BookableResourceDto
    {
        public Guid Id { get; init; }

        public string? Name { get; init; }

        public bool IsClosed { get; init; }
    }
}

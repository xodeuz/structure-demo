namespace Demo.Domain.BookableResources.Entities;

public class BookableResource
{
    public Guid Id { get; init; }
    public bool IsClosed { get; init; }
    public string Name { get; init; }
}

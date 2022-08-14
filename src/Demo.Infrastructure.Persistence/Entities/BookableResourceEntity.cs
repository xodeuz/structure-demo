namespace Demo.Infrastructure.Persistence.Entities
{
    internal class BookableResourceEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool IsClosed { get; set; }
    }
}

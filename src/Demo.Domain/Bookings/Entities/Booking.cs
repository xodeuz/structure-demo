using Demo.Domain.BookableResource.DTO;

namespace Demo.Domain.Bookings.Entities
{
    internal sealed class Booking
    {
        public Booking(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; init; }

        public Guid UserId { get; private set; }

        public Guid ResourceId { get; private set; }

        public static Booking New() => new(Guid.NewGuid());

        internal void SetBookedBy(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            UserId = userId;
        }

        internal void SetResource(BookableResourceDto resource)
        {
            ArgumentNullException.ThrowIfNull(resource, nameof(resource));

            if (resource.IsClosed)
            {
                throw new InvalidOperationException("Resource is closed for bookings");
            }

            ResourceId = resource.Id;
        }
    }
}

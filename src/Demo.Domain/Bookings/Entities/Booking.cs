using Demo.Domain.BookableResources.Entities;
using Demo.Domain.Bookings.Exceptions;

namespace Demo.Domain.Bookings.Entities
{
    public sealed class Booking
    {
        public Booking(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; init; }

        public Guid UserId { get; private set; }

        public Guid ResourceId { get; private set; }

        public DateTime Date { get; private set; }

        public static Booking New() => new(Guid.NewGuid());

        internal void SetBookedBy(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            UserId = userId;
        }

        internal void SetResource(BookableResource resource)
        {
            ArgumentNullException.ThrowIfNull(resource, nameof(resource));

            if (resource.IsClosed)
            {
                throw new BusinessRuleViolationException("Resource is closed for bookings");
            }

            ResourceId = resource.Id;
        }

        internal void SetDate(DateTime date)
        {
            if (date < DateTime.Today)
            {
                throw new BusinessRuleViolationException("Can not set a date before current date");
            }

            Date = date;
        }
    }
}

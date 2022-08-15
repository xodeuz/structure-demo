using Demo.Domain.BookableResources.Entities;
using Demo.Domain.Bookings.Entities;
using Demo.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Persistence.Context;

internal class BookingDbContext : DbContext, IUnitOfWork
{
    public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
    { }

    public DbSet<Booking> Bookings { get; set; }
    public DbSet<BookableResource> Resources { get; set; }
}

using Demo.Domain.Shared;
using Demo.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Persistence.Context;

internal class BookingDbContext : DbContext, IUnitOfWork
{
    public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
    { }

    public DbSet<BookingEntity> Bookings { get; set; }
    public DbSet<BookableResourceEntity> Resources { get; set; }
}

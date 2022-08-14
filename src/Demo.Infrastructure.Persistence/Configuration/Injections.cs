using Demo.Domain.BookableResource.Interfaces;
using Demo.Domain.Bookings.Interfaces;
using Demo.Infrastructure.Persistence.BookableResource;
using Demo.Infrastructure.Persistence.Booking;
using Demo.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infrastructure.Persistence.Configuration;

public static class Injections
{
    /// <summary>
    ///     Add persistence layer services and infrastructure components to ServiceCollection
    /// </summary>
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services)
    {
        services.AddDbContext<BookingDbContext>(x => x.UseInMemoryDatabase("InMemoryDb"));
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IBookableResourceRepository, BookableResourceRepository>();
        return services;
    }
}

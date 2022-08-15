using Demo.Domain.BookableResources.Interfaces;
using Demo.Domain.BookableResources.Services;
using Demo.Domain.Bookings.Interfaces;
using Demo.Domain.Bookings.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Domain.Configuration;

public static class Injections
{
    /// <summary>
    ///     Add domain layer services
    /// </summary>
    public static IServiceCollection AddDomainLayer(this IServiceCollection services)
    {
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IBookableResourceService, BookableResourceService>();
        return services;
    }
}

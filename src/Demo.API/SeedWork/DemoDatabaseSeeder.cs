using Bogus;
using Demo.Domain.BookableResource.DTO;
using Demo.Domain.BookableResource.Interfaces;

namespace Demo.API.SeedWork;

/// <summary>
///     Ingore this, just here to add some stuff to db for demo purposes
/// </summary>
internal static class DemoDatabaseSeeder
{
    public static async Task SeedForDemo(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
        var repository = scope.ServiceProvider.GetRequiredService<IBookableResourceRepository>();

        var logger = loggerFactory.CreateLogger(nameof(DemoDatabaseSeeder));
        logger.LogInformation("Starting to seed database");

        var faker = new Faker<BookableResourceDto>(locale: "sv")
            .UseSeed(1337)
            .RuleFor(prop => prop.Name, f => f.Address.StreetAddress())
            .RuleFor(prop => prop.IsClosed, f => f.Random.Bool())
            .RuleFor(prop => prop.Id, f => f.Random.Guid());

        var bookableResources = faker.GenerateBetween(15, 15);

        foreach (var item in bookableResources)
        {
            await repository.AddAsync(item);
        }

        await repository.UnitOfWork.SaveChangesAsync();

        logger.LogInformation("Demo database seed completed");
    }
}

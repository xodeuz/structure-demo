using Demo.Domain.BookableResources.DTO;
using Demo.Domain.BookableResources.Entities;

namespace Demo.Domain.BookableResources.Extensions;

internal static class BookableResourceExtensions
{
    public static IEnumerable<BookableResourceDto> ToDtoCollection(this IEnumerable<BookableResource> models)
        => models.Select(model => model.ToDto()).ToList();

    public static BookableResourceDto ToDto(this Entities.BookableResource model)
        => new()
        {
            Id = model.Id,
            Name = model.Name,
            IsClosed = model.IsClosed
        };
}

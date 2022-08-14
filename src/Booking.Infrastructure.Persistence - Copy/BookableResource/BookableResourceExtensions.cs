using Demo.Domain.BookableResource.DTO;
using Demo.Infrastructure.Persistence.Entities;

namespace Demo.Infrastructure.Persistence.BookableResource;

internal static class BookableResourceExtensions
{
    public static IEnumerable<BookableResourceDto> ToDtoCollection(this IEnumerable<BookableResourceEntity> collection)
        => collection.Select(item => item.ToDto()).ToList();

    public static BookableResourceDto ToDto(this BookableResourceEntity entity)
        => new()
        {
            Id = entity.Id,
            IsClosed = entity.IsClosed,
            Name = entity.Name
        };

    public static BookableResourceEntity ToEntity(this BookableResourceDto dto)
        => new()
        {
            Id = dto.Id,
            IsClosed = dto.IsClosed,
            Name = dto.Name
        };
}

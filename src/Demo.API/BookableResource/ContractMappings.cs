using Demo.API.BookableResource.Contracts;
using Demo.Domain.BookableResource.DTO;

namespace Demo.API.BookableResource;

/// <summary>
///     Mapping between application contract to internal data transfer objects
/// </summary>
internal static class ContractMappings
{
    public static IEnumerable<BookableResourceContract> ToContractCollection(this IEnumerable<BookableResourceDto> dtoCollection)
        => dtoCollection.Select(dto => dto.ToContract()).ToList();

    public static BookableResourceContract ToContract(this BookableResourceDto dto)
        => new(dto.Id, dto.Name, dto.IsClosed);
}

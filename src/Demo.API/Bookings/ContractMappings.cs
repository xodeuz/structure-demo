using Demo.API.Bookings.Contracts;
using Demo.Domain.Bookings.DTO;

namespace Demo.API.Bookings
{
    /// <summary>
    ///     Mapping between application contract to internal data transfer objects
    /// </summary>
    internal static class ContractMappings
    {
        public static IEnumerable<BookingContract> ToContractCollection(this IEnumerable<BookingDto> dtoCollection)
            => dtoCollection.Select(dto => dto.ToContract()).ToList();

        public static BookingContract ToContract(this BookingDto dto)
            => new(dto.Id);

        public static CreateBookingDto ToDto(this CreateBookingContract contract)
            => new()
            {
                UserId = contract.UserId,
                ResourceId = contract.ResourceId
            };
    }
}

using Demo.Domain.BookableResource.Interfaces;
using Demo.Domain.Bookings.DTO;
using Demo.Domain.Bookings.Entities;
using Demo.Domain.Bookings.Extensions;
using Demo.Domain.Bookings.Interfaces;

namespace Demo.Domain.Bookings.Services;

/// <summary>
///     Concrete implementation of IBookingService (domain service)
/// </summary>
internal class BookingService : IBookingService
{
    private readonly IBookingRepository _repository;
    private readonly IBookableResourceRepository _resourceRepository;

    public BookingService(
        IBookingRepository repository,
        IBookableResourceRepository resourceRepository)
    {
        _repository = repository;
        _resourceRepository = resourceRepository;
    }

    /// <inheritdoc/>
    public async Task<Guid> CreateAsync(CreateBookingDto command, CancellationToken ct)
    {
        // Retrieve additional data
        var resource = await _resourceRepository.GetResourceByIdAsync(command.ResourceId, ct);

        // Create a new booking using domain model
        var booking = Booking.New();
        booking.SetBookedBy(command.UserId);
        booking.SetResource(resource);

        // Convert model to data transfer object
        var dto = booking.ToDto();
        await _repository.AddAsync(dto, ct);
        await _repository.UnitOfWork.SaveChangesAsync(ct);
        return booking.Id;
    }

    /// <inheritdoc/>
    public Task<IEnumerable<BookingDto>> GetAllBookingsAsync(CancellationToken ct)
    {
        return _repository.GetAllAsync(ct);
    }

    /// <inheritdoc/>
    public Task<BookingDto> GetBookingByIdAsync(Guid id, CancellationToken ct)
    {
        return _repository.GetBookingByIdAsync(id, ct);
    }
}
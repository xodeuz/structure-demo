using Demo.Domain.BookableResources.Interfaces;
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
        await _repository.AddAsync(booking, ct);
        await _repository.UnitOfWork.SaveChangesAsync(ct);
        return booking.Id;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<BookingDto>> GetAllBookingsAsync(CancellationToken ct)
    {
        var entities = await _repository.GetAllAsync(ct);
        return entities.Select(x => x.ToDto());
    }

    /// <inheritdoc/>
    public async Task<BookingDto> GetBookingByIdAsync(Guid id, CancellationToken ct)
    {
        var entity = await _repository.GetBookingByIdAsync(id, ct);
        return entity.ToDto();
    }
}
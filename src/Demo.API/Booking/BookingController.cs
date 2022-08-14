using Demo.API.Booking.Contracts;
using Demo.Domain.Bookings.Exceptions;
using Demo.Domain.Bookings.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Booking;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingService _domainService;
    private readonly ILogger<BookingController> _logger;

    public BookingController(IBookingService domainService, ILogger<BookingController> logger)
    {
        _domainService = domainService;
        _logger = logger;
    }

    /// <summary>
    ///     Get all bookings.
    ///     GET v1/Booking
    /// </summary>
    [HttpGet(Name = "GetAllBookings")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookingContract>))]
    public async Task<ActionResult<IEnumerable<BookingContract>>> GetAllBookings(CancellationToken ct)
    {
        var bookings = await _domainService.GetAllBookingsAsync(ct);

        var response = bookings.ToContractCollection();

        return Ok(response);
    }

    /// <summary>
    ///     Get all bookings.
    ///     GET v1/Booking
    /// </summary>
    [HttpGet("{id}", Name = "GetBooking")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookingContract))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookingContract>> GetBooking(Guid id, CancellationToken ct)
    {
        try
        {
            var booking = await _domainService.GetBookingByIdAsync(id, ct);
            var response = booking.ToContract();
            return Ok(response);
        }
        catch (BookingNotFoundException)
        {
            _logger.LogInformation("No booking found with {Id}", id);
            return NotFound();
        }
    }


    /// <summary>
    ///     Get all bookings.
    ///     GET v1/Booking
    /// </summary>
    [HttpPost(Name = "CreateBooking")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IEnumerable<BookingContract>))]
    public async Task<ActionResult> CreateBooking(CreateBookingContract contract, CancellationToken ct)
    {
        var command = contract.ToDto();

        var id = await _domainService.CreateAsync(command, ct);

        return Created(Url.RouteUrl(id)!, id);
    }
}

using Demo.API.BookableResource.Contracts;
using Demo.Domain.BookableResource.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.BookableResource;

[Route("api/[controller]")]
[ApiController]
public class BookableResourceController : ControllerBase
{
    private readonly IBookableResourceService _domainService;
    private readonly ILogger<BookableResourceController> _logger;

    public BookableResourceController(IBookableResourceService domainService, ILogger<BookableResourceController> logger)
    {
        _domainService = domainService;
        _logger = logger;
    }

    /// <summary>
    ///     Get all bookable resources.
    ///     GET v1/BookableResouce
    /// </summary>
    [HttpGet(Name = "GetAllBookableResources")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookableResourceContract>))]
    public async Task<ActionResult<IEnumerable<BookableResourceContract>>> GetAllResources(CancellationToken ct)
    {
        var bookings = await _domainService.GetAllResourcesAsync(ct);

        var response = bookings.ToContractCollection();

        return Ok(response);
    }
}

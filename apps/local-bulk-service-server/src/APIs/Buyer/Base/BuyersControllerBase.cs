using LocalBulkService.APIs;
using LocalBulkService.APIs.Common;
using LocalBulkService.APIs.Dtos;
using LocalBulkService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace LocalBulkService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class BuyersControllerBase : ControllerBase
{
    protected readonly IBuyersService _service;

    public BuyersControllerBase(IBuyersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Buyer
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Buyer>> CreateBuyer(BuyerCreateInput input)
    {
        var buyer = await _service.CreateBuyer(input);

        return CreatedAtAction(nameof(Buyer), new { id = buyer.Id }, buyer);
    }

    /// <summary>
    /// Delete one Buyer
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteBuyer([FromRoute()] BuyerWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteBuyer(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Buyers
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Buyer>>> Buyers([FromQuery()] BuyerFindManyArgs filter)
    {
        return Ok(await _service.Buyers(filter));
    }

    /// <summary>
    /// Meta data about Buyer records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> BuyersMeta([FromQuery()] BuyerFindManyArgs filter)
    {
        return Ok(await _service.BuyersMeta(filter));
    }

    /// <summary>
    /// Get one Buyer
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Buyer>> Buyer([FromRoute()] BuyerWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Buyer(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Buyer
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateBuyer(
        [FromRoute()] BuyerWhereUniqueInput uniqueId,
        [FromQuery()] BuyerUpdateInput buyerUpdateDto
    )
    {
        try
        {
            await _service.UpdateBuyer(uniqueId, buyerUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

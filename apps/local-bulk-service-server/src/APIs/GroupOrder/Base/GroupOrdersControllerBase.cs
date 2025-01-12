using LocalBulkService.APIs;
using LocalBulkService.APIs.Common;
using LocalBulkService.APIs.Dtos;
using LocalBulkService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace LocalBulkService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class GroupOrdersControllerBase : ControllerBase
{
    protected readonly IGroupOrdersService _service;

    public GroupOrdersControllerBase(IGroupOrdersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one GroupOrder
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<GroupOrder>> CreateGroupOrder(GroupOrderCreateInput input)
    {
        var groupOrder = await _service.CreateGroupOrder(input);

        return CreatedAtAction(nameof(GroupOrder), new { id = groupOrder.Id }, groupOrder);
    }

    /// <summary>
    /// Delete one GroupOrder
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteGroupOrder(
        [FromRoute()] GroupOrderWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteGroupOrder(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many GroupOrders
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<GroupOrder>>> GroupOrders(
        [FromQuery()] GroupOrderFindManyArgs filter
    )
    {
        return Ok(await _service.GroupOrders(filter));
    }

    /// <summary>
    /// Meta data about GroupOrder records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> GroupOrdersMeta(
        [FromQuery()] GroupOrderFindManyArgs filter
    )
    {
        return Ok(await _service.GroupOrdersMeta(filter));
    }

    /// <summary>
    /// Get one GroupOrder
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<GroupOrder>> GroupOrder(
        [FromRoute()] GroupOrderWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.GroupOrder(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one GroupOrder
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateGroupOrder(
        [FromRoute()] GroupOrderWhereUniqueInput uniqueId,
        [FromQuery()] GroupOrderUpdateInput groupOrderUpdateDto
    )
    {
        try
        {
            await _service.UpdateGroupOrder(uniqueId, groupOrderUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

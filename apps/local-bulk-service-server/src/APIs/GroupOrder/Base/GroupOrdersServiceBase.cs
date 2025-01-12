using LocalBulkService.APIs;
using LocalBulkService.APIs.Common;
using LocalBulkService.APIs.Dtos;
using LocalBulkService.APIs.Errors;
using LocalBulkService.APIs.Extensions;
using LocalBulkService.Infrastructure;
using LocalBulkService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalBulkService.APIs;

public abstract class GroupOrdersServiceBase : IGroupOrdersService
{
    protected readonly LocalBulkServiceDbContext _context;

    public GroupOrdersServiceBase(LocalBulkServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one GroupOrder
    /// </summary>
    public async Task<GroupOrder> CreateGroupOrder(GroupOrderCreateInput createDto)
    {
        var groupOrder = new GroupOrderDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            groupOrder.Id = createDto.Id;
        }

        _context.GroupOrders.Add(groupOrder);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<GroupOrderDbModel>(groupOrder.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one GroupOrder
    /// </summary>
    public async Task DeleteGroupOrder(GroupOrderWhereUniqueInput uniqueId)
    {
        var groupOrder = await _context.GroupOrders.FindAsync(uniqueId.Id);
        if (groupOrder == null)
        {
            throw new NotFoundException();
        }

        _context.GroupOrders.Remove(groupOrder);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many GroupOrders
    /// </summary>
    public async Task<List<GroupOrder>> GroupOrders(GroupOrderFindManyArgs findManyArgs)
    {
        var groupOrders = await _context
            .GroupOrders.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return groupOrders.ConvertAll(groupOrder => groupOrder.ToDto());
    }

    /// <summary>
    /// Meta data about GroupOrder records
    /// </summary>
    public async Task<MetadataDto> GroupOrdersMeta(GroupOrderFindManyArgs findManyArgs)
    {
        var count = await _context.GroupOrders.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one GroupOrder
    /// </summary>
    public async Task<GroupOrder> GroupOrder(GroupOrderWhereUniqueInput uniqueId)
    {
        var groupOrders = await this.GroupOrders(
            new GroupOrderFindManyArgs { Where = new GroupOrderWhereInput { Id = uniqueId.Id } }
        );
        var groupOrder = groupOrders.FirstOrDefault();
        if (groupOrder == null)
        {
            throw new NotFoundException();
        }

        return groupOrder;
    }

    /// <summary>
    /// Update one GroupOrder
    /// </summary>
    public async Task UpdateGroupOrder(
        GroupOrderWhereUniqueInput uniqueId,
        GroupOrderUpdateInput updateDto
    )
    {
        var groupOrder = updateDto.ToModel(uniqueId);

        _context.Entry(groupOrder).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.GroupOrders.Any(e => e.Id == groupOrder.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}

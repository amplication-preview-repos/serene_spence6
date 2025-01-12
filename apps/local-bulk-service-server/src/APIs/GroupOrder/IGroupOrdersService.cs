using LocalBulkService.APIs.Common;
using LocalBulkService.APIs.Dtos;

namespace LocalBulkService.APIs;

public interface IGroupOrdersService
{
    /// <summary>
    /// Create one GroupOrder
    /// </summary>
    public Task<GroupOrder> CreateGroupOrder(GroupOrderCreateInput grouporder);

    /// <summary>
    /// Delete one GroupOrder
    /// </summary>
    public Task DeleteGroupOrder(GroupOrderWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many GroupOrders
    /// </summary>
    public Task<List<GroupOrder>> GroupOrders(GroupOrderFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about GroupOrder records
    /// </summary>
    public Task<MetadataDto> GroupOrdersMeta(GroupOrderFindManyArgs findManyArgs);

    /// <summary>
    /// Get one GroupOrder
    /// </summary>
    public Task<GroupOrder> GroupOrder(GroupOrderWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one GroupOrder
    /// </summary>
    public Task UpdateGroupOrder(
        GroupOrderWhereUniqueInput uniqueId,
        GroupOrderUpdateInput updateDto
    );
}

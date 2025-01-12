using LocalBulkService.APIs.Common;
using LocalBulkService.APIs.Dtos;

namespace LocalBulkService.APIs;

public interface IBuyersService
{
    /// <summary>
    /// Create one Buyer
    /// </summary>
    public Task<Buyer> CreateBuyer(BuyerCreateInput buyer);

    /// <summary>
    /// Delete one Buyer
    /// </summary>
    public Task DeleteBuyer(BuyerWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Buyers
    /// </summary>
    public Task<List<Buyer>> Buyers(BuyerFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Buyer records
    /// </summary>
    public Task<MetadataDto> BuyersMeta(BuyerFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Buyer
    /// </summary>
    public Task<Buyer> Buyer(BuyerWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Buyer
    /// </summary>
    public Task UpdateBuyer(BuyerWhereUniqueInput uniqueId, BuyerUpdateInput updateDto);
}

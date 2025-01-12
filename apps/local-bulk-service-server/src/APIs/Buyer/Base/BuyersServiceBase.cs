using LocalBulkService.APIs;
using LocalBulkService.APIs.Common;
using LocalBulkService.APIs.Dtos;
using LocalBulkService.APIs.Errors;
using LocalBulkService.APIs.Extensions;
using LocalBulkService.Infrastructure;
using LocalBulkService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalBulkService.APIs;

public abstract class BuyersServiceBase : IBuyersService
{
    protected readonly LocalBulkServiceDbContext _context;

    public BuyersServiceBase(LocalBulkServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Buyer
    /// </summary>
    public async Task<Buyer> CreateBuyer(BuyerCreateInput createDto)
    {
        var buyer = new BuyerDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            buyer.Id = createDto.Id;
        }

        _context.Buyers.Add(buyer);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<BuyerDbModel>(buyer.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Buyer
    /// </summary>
    public async Task DeleteBuyer(BuyerWhereUniqueInput uniqueId)
    {
        var buyer = await _context.Buyers.FindAsync(uniqueId.Id);
        if (buyer == null)
        {
            throw new NotFoundException();
        }

        _context.Buyers.Remove(buyer);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Buyers
    /// </summary>
    public async Task<List<Buyer>> Buyers(BuyerFindManyArgs findManyArgs)
    {
        var buyers = await _context
            .Buyers.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return buyers.ConvertAll(buyer => buyer.ToDto());
    }

    /// <summary>
    /// Meta data about Buyer records
    /// </summary>
    public async Task<MetadataDto> BuyersMeta(BuyerFindManyArgs findManyArgs)
    {
        var count = await _context.Buyers.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Buyer
    /// </summary>
    public async Task<Buyer> Buyer(BuyerWhereUniqueInput uniqueId)
    {
        var buyers = await this.Buyers(
            new BuyerFindManyArgs { Where = new BuyerWhereInput { Id = uniqueId.Id } }
        );
        var buyer = buyers.FirstOrDefault();
        if (buyer == null)
        {
            throw new NotFoundException();
        }

        return buyer;
    }

    /// <summary>
    /// Update one Buyer
    /// </summary>
    public async Task UpdateBuyer(BuyerWhereUniqueInput uniqueId, BuyerUpdateInput updateDto)
    {
        var buyer = updateDto.ToModel(uniqueId);

        _context.Entry(buyer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Buyers.Any(e => e.Id == buyer.Id))
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

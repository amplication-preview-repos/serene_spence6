using LocalBulkService.APIs.Dtos;
using LocalBulkService.Infrastructure.Models;

namespace LocalBulkService.APIs.Extensions;

public static class BuyersExtensions
{
    public static Buyer ToDto(this BuyerDbModel model)
    {
        return new Buyer
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static BuyerDbModel ToModel(
        this BuyerUpdateInput updateDto,
        BuyerWhereUniqueInput uniqueId
    )
    {
        var buyer = new BuyerDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            buyer.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            buyer.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return buyer;
    }
}

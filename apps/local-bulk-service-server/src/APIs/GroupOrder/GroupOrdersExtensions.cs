using LocalBulkService.APIs.Dtos;
using LocalBulkService.Infrastructure.Models;

namespace LocalBulkService.APIs.Extensions;

public static class GroupOrdersExtensions
{
    public static GroupOrder ToDto(this GroupOrderDbModel model)
    {
        return new GroupOrder
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static GroupOrderDbModel ToModel(
        this GroupOrderUpdateInput updateDto,
        GroupOrderWhereUniqueInput uniqueId
    )
    {
        var groupOrder = new GroupOrderDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            groupOrder.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            groupOrder.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return groupOrder;
    }
}

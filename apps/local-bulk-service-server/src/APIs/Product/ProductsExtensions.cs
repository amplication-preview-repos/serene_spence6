using LocalBulkService.APIs.Dtos;
using LocalBulkService.Infrastructure.Models;

namespace LocalBulkService.APIs.Extensions;

public static class ProductsExtensions
{
    public static Product ToDto(this ProductDbModel model)
    {
        return new Product
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ProductDbModel ToModel(
        this ProductUpdateInput updateDto,
        ProductWhereUniqueInput uniqueId
    )
    {
        var product = new ProductDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            product.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            product.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return product;
    }
}

using LocalBulkService.Infrastructure;

namespace LocalBulkService.APIs;

public class ProductsService : ProductsServiceBase
{
    public ProductsService(LocalBulkServiceDbContext context)
        : base(context) { }
}

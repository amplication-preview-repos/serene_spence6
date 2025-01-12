using LocalBulkService.Infrastructure;

namespace LocalBulkService.APIs;

public class SuppliersService : SuppliersServiceBase
{
    public SuppliersService(LocalBulkServiceDbContext context)
        : base(context) { }
}

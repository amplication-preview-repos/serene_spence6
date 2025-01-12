using LocalBulkService.Infrastructure;

namespace LocalBulkService.APIs;

public class BuyersService : BuyersServiceBase
{
    public BuyersService(LocalBulkServiceDbContext context)
        : base(context) { }
}

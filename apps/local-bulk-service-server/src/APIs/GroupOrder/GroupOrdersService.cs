using LocalBulkService.Infrastructure;

namespace LocalBulkService.APIs;

public class GroupOrdersService : GroupOrdersServiceBase
{
    public GroupOrdersService(LocalBulkServiceDbContext context)
        : base(context) { }
}

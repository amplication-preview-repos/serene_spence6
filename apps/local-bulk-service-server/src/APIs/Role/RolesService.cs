using LocalBulkService.Infrastructure;

namespace LocalBulkService.APIs;

public class RolesService : RolesServiceBase
{
    public RolesService(LocalBulkServiceDbContext context)
        : base(context) { }
}

using LocalBulkService.Infrastructure;

namespace LocalBulkService.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(LocalBulkServiceDbContext context)
        : base(context) { }
}

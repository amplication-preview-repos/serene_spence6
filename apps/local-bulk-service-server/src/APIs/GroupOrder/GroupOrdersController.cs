using Microsoft.AspNetCore.Mvc;

namespace LocalBulkService.APIs;

[ApiController()]
public class GroupOrdersController : GroupOrdersControllerBase
{
    public GroupOrdersController(IGroupOrdersService service)
        : base(service) { }
}

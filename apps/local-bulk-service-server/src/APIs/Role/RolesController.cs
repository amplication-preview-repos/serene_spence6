using Microsoft.AspNetCore.Mvc;

namespace LocalBulkService.APIs;

[ApiController()]
public class RolesController : RolesControllerBase
{
    public RolesController(IRolesService service)
        : base(service) { }
}

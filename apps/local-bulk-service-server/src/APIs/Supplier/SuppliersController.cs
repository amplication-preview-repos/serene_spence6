using Microsoft.AspNetCore.Mvc;

namespace LocalBulkService.APIs;

[ApiController()]
public class SuppliersController : SuppliersControllerBase
{
    public SuppliersController(ISuppliersService service)
        : base(service) { }
}

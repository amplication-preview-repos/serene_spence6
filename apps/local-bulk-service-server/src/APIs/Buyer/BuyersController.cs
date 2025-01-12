using Microsoft.AspNetCore.Mvc;

namespace LocalBulkService.APIs;

[ApiController()]
public class BuyersController : BuyersControllerBase
{
    public BuyersController(IBuyersService service)
        : base(service) { }
}

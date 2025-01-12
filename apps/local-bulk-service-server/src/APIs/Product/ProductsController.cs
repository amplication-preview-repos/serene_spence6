using Microsoft.AspNetCore.Mvc;

namespace LocalBulkService.APIs;

[ApiController()]
public class ProductsController : ProductsControllerBase
{
    public ProductsController(IProductsService service)
        : base(service) { }
}

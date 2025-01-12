using LocalBulkService.APIs;

namespace LocalBulkService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IBuyersService, BuyersService>();
        services.AddScoped<IGroupOrdersService, GroupOrdersService>();
        services.AddScoped<IProductsService, ProductsService>();
        services.AddScoped<IRolesService, RolesService>();
        services.AddScoped<ISuppliersService, SuppliersService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}

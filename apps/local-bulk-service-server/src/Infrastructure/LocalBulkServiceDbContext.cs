using LocalBulkService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalBulkService.Infrastructure;

public class LocalBulkServiceDbContext : DbContext
{
    public LocalBulkServiceDbContext(DbContextOptions<LocalBulkServiceDbContext> options)
        : base(options) { }

    public DbSet<RoleDbModel> Roles { get; set; }

    public DbSet<SupplierDbModel> Suppliers { get; set; }

    public DbSet<GroupOrderDbModel> GroupOrders { get; set; }

    public DbSet<ProductDbModel> Products { get; set; }

    public DbSet<BuyerDbModel> Buyers { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}

using Microsoft.EntityFrameworkCore;
using SystemManagementFactory.Domain.Entities;

namespace SystemManagementFactory.DB;

public class BaseDbContext(DbContextOptions<BaseDbContext> options) : DbContext(options)
{
    public DbSet<Farmer> Farmers { get; set; }

    public DbSet<BusinessOwner> BusinessOwners { get; set; }

    public DbSet<FarmerGarden> FarmerGardens { get; set; }

    public DbSet<PurchaseRequest> PurchaseRequests { get; set; }

    public DbSet<Crop> Crops { get; set; }

    public DbSet<Transaction> Transactions { get; set; }
}
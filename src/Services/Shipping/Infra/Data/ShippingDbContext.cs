using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data;

public class ShippingDbContext : DbContext
{
    public ShippingDbContext(DbContextOptions<ShippingDbContext> option) : base(option) {}
    public DbSet<Region> Regions { get; set; }
    public DbSet<Shipper> Shippers { get; set; }
    public DbSet<ShipperRegion> ShipperRegions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shipper>(ConfigureShipper);
        modelBuilder.Entity<ShipperRegion>(ConfigureShipperRegion);
    }

    private void ConfigureShipper(EntityTypeBuilder<Shipper> builder)
    {
        builder.HasIndex(s => s.Email)
            .IsUnique();
    }
    
    private void ConfigureShipperRegion(EntityTypeBuilder<ShipperRegion> builder)
    {
        builder.HasKey(sr => sr.Id);
        builder.HasOne(sr => sr.Shipper).WithMany(s => s.ShipperRegions).HasForeignKey(s => s.RegionId);
        builder.HasOne(sr => sr.Region).WithMany(r => r.ShipperRegions).HasForeignKey(r => r.ShipperId);
    }
}
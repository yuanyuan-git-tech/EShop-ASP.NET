using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data;

public class OrderDbContext : DbContext
{
    // inject the dbcontext options
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
    }

    public DbSet<Order> Order { get; set; }
    public DbSet<OrderStatus> OrderStatus { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<ShoppingCart> ShoppingCart { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
    public DbSet<PaymentType> PaymentType { get; set; }
    public DbSet<PaymentMethod> PaymentMethod { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(ConfigureAddress);
        modelBuilder.Entity<ShoppingCart>(ConfigureShoppingCart);
        modelBuilder.Entity<ShoppingCartItem>(ConfigureShoppingCartItem);
    }

    private void ConfigureAddress(EntityTypeBuilder<Address> builder)
    {
        // Fluent API Way
        // specify the rules for Address Entity
        builder.HasKey(a => a.Id);
    }

    private void ConfigureShoppingCart(EntityTypeBuilder<ShoppingCart> builder)
    {
        builder.HasKey(sc => sc.Id);
    }
    private void ConfigureShoppingCartItem(EntityTypeBuilder<ShoppingCartItem> builder)
    {
        builder.HasKey(sci => sci.Id);
    }

    private void ConfigureOrder(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
    }
    
}
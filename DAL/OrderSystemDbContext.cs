using Common;
using Microsoft.EntityFrameworkCore;
using ThreeLayerArchitecture.Common;

namespace ThreeLayerArchitecture.DAL
{
    public class OrderSystemDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Common.OrderDetail> OrderDetails { get; set; }

        public OrderSystemDbContext(DbContextOptions<OrderSystemDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });
        }
    }
}

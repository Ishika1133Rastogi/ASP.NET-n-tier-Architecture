
using Microsoft.EntityFrameworkCore;
using OrderProducts.Domain.Entities;

namespace OrderProducts.Dal.Data { 

    public class ApplicationDbContext : DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
       // public DbSet<OrderDetails> OrderDetails { get; set; }
      //  public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customers)
                .WithMany(or => or.Order)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Orders)
                .WithMany(o => o.OrderDetail)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetails>()
               .HasOne(od => od.Product)
               .WithMany(o => o.Details)
               .HasForeignKey(od => od.ProductId);

            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer
                {
                    CustomerId = 1,
                    CustomerName = "Sample Name1",
                    CustomerAddress = "Sample Address1",
                    TaxIdentifier = "xyz"
                },
                new Customer
                {
                    CustomerId = 2,
                    CustomerName = "Sample Name2",
                    CustomerAddress = "Sample Address2",
                    TaxIdentifier = "pqr"
                });

            modelBuilder.Entity<Order>()
                .HasData(
                new Order
                {
                    OrderId = 1,
                    OrderDate = DateTime.Now,
                    OrederAmount = 100,
                    Comments = "Sample Data1",
                    CustomerId = 1,
                },
                new Order
                {
                    OrderId = 2,
                    OrderDate = DateTime.Now,
                    OrederAmount = 200,
                    Comments = "Sample Data2",
                    CustomerId = 2
                });

            modelBuilder.Entity<Product>()
               .HasData(
               new Product
               {
                   ProductId = 1,
                   ProductCode = "XCYZCODE1",
                   ProductName = "Mobile",
                   ProductDescription = "Mobile Description",
                   ProductPrice = 1000000
               },
               new Product
               {
                   ProductId = 2,
                   ProductCode = "XCYZCODE2",
                   ProductName = "Bike",
                   ProductDescription = "Bike Description",
                   ProductPrice = 2000000
               });

            modelBuilder.Entity<OrderDetails>()
                .HasData(
                new OrderDetails
                {
                    OrderDetailId = 1,
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 50
                },
                new OrderDetails
                {
                    OrderDetailId = 2,
                    OrderId = 2,
                    ProductId = 2,
                    Quantity = 50
                });
        }
    }
}
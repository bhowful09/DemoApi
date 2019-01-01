using DemoApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Data
{
    //scaffold-DbContext "Data Source=SQL7001.site4now.net;Initial Catalog=DB_A43FF5_benhowarddev;User Id=DB_A43FF5_benhowarddev_admin;Password=******;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
    public class BenHowardDevContext : DbContext
    {
        public BenHowardDevContext()
        {
        }

        public BenHowardDevContext(DbContextOptions<BenHowardDevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerEntity> Customers { get; set; }
        public virtual DbSet<OrderEntity> Orders { get; set; }
        public virtual DbSet<OrderItemEntity> OrderItems { get; set; }
        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<SupplierEntity> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerEntity>(entity =>
            {
                entity.ToTable("Customer", "dbo");

                entity.HasIndex(e => new { e.LastName, e.FirstName })
                    .HasName("IndexCustomerName");

                entity.Property(e => e.City).HasMaxLength(40);

                entity.Property(e => e.Country).HasMaxLength(40);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Phone).HasMaxLength(20);
            });

            modelBuilder.Entity<OrderEntity>(entity =>
            {
                entity.ToTable("Order", "dbo");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("IndexOrderCustomerId");

                entity.HasIndex(e => e.OrderDate)
                    .HasName("IndexOrderOrderDate");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderNumber).HasMaxLength(10);

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(12, 2)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_REFERENCE_CUSTOMER");
            });

            modelBuilder.Entity<OrderItemEntity>(entity =>
            {
                entity.ToTable("OrderItem", "dbo");

                entity.HasIndex(e => e.OrderId)
                    .HasName("IndexOrderItemOrderId");

                entity.HasIndex(e => e.ProductId)
                    .HasName("IndexOrderItemProductId");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(12, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERITE_REFERENCE_ORDER");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERITE_REFERENCE_PRODUCT");
            });

            modelBuilder.Entity<ProductEntity>(entity =>
            {
                entity.ToTable("Product", "dbo");

                entity.HasIndex(e => e.ProductName)
                    .HasName("IndexProductName");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("IndexProductSupplierId");

                entity.Property(e => e.Package).HasMaxLength(30);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(12, 2)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_REFERENCE_SUPPLIER");
            });

            modelBuilder.Entity<SupplierEntity>(entity =>
            {
                entity.ToTable("Supplier", "dbo");

                entity.HasIndex(e => e.CompanyName)
                    .HasName("IndexSupplierName");

                entity.HasIndex(e => e.Country)
                    .HasName("IndexSupplierCountry");

                entity.Property(e => e.City).HasMaxLength(40);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ContactName).HasMaxLength(50);

                entity.Property(e => e.ContactTitle).HasMaxLength(40);

                entity.Property(e => e.Country).HasMaxLength(40);

                entity.Property(e => e.Fax).HasMaxLength(30);

                entity.Property(e => e.Phone).HasMaxLength(30);
            });
        }
    }
}
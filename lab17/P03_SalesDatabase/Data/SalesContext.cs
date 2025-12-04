using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
  public class SalesContext : DbContext
  {
      public SalesContext() { }
      
      public SalesContext(DbContextOptions<SalesContext> options)
          : base(options) { }
      
      public DbSet<Product> Products { get; set; }
      public DbSet<Customer> Customers { get; set; }
      public DbSet<Store> Stores { get; set; }
      public DbSet<Sale> Sales { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
          if (!optionsBuilder.IsConfigured)
          {
              optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SalesDatabase;Trusted_Connection=True;TrustServerCertificate=True;");
          }
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
          modelBuilder.Entity<Product>(entity =>
          {
              entity.HasKey(p => p.ProductId);
              
              entity.Property(p => p.Name)
                  .HasMaxLength(50)
                  .IsUnicode(true)
                  .IsRequired();
              
              entity.Property(p => p.Description)
                  .HasMaxLength(250)
                  .HasDefaultValue("No description");
          });
          
          modelBuilder.Entity<Customer>(entity =>
          {
              entity.HasKey(c => c.CustomerId);

              entity.Property(c => c.Name)
                  .HasMaxLength(100)
                  .IsUnicode(true)
                  .IsRequired();

              entity.Property(c => c.Email)
                  .HasMaxLength(80)
                  .IsUnicode(false)
                  .IsRequired();
          });
          
          modelBuilder.Entity<Sale>(entity =>
          {
              entity.Property(s => s.Date)
                  .HasDefaultValueSql("GETDATE()"); 
          });
          
          modelBuilder.Entity<Store>(entity =>
          {
              entity.HasKey(s => s.StoreId);

              entity.Property(s => s.Name)
                  .HasMaxLength(80)
                  .IsUnicode(true)
                  .IsRequired();
          });
          
          modelBuilder.Entity<Sale>(entity =>
          { // ключі
              entity.HasKey(s => s.SaleId);
              
              entity.HasOne(s => s.Product)
                  .WithMany(p => p.Sales)
                  .HasForeignKey(s => s.ProductId);

              entity.HasOne(s => s.Customer)
                  .WithMany(c => c.Sales)
                  .HasForeignKey(s => s.CustomerId);

              entity.HasOne(s => s.Store)
                  .WithMany(st => st.Sales)
                  .HasForeignKey(s => s.StoreId);
          });
      }
  }  
}


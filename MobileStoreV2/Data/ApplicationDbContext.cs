using Microsoft.EntityFrameworkCore;
using MobileStoreV2.Models;

namespace MobileStoreV2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet for Products
        public DbSet<Product> Products { get; set; }

        // DbSet for Bills
        public DbSet<Bill> Bills { get; set; }

        // DbSet for Categories
        public DbSet<Category> Categories { get; set; }

        // DbSet for Sells
        public DbSet<Sell> Sells { get; set; }

        // DbSet for Brands
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the one-to-many relationship between Bill and Sell
            modelBuilder.Entity<Bill>()
                .HasMany(b => b.Sells)
                .WithOne(s => s.Bill)
                .HasForeignKey(s => s.BillId);

            // Configuring the one-to-many relationship between Brand and Product
            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Products)
                .WithOne(p => p.Brand)
                .HasForeignKey(p => p.BrandId);

            // Configuring the one-to-many relationship between Category and Product
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}

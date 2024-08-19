using Microsoft.EntityFrameworkCore;
using DataCore.Models;
using DataCore.Models.DataCore.Models;
namespace DataCore.Data
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

        // DbSet for Brands
        public DbSet<ImageModel> images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer($"Server={Environment.MachineName}\\{Environment.UserName};Database=MobileStore;Trusted_Connection=True;TrustServerCertificate=True;");
            optionsBuilder
                   .AddInterceptors(new SoftDeleteInterceptor());


            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>(entity =>
            //{
            //    // Other configurations
            //    entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            //    entity.Property(e => e.DeletedAt).HasColumnType("datetime2");
            //});

            // Configuring the one-to-many relationship between Product and Barnd
            modelBuilder.Entity<Product>()
                .HasQueryFilter(x => x.IsDeleted == false)
                .HasOne(c => c.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuring the one-to-many relationship between Product and Category
            modelBuilder.Entity<Product>()
                .HasQueryFilter(x => x.IsDeleted == false)
                .HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);




            // Configuring the one-to-many relationship between Bill and Sell
            modelBuilder.Entity<Bill>()
                .HasQueryFilter(x => x.IsDeleted == false)
                .HasMany(b => b.Sells)
                .WithOne(s => s.Bill)
                .HasForeignKey(s => s.BillId)
                .OnDelete(DeleteBehavior.Cascade);



            // Configuring the one-to-many relationship between Brand and Product
            modelBuilder.Entity<Brand>()
                .HasQueryFilter(x => x.IsDeleted == false)
                .HasMany(b => b.Products)
                .WithOne(p => p.Brand)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuring the one-to-many relationship between Category and Product
            modelBuilder.Entity<Category>()
                .HasQueryFilter(x => x.IsDeleted == false)
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}

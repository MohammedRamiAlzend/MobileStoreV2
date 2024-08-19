
namespace MobileStoreV2.DatabaseSeeder.Classes;

public class ProductSeeder : BaseSeeder<Product>
{
    protected override IEnumerable<Product> GetSeedData()
    {
        return new List<Product>
        {
            new Product { Name = "Product 1", Description = "Description 1", Price = 10.99, Discount = 0, ImageId= 2, Quantity = 100, BarCode = 123456, InsertDate = DateTime.Now, BrandId = 1, CategoryId = 1 },
            new Product { Name = "Product 2", Description = "Description 2", Price = 15.49, Discount = 5, ImageId= 1, Quantity = 50, BarCode = 123457, InsertDate = DateTime.Now, BrandId = 2, CategoryId = 2 }
        };
    }

    public override void Seed(ApplicationDbContext dbContext)
    {
        Seed(dbContext, GetSeedData());
    }
}

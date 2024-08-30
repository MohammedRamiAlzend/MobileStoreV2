
namespace MobileStoreV2.DatabaseSeeder.Classes;
public class BrandSeeder : BaseSeeder<Brand>
{
    protected override IEnumerable<Brand> GetSeedData()
    {
        return new List<Brand>
        {
                //new Brand { Name = "Brand 1" },
                //new Brand { Name = "Brand 2" }
        };
    }
    public override void Seed(ApplicationDbContext dbContext)
    {
        Seed(dbContext, GetSeedData());
    }


}

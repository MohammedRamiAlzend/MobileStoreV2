
namespace MobileStoreV2.DatabaseSeeder.Classes;

public class CategorySeeder : BaseSeeder<Category>
{

    protected override IEnumerable<Category> GetSeedData()
    {
        return new List<Category>
        {
            //new Category { Name = "Category 1" },
            //new Category { Name = "Category 2" }
        };
    }
    public override void Seed(ApplicationDbContext dbContext)
    {
        Seed(dbContext, GetSeedData());
    }
}

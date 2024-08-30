

namespace MobileStoreV2.DatabaseSeeder.Classes;

public class BillSeeder : BaseSeeder<Bill>
{
    protected override IEnumerable<Bill> GetSeedData()
    {
        return new List<Bill>
            {
                //new Bill { Discount = 5, Total = 30.00, FinalTotal = 28.50, Date = DateTime.Now }
            };
    }
    public override void Seed(ApplicationDbContext dbContext)
    {
        Seed(dbContext, GetSeedData());
    }
}

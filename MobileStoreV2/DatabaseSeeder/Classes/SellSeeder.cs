namespace MobileStoreV2.DatabaseSeeder.Classes;

public class SellSeeder : BaseSeeder<Sell>
{
    protected override IEnumerable<Sell> GetSeedData()
    {
        return new List<Sell>
            {
                //new Sell { TotalProducts = 2, TotalAmount = 20.98, BillId = 1, ProductId = 1 },
                //new Sell { TotalProducts = 1, TotalAmount = 10.99, BillId = 1, ProductId = 2 }
            };
    }
    public override void Seed(ApplicationDbContext dbContext)
    {
        Seed(dbContext, GetSeedData());
    }
}
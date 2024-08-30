
using DataCore.Models.DataCore.Models;

namespace MobileStoreV2.DatabaseSeeder.Classes;

public class ImagesSeeder : BaseSeeder<ImageModel>
{

    protected override IEnumerable<ImageModel> GetSeedData()
    {
        return new List<ImageModel>
        {
            new ImageModel { ImageName = "0.jpg" , ImagePath= "uploads/0.jpg" , UploadDate = DateTime.Now   },
        };
    }
    public override void Seed(ApplicationDbContext dbContext)
    {
        Seed(dbContext, GetSeedData());
    }
}

namespace MobileStoreV2.DatabaseSeeder.Classes;

public interface IEntitySeeder
{
    void Seed(ApplicationDbContext dbContext);
}
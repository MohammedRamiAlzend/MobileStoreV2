namespace MobileStoreV2.DatabaseSeeder;

public static class DataSeeder
{
    private static readonly List<IEntitySeeder> _seeders = new()
        {
            new BrandSeeder(),
            new CategorySeeder(),
            new ProductSeeder(),
            new BillSeeder(),
            new SellSeeder(),
            new ImagesSeeder(),
        };

    public static void EnsurePopulated(MauiApp app)
    {
        ApplicationDbContext dbContext = app.Services
                .GetRequiredService<ApplicationDbContext>();

        if (dbContext.Database.GetPendingMigrations().Any())
        {
            dbContext.Database.Migrate();
        }
        foreach (var seeder in _seeders)
        {
            seeder.Seed(dbContext);
        }
    }

}


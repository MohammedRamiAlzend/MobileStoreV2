using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStoreV2.DatabaseSeeder.Classes;
public abstract class BaseSeeder<TEntity> : IEntitySeeder where TEntity : class
{
    public virtual void Seed(ApplicationDbContext dbContext, IEnumerable<TEntity> data)
    {
        if (!dbContext.Set<TEntity>().IgnoreQueryFilters().Any())
        {
            dbContext.Set<TEntity>().AddRange(data);
            dbContext.SaveChanges();
        }

    }

    public virtual void Seed(ApplicationDbContext dbContext)
    {
        Seed(dbContext, GetSeedData());
    }

    protected abstract IEnumerable<TEntity> GetSeedData();
}

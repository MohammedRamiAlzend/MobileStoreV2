using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using DataCore.Models.SoftDelete;
using System.Threading;
using System.Diagnostics;

public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    //public override InterceptionResult<int> SavingChanges(
    //    DbContextEventData eventData,
    //    InterceptionResult<int> result)
    //{
    //    if (eventData.Context is null)
    //    {
    //        return base.SavingChanges(
    //            eventData, result);
    //    }

    //    IEnumerable<EntityEntry<ISoftDelete>> entries =
    //        eventData
    //            .Context
    //            .ChangeTracker
    //            .Entries<ISoftDelete>()
    //            .Where(e => e.State == EntityState.Deleted);

    //    foreach (EntityEntry<ISoftDelete> softDeletable in entries)
    //    {
    //        if (softDeletable.State == EntityState.Deleted)
    //        {
    //            softDeletable.Entity.IsDeleted = true;
    //            softDeletable.Entity.DeletedAt = DateTime.Now;
    //        }
    //    }
    //    return base.SavingChanges(eventData, result);
    //}
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
       DbContextEventData eventData,
       InterceptionResult<int> result,
       CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
        {
            return base.SavingChangesAsync(
                eventData, result, cancellationToken);
        }

        IEnumerable<EntityEntry<ISoftDelete>> entries =
            eventData
                .Context
                .ChangeTracker
                .Entries<ISoftDelete>()
                .Where(e => e.State == EntityState.Deleted);

        foreach (EntityEntry<ISoftDelete> softDeletable in entries)
        {
            softDeletable.State = EntityState.Modified;
            softDeletable.Entity.IsDeleted = true;
            softDeletable.Entity.DeletedAt = DateTime.Now;
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}